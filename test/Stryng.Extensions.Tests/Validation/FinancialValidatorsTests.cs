using Stryng.Extensions.Validation;

namespace Stryng.Extensions.Tests.Validation;

public class FinancialValidatorsTests
{
    [Fact]
    public void IsIban_ReturnsTrue_ForValidIbans()
    {
        Assert.True(FinancialValidators.IsIban("GB82 WEST 1234 5698 7654 32"));
        Assert.True(FinancialValidators.IsIban("DE89 3704 0044 0532 0130 00"));
        Assert.True(FinancialValidators.IsIban("FR14 2004 1010 0505 0001 3M02 606"));
    }

    [Fact]
    public void IsIban_ReturnsFalse_ForInvalidIbans()
    {
        Assert.False(FinancialValidators.IsIban("INVALIDIBAN"));
        Assert.False(FinancialValidators.IsIban("GB82 WEST 1234 5698 7654")); // Too short
        Assert.False(FinancialValidators.IsIban("")); // Empty
        Assert.False(FinancialValidators.IsIban(null)); // Null
        Assert.False(FinancialValidators.IsIban("GB82WEST1234569876543212345678901234567890")); // Too long
    }

    [Fact]
    public void IsBic_ReturnsTrue_ForValidBics()
    {
        Assert.True(FinancialValidators.IsBic("DEUTDEFF"));
        Assert.True(FinancialValidators.IsBic("NEDSZAJJXXX"));
        Assert.True(FinancialValidators.IsBic("BOFAUS3N"));
    }

    [Fact]
    public void IsBic_ReturnsFalse_ForInvalidBics()
    {
        Assert.False(FinancialValidators.IsBic("INVALIDBIC"));
        Assert.False(FinancialValidators.IsBic("DEUTDE")); // Too short
        Assert.False(FinancialValidators.IsBic("DEUTDEFF1234")); // Too long
        Assert.False(FinancialValidators.IsBic("")); // Empty
        Assert.False(FinancialValidators.IsBic(null)); // Null
    }

    [Fact]
    public void IsCurrency_ReturnsTrue_ForValidCurrencies()
    {
        Assert.True(FinancialValidators.IsCurrency("USD"));
        Assert.True(FinancialValidators.IsCurrency("eur"));
        Assert.True(FinancialValidators.IsCurrency("JPY"));
    }

    [Fact]
    public void IsCurrency_ReturnsFalse_ForInvalidCurrencies()
    {
        Assert.False(FinancialValidators.IsCurrency("XXX"));
        Assert.False(FinancialValidators.IsCurrency("usdollar"));
        Assert.False(FinancialValidators.IsCurrency("")); // Empty
        Assert.False(FinancialValidators.IsCurrency(null)); // Null
    }
}