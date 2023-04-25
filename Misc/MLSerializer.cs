using System.Text.Json;

public static class MLSerializer
{
    static string ConvertJsonToMarkdown(JsonElement jsonElement)
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
                    markdown += ConvertArrayToMarkdownList(value.EnumerateArray());
                    break;
                case JsonValueKind.Object:
                    markdown += ConvertJsonToMarkdown(value);
                    break;
            }
        }

        return markdown;
    }

    static string ConvertArrayToMarkdownList(JsonElement.ArrayEnumerator array)
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
