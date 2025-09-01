using System.Text.RegularExpressions;
using Stryng.Extensions.Data;

namespace Stryng.Extensions.Validation;

/// <summary>
/// Provides financial-related string validations.
/// </summary>
public static class FinancialValidators
{
    /// <summary>
    /// Checks if the string is a valid IBAN.
    /// </summary>
    public static bool IsIban(string? input)
    {
        if (string.IsNullOrWhiteSpace(input)) return false;

        var iban = input.Replace(" ", string.Empty).ToUpperInvariant();
        if (iban.Length is < 15 or > 34) return false;

        var rearranged = iban[4..] + iban[..4];
        var numericIban = string.Concat(rearranged.Select(c => char.IsLetter(c) ? (c - 'A' + 10).ToString() : c.ToString()));

        return BigIntegerTryMod97(numericIban) == 1;
    }

    private static int BigIntegerTryMod97(string numericIban)
    {
        return numericIban.Aggregate(0, (current, c) => (current * 10 + (c - '0')) % 97);
    }

    /// <summary>
    /// Checks if the string is a valid BIC/SWIFT code.
    /// </summary>
    public static bool IsBic(string? input)
    {
        return !string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, "^[A-Z]{4}[A-Z]{2}[A-Z0-9]{2}([A-Z0-9]{3})?$", RegexOptions.IgnoreCase);
    }

    /// <summary>
    /// Checks if the string is a valid ISO 4217 currency code.
    /// </summary>
    public static bool IsCurrency(string? input) =>
        !string.IsNullOrWhiteSpace(input) && CurrencyCodes.All.Contains(input.ToUpperInvariant());
}