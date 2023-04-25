using System.Text.Json;
using System.Text.Json.Nodes;

public static class MLSerializer
{
    public static string ConvertJsonToMarkdown(JsonDocument json)
    {
        string markdown = "";

        foreach (JsonProperty property in json.RootElement.EnumerateObject())
        {
            string key = property.Name;
            JsonElement value = property.Value;

            markdown += $"## {key}\n";

            if (value.ValueKind == JsonValueKind.String)
            {
                markdown += $"{value}\n\n";
            }
            else if (value.ValueKind == JsonValueKind.Array)
            {
                JsonArray array = JsonArray.Create(value);
                markdown += ConvertArrayToMarkdownList(array);
            }
            else if (value.ValueKind == JsonValueKind.Object)
            {
                markdown += ConvertJsonToMarkdown(JsonDocument.Parse(JsonSerializer.Serialize(value)));
            }
        }

        return markdown;
    }

    public static string ConvertArrayToMarkdownList(JsonArray array)
    {
        string markdownList = "";
        foreach (JsonValue item in array)
        {
            markdownList += $"- {item}\n";
        }
        markdownList += "\n";
        return markdownList;
    }
}
