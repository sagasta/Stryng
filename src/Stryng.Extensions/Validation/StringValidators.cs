namespace Stryng.Extensions.Validation;

/// <summary>
/// Provides basic string validation methods for length and null/empty checks.
/// </summary>
public static class BasicStringValidators
{
    /// <summary>
    /// Checks if the string is null or empty.
    /// </summary>
    public static bool IsNullOrEmpty(string? input) =>
        string.IsNullOrEmpty(input);

    /// <summary>
    /// Checks if the string is null or consists only of whitespace characters.
    /// </summary>
    public static bool IsNullOrWhiteSpace(string? input) =>
        string.IsNullOrWhiteSpace(input);

    /// <summary>
    /// Checks if the string is not null and not empty.
    /// </summary>
    public static bool IsNotNullOrEmpty(string? input) =>
        !string.IsNullOrEmpty(input);

    /// <summary>
    /// Checks if the string is not null and contains characters other than whitespace.
    /// </summary>
    public static bool IsNotNullOrWhiteSpace(string? input) =>
        !string.IsNullOrWhiteSpace(input);

    /// <summary>
    /// Checks if the string has exactly the specified length.
    /// </summary>
    public static bool HasLength(string? input, int length) =>
        input?.Length == length;

    /// <summary>
    /// Checks if the string has at least the specified minimum length.
    /// </summary>
    public static bool HasMinLength(string? input, int min) =>
        input != null && input.Length >= min;

    /// <summary>
    /// Checks if the string has at most the specified maximum length.
    /// </summary>
    public static bool HasMaxLength(string? input, int max) =>
        input != null && input.Length <= max;
}