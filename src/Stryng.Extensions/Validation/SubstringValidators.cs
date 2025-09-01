using System.Globalization;
using System.Text.RegularExpressions;

namespace Stryng.Extensions.Validation;

/// <summary>
/// Provides substring and pattern-based string validation methods.
/// </summary>
public static class SubstringValidators
{
    /// <summary>
    /// Checks if the string contains at least one of the specified substrings.
    /// </summary>
    public static bool ContainsAny(string? input, params string[] substrings) =>
        !string.IsNullOrEmpty(input) && substrings.Any(input.Contains);

    /// <summary>
    /// Checks if the string contains all the of the specified substrings.
    /// </summary>
    public static bool ContainsAll(string? input, params string[] substrings) =>
        !string.IsNullOrEmpty(input) && substrings.All(input.Contains);

    /// <summary>
    /// Checks if the string starts with at least one of the specified prefixes (case-insensitive, invariant culture by default).
    /// </summary>
    public static bool StartsWithAny(string? input, params string[] prefixes) =>
        StartsWithAny(input, CultureInfo.InvariantCulture, prefixes);

    /// <summary>
    /// Checks if the string starts with at least one of the specified prefixes, using the specified culture (case-insensitive).
    /// </summary>
    public static bool StartsWithAny(string? input, CultureInfo culture, params string[] prefixes) =>
        !string.IsNullOrEmpty(input) && prefixes.Any(p => input.StartsWith(p, true, culture));

    /// <summary>
    /// Checks if the string ends with at least one of the specified suffixes (case-insensitive, invariant culture by default).
    /// </summary>
    public static bool EndsWithAny(string? input, params string[] suffixes) =>
        EndsWithAny(input, CultureInfo.InvariantCulture, suffixes);

    /// <summary>
    /// Checks if the string ends with at least one of the specified suffixes, using the specified culture (case-insensitive).
    /// </summary>
    public static bool EndsWithAny(string? input, CultureInfo culture, params string[] suffixes) =>
        !string.IsNullOrEmpty(input) && suffixes.Any(s => input.EndsWith(s, true, culture));

    /// <summary>
    /// Checks if the string matches the specified regular expression pattern.
    /// </summary>
    public static bool MatchesRegex(string? input, string pattern) =>
        !string.IsNullOrEmpty(input) && Regex.IsMatch(input, pattern);
}