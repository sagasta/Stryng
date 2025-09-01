using System.Text.RegularExpressions;

namespace Stryng.Extensions.Validation;

/// <summary>
/// Provides string validations for common formats and structured data.
/// </summary>
public static class FormatValidators
{
    /// <summary>
    /// Checks if the string is a valid GUID.
    /// </summary>
    public static bool IsGuid(string? input) =>
        Guid.TryParse(input, out _);

    /// <summary>
    /// Checks if the string is a valid basic email.
    /// </summary>
    public static bool IsEmail(string? input)
    {
        if (string.IsNullOrEmpty(input)) return false;

        const string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
    }

    /// <summary>
    /// Checks if the string is a valid basic URL.
    /// </summary>
    public static bool IsUrl(string? input)
    {
        if (string.IsNullOrEmpty(input)) return false;

        const string pattern = @"^(https?|ftp)://[^\s/$.?#].[^\s]*$";
        return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
    }

    /// <summary>
    /// Checks if the string is a valid Base64-encoded string.
    /// </summary>
    public static bool IsBase64(string? input)
    {
        if (string.IsNullOrEmpty(input)) return false;

        var buffer = new Span<byte>(new byte[input.Length]);
        return Convert.TryFromBase64String(input, buffer, out _);
    }

    /// <summary>
    /// Checks if the string is a valid C# or Java identifier.
    /// Must start with a letter or underscore and can contain letters, digits, or underscores.
    /// </summary>
    public static bool IsIdentifier(string? input)
    {
        if (string.IsNullOrEmpty(input)) return false;

        if (!(char.IsLetter(input[0]) || input[0] == '_')) return false;

        for (var i = 1; i < input.Length; i++)
        {
            if (!(char.IsLetterOrDigit(input[i]) || input[i] == '_')) return false;
        }

        return true;
    }

    /// <summary>
    /// Checks if the string is a strong password.
    /// Default rules: min 8 chars, at least one upper, one lower, one digit, one special char.
    /// </summary>
    /// <param name="input">The string to validate.</param>
    /// <param name="minLength">Minimum length of the password (default 8).</param>
    /// <param name="requireUpper">Require at least one uppercase letter (default true).</param>
    /// <param name="requireLower">Require at least one lowercase letter (default true).</param>
    /// <param name="requireDigit">Require at least one digit (default true).</param>
    /// <param name="requireSpecial">Require at least one special character (default true).</param>
    /// <returns>True if the string meets the strong password criteria.</returns>
    public static bool IsStrongPassword(
        string? input,
        int minLength = 8,
        bool requireUpper = true,
        bool requireLower = true,
        bool requireDigit = true,
        bool requireSpecial = true)
    {
        if (string.IsNullOrEmpty(input) || input.Length < minLength)
            return false;

        if (requireUpper && !input.Any(char.IsUpper))
            return false;

        if (requireLower && !input.Any(char.IsLower))
            return false;

        if (requireDigit && !input.Any(char.IsDigit))
            return false;

        return !requireSpecial || !input.All(char.IsLetterOrDigit);
    }
}