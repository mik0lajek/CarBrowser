using System.Text.Json;

namespace CarBrowser.Tools
{
    public static class VehicleFormatter
    {
        public static string FormatKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return key;

            var withSpaces = key.Replace("-", " ");
            return char.ToUpper(withSpaces[0]) + withSpaces.Substring(1);
        }

        public static string FormatValue(JsonElement value)
        {
            return value.ValueKind switch
            {
                JsonValueKind.String => value.GetString(),
                JsonValueKind.Number => value.GetRawText(),
                JsonValueKind.True => "Tak",
                JsonValueKind.False => "Nie",
                JsonValueKind.Null => "-",
                _ => value.GetRawText()
            };
        }
    }
}
