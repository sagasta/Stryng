using Stryng.Extensions.Validation;

namespace Stryng.Extensions.Tests.Validation;

public class SubstringValidatorsTests
{
    [Fact]
    public void ContainsAny_ReturnsTrue_IfContainsAnySubstring()
    {
        Assert.True(SubstringValidators.ContainsAny("hello world", "world", "foo"));
        Assert.False(SubstringValidators.ContainsAny("hello", "foo", "bar"));
    }

    [Fact]
    public void ContainsAll_ReturnsTrue_IfContainsAllSubstrings()
    {
        Assert.True(SubstringValidators.ContainsAll("hello world", "hello", "world"));
        Assert.False(SubstringValidators.ContainsAll("hello world", "hello", "foo"));
    }

    [Fact]
    public void StartsWithAny_ReturnsTrue_IfStartsWithAnyPrefix()
    {
        Assert.True(SubstringValidators.StartsWithAny("hello world", "hello", "foo"));
        Assert.False(SubstringValidators.StartsWithAny("world hello", "hello", "foo"));
    }

    [Fact]
    public void EndsWithAny_ReturnsTrue_IfEndsWithAnySuffix()
    {
        Assert.True(SubstringValidators.EndsWithAny("hello world", "world", "foo"));
        Assert.False(SubstringValidators.EndsWithAny("hello world", "hello", "foo"));
    }

    [Fact]
    public void MatchesRegex_ReturnsTrue_IfMatchesPattern()
    {
        Assert.True(SubstringValidators.MatchesRegex("abc123", @"\d+"));
        Assert.False(SubstringValidators.MatchesRegex("abcdef", @"\d+"));
    }
}