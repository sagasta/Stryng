using System.Text.Json;
using System.Xml;

namespace Stryng.Extensions.Validation;

/// <summary>
/// Provides validations for serialized or structured data strings.
/// </summary>
public static class StructuredDataValidators
{
    /// <summary>
    /// Checks if the string is a valid JSON document.
    /// </summary>
    public static bool IsJson(string? input)
    {
        if (string.IsNullOrWhiteSpace(input)) return false;

        try
        {
            using var doc = JsonDocument.Parse(input);
            return true;
        }
        catch (JsonException)
        {
            return false;
        }
    }

    /// <summary>
    /// Checks if the string is a valid XML document.
    /// </summary>
    public static bool IsXml(string? input)
    {
        if (string.IsNullOrWhiteSpace(input)) return false;

        try
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(input);
            return true;
        }
        catch (XmlException)
        {
            return false;
        }
    }
}