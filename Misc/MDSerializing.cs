using System.Text.Json;
using System.Text.Json.Nodes;

public static class MDSerializing
{
    public static string ToMarkdown(this JsonElement jsonElement)
    {
        string markdown = "";

        foreach (JsonProperty property in jsonElement.EnumerateObject())
        {
            string key = property.Name;
            JsonElement value = property.Value;

            markdown += $"## {key}\n";

            switch (value.ValueKind)
            {
                case JsonValueKind.String:
                    markdown += $"{value.GetString()}\n\n";
                    break;
                case JsonValueKind.Array:
                    markdown += value.EnumerateArray().ConvertArrayToMarkdownList();
                    break;
                case JsonValueKind.Object:
                    markdown += ToMarkdown(value);
                    break;
            }
        }

        return markdown;
    }

    public static JsonElement ToJsonElement(this string markdown)
    {
        //var options = new JsonSerializerOptions
        //{
        //PropertyNameCaseInsensitive = true
        //};

        var root = new JsonObject();

        string[] lines = markdown.Split('\n');
        string currentKey = null;
        JsonArray currentArray = null;

        foreach (string line in lines)
        {
            if (line.StartsWith("## "))
            {
                currentKey = line.Substring(3).Trim();
                currentArray = null;
            }
            else if (line.StartsWith("- "))
            {
                if (currentArray == null)
                {
                    currentArray = new JsonArray();
                    root[currentKey] = currentArray;
                }
                currentArray.Add(line.Substring(2).Trim());
            }
            else if (!string.IsNullOrWhiteSpace(line))
            {
                root[currentKey] = line.Trim();
                currentArray = null;
            }
        }

        return JsonDocument.Parse(JsonSerializer.Serialize(root)).RootElement;
    }

    public static string ConvertArrayToMarkdownList(this JsonElement.ArrayEnumerator array)
    {
        string markdownList = "";
        while (array.MoveNext())
        {
            JsonElement item = array.Current;
            markdownList += $"- {item}\n";
        }
        markdownList += "\n";
        return markdownList;
    }
}
