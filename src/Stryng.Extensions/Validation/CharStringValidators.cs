using System.Globalization;
using System.Text.RegularExpressions;

namespace Stryng.Extensions.Validation;

/// <summary>
/// Provides character-based string validation methods.
/// </summary>
public static class CharStringValidators
{
    private static readonly char[] DefaultSpecialChars = "!@#$%^&*()-_=+[]{}|;:'\",.<>?/`~".ToCharArray();

    /// <summary>
    /// Checks if the string contains only letters
    /// </summary>
    public static bool IsAlpha(string? input) =>
        !string.IsNullOrEmpty(input) && input.All(char.IsLetter);

    /// <summary>
    /// Checks if the string contains only uppercase letters.
    /// </summary>
    public static bool IsUpperAlpha(string? input) =>
        IsUpperAlpha(input, CultureInfo.InvariantCulture);

    /// <summary>
    /// Checks if the string contains only uppercase letters
    /// </summary>
    public static bool IsUpperAlpha(string? input, CultureInfo culture) =>
        !string.IsNullOrEmpty(input) &&
        input.All(c => char.IsLetter(c) && char.ToUpper(c, culture) == c);

    /// <summary>
    /// Checks if the string contains only lowercase letters.
    /// </summary>
    public static bool IsLowerAlpha(string? input) =>
        IsLowerAlpha(input, CultureInfo.InvariantCulture);

    /// <summary>
    /// Checks if the string contains only lowercase letters
    /// </summary>
    public static bool IsLowerAlpha(string? input, CultureInfo culture) =>
        !string.IsNullOrEmpty(input) &&
        input.All(c => char.IsLetter(c) && char.ToLower(c, culture) == c);

    /// <summary>
    /// Checks if all letters in the string are lowercase.
    /// </summary>
    public static bool IsLowerCase(string? input) =>
        IsLowerCase(input, CultureInfo.InvariantCulture);

    /// <summary>
    /// Checks if all letters in the string are lowercase
    /// </summary>
    public static bool IsLowerCase(string? input, CultureInfo culture) =>
        !string.IsNullOrEmpty(input) &&
        input.All(c => !char.IsLetter(c) || char.ToLower(c, culture) == c);

    /// <summary>
    /// Checks if all letters in the string are uppercase.
    /// </summary>
    public static bool IsUpperCase(string? input) =>
        IsUpperCase(input, CultureInfo.InvariantCulture);

    /// <summary>
    /// Checks if all letters in the string are uppercase
    /// </summary>
    public static bool IsUpperCase(string? input, CultureInfo culture) =>
        !string.IsNullOrEmpty(input) &&
        input.All(c => !char.IsLetter(c) || char.ToUpper(c, culture) == c);

    /// <summary>
    /// Checks if the string contains only digits (0-9).
    /// </summary>
    public static bool IsNumeric(string? input) =>
        !string.IsNullOrEmpty(input) && input.All(char.IsDigit);

    /// <summary>
    /// Checks if the string contains only binary digits (0 or 1).
    /// </summary>
    public static bool IsBinary(string? input) =>
        !string.IsNullOrEmpty(input) && input.All(c => c is '0' or '1');

    /// <summary>
    /// Checks if the string contains only hexadecimal characters (0-9, A-F, a-f).
    /// </summary>
    public static bool IsHexadecimal(string? input) =>
        !string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"\A\b[0-9a-fA-F]+\b\Z");
    
    /// <summary>
    /// Checks if the string contains only letters or digits
    /// </summary>
    public static bool IsAlphaNumeric(string? input) =>
        !string.IsNullOrEmpty(input) && input.All(char.IsLetterOrDigit);

    /// <summary>
    /// Checks if the string contains at least one digit.
    /// </summary>
    public static bool HasDigits(string? input) =>
        !string.IsNullOrEmpty(input) && input.Any(char.IsDigit);

    /// <summary>
    /// Checks if the string contains at least one letter
    /// </summary>
    public static bool HasLetters(string? input) =>
        !string.IsNullOrEmpty(input) && input.Any(char.IsLetter);

    /// <summary>
    /// Checks if the string contains any special character.
    /// Uses a default set of common special characters, can be extended with extra chars.
    /// </summary>
    public static bool HasSpecialChars(string? input, params char[] extraChars)
    {
        if (string.IsNullOrEmpty(input)) return false;

        var allChars = DefaultSpecialChars;
        if (extraChars.Length > 0)
        {
            allChars = [.. allChars, .. extraChars];
        }

        return input.Any(c => allChars.Contains(c));
    }

    /// <summary>
    /// Checks if the string contains only the specified characters.
    /// </summary>
    public static bool ContainsOnly(string? input, params char[] chars) =>
        !string.IsNullOrEmpty(input) && input.All(chars.Contains);

    /// <summary>
    /// Checks if the string contains none of the specified characters.
    /// </summary>
    public static bool ContainsNone(string? input, params char[] chars) =>
        !string.IsNullOrEmpty(input) && input.All(c => !chars.Contains(c));
}