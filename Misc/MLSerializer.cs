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

            if (value.ValueKind == JsonValueKind.String)
            {
                markdown += $"{value.GetString()}\n\n";
            }
            else if (value.ValueKind == JsonValueKind.Array)
            {
                JsonElement.ArrayEnumerator array = value.EnumerateArray();
                markdown += ConvertArrayToMarkdownList(array);
            }
            else if (value.ValueKind == JsonValueKind.Object)
            {
                markdown += ConvertJsonToMarkdown(value);
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
