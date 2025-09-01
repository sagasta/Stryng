using Stryng.Extensions.Data;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Stryng.Extensions.Generation;

/// <summary>
/// Provides utilities for generating and transforming text.
/// </summary>
public static class TextGenerator
{
    /// <summary>
    /// Generates a random string with letters and digits.
    /// </summary>
    public static string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string([.. Enumerable.Range(0, length).Select(_ => chars[Random.Shared.Next(chars.Length)])]);
    }

    /// <summary>
    /// Generates a random string with letters only.
    /// </summary>
    public static string GenerateRandomAlpha(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        return new string([.. Enumerable.Range(0, length).Select(_ => chars[Random.Shared.Next(chars.Length)])]);
    }

    /// <summary>
    /// Generates a random string with letters and digits only.
    /// </summary>
    public static string GenerateRandomAlphaNumeric(int length)
    {
        return GenerateRandomString(length);
    }

    /// <summary>
    /// Generates a random password with optional special characters.
    /// </summary>
    public static string GenerateRandomPassword(int length, bool includeSpecial = true)
    {
        const string lettersDigits = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        const string specialChars = "!@#$%^&*()-_=+[]{}|;:'\",.<>?/`~";

        var chars = lettersDigits + (includeSpecial ? specialChars : "");
        return new string([.. Enumerable.Range(0, length).Select(_ => chars[Random.Shared.Next(chars.Length)])]);
    }

    /// <summary>
    /// Reverses the characters in the string.
    /// </summary>
    public static string Reverse(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        var array = input.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }

    /// <summary>
    /// Converts the string into a URL-friendly slug.
    /// </summary>
    public static string Slugify(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;

        var normalized = input.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();

        foreach (var c in normalized)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark && (char.IsLetterOrDigit(c) || c == ' '))
            {
                sb.Append(c);
            }
        }

        var slug = sb.ToString().Normalize(NormalizationForm.FormC);
        slug = Regex.Replace(slug, @"\s+", "-");
        slug = Regex.Replace(slug, @"[^a-zA-Z0-9\-]", "");
        return slug.ToLowerInvariant();
    }

    /// <summary>
    /// Converts the first letter of each word in the string to uppercase (Title Case).
    /// </summary>
    public static string ToTitleCase(string input)
    {
        return string.IsNullOrWhiteSpace(input) ? string.Empty : CultureInfo.InvariantCulture.TextInfo.ToTitleCase(input.ToLowerInvariant());
    }

    /// <summary>
    /// Generates Lorem Ipsum text with the specified number of words.
    /// </summary>
    public static string GenerateLoremIpsum(int words)
    {
        if (words <= 0) return string.Empty;

        return string.Join(" ", Enumerable.Range(0, words)
            .Select(_ => LoremWords.Words[Random.Shared.Next(LoremWords.Words.Length)]));
    }

    /// <summary>
    /// Generates a random sentence with a number of words between minWords and maxWords.
    /// </summary>
    public static string GenerateRandomSentence(int minWords = 4, int maxWords = 12)
    {
        var wordCount = Random.Shared.Next(minWords, maxWords + 1);
        var sentence = GenerateLoremIpsum(wordCount);
        return char.ToUpper(sentence[0]) + sentence[1..] + ".";
    }

    /// <summary>
    /// Generates a random paragraph with the specified number of sentences.
    /// </summary>
    public static string GenerateRandomParagraph(int sentences = 3)
    {
        if (sentences <= 0) return string.Empty;

        return string.Join(" ", Enumerable.Range(0, sentences)
            .Select(_ => GenerateRandomSentence()));
    }

    /// <summary>
    /// Generates a random email address with a fake domain.
    /// </summary>
    public static string GenerateRandomEmail()
    {
        var user = GenerateRandomString(6, 12).ToLowerInvariant();
        var domain = GenerateRandomString(5, 8).ToLowerInvariant();
        return $"{user}@{domain}.com";
    }

    /// <summary>
    /// Generates a random phone number, optionally with a country code.
    /// </summary>
    public static string GenerateRandomPhoneNumber(string? countryCode = null)
    {
        var number = string.Concat(Enumerable.Range(0, 10).Select(_ => Random.Shared.Next(0, 10).ToString()));
        return string.IsNullOrWhiteSpace(countryCode) ? number : $"+{countryCode}{number}";
    }

    private static string GenerateRandomString(int minLength, int maxLength)
    {
        var length = Random.Shared.Next(minLength, maxLength + 1);
        const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        return new string([.. Enumerable.Range(0, length).Select(_ => chars[Random.Shared.Next(chars.Length)])]);
    }

    /// <summary>
    /// Wraps the input text into lines of a maximum specified length, preserving words.
    /// Returns a collection of lines.
    /// </summary>
    /// <param name="input">The text to wrap.</param>
    /// <param name="maxLineLength">The maximum length of each line.</param>
    /// <returns>An IEnumerable of lines.</returns>
    public static IEnumerable<string> WrapText(string input, int maxLineLength)
    {
        if (string.IsNullOrWhiteSpace(input) || maxLineLength <= 0)
            yield break;

        var words = input.Split([' ', '\t', '\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        var currentLine = new StringBuilder();

        foreach (var word in words)
        {
            if (currentLine.Length + word.Length + 1 > maxLineLength)
            {
                if (currentLine.Length > 0)
                {
                    yield return currentLine.ToString().TrimEnd();
                    currentLine.Clear();
                }
            }

            currentLine.Append(word + " ");
        }

        if (currentLine.Length > 0)
            yield return currentLine.ToString().TrimEnd();
    }
}