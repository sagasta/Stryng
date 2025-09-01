using Stryng.Extensions.Validation;

namespace Stryng.Extensions.Tests.Validation;

public class BasicStringValidatorsTests
{
    [Fact]
    public void IsNullOrEmpty_WorksAsExpected()
    {
        Assert.True(BasicStringValidators.IsNullOrEmpty(null));
        Assert.True(BasicStringValidators.IsNullOrEmpty(""));
        Assert.False(BasicStringValidators.IsNullOrEmpty(" "));
        Assert.False(BasicStringValidators.IsNullOrEmpty("abc"));
    }

    [Fact]
    public void IsNullOrWhiteSpace_WorksAsExpected()
    {
        Assert.True(BasicStringValidators.IsNullOrWhiteSpace(null));
        Assert.True(BasicStringValidators.IsNullOrWhiteSpace(""));
        Assert.True(BasicStringValidators.IsNullOrWhiteSpace("   "));
        Assert.False(BasicStringValidators.IsNullOrWhiteSpace("abc"));
        Assert.False(BasicStringValidators.IsNullOrWhiteSpace(" a "));
    }

    [Fact]
    public void IsNotNullOrEmpty_WorksAsExpected()
    {
        Assert.False(BasicStringValidators.IsNotNullOrEmpty(null));
        Assert.False(BasicStringValidators.IsNotNullOrEmpty(""));
        Assert.True(BasicStringValidators.IsNotNullOrEmpty(" "));
        Assert.True(BasicStringValidators.IsNotNullOrEmpty("abc"));
    }

    [Fact]
    public void IsNotNullOrWhiteSpace_WorksAsExpected()
    {
        Assert.False(BasicStringValidators.IsNotNullOrWhiteSpace(null));
        Assert.False(BasicStringValidators.IsNotNullOrWhiteSpace(""));
        Assert.False(BasicStringValidators.IsNotNullOrWhiteSpace("   "));
        Assert.True(BasicStringValidators.IsNotNullOrWhiteSpace("abc"));
        Assert.True(BasicStringValidators.IsNotNullOrWhiteSpace(" a "));
    }

    [Fact]
    public void HasLength_WorksAsExpected()
    {
        Assert.True(BasicStringValidators.HasLength("abc", 3));
        Assert.False(BasicStringValidators.HasLength("abc", 2));
        Assert.False(BasicStringValidators.HasLength(null, 0));
        Assert.True(BasicStringValidators.HasLength("", 0));
    }

    [Fact]
    public void HasMinLength_WorksAsExpected()
    {
        Assert.True(BasicStringValidators.HasMinLength("abc", 2));
        Assert.True(BasicStringValidators.HasMinLength("abc", 3));
        Assert.False(BasicStringValidators.HasMinLength("abc", 4));
        Assert.False(BasicStringValidators.HasMinLength(null, 0));
    }

    [Fact]
    public void HasMaxLength_WorksAsExpected()
    {
        Assert.True(BasicStringValidators.HasMaxLength("abc", 3));
        Assert.True(BasicStringValidators.HasMaxLength("abc", 4));
        Assert.False(BasicStringValidators.HasMaxLength("abc", 2));
        Assert.False(BasicStringValidators.HasMaxLength(null, 0));
    }
}