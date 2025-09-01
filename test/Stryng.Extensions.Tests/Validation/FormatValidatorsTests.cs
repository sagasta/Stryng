using Stryng.Extensions.Validation;

namespace Stryng.Extensions.Tests.Validation;

public class FormatValidatorsTests
{
    [Fact]
    public void IsGuid_ReturnsTrue_ForValidGuid()
    {
        Assert.True(FormatValidators.IsGuid("d3c1a1e2-5b6a-4c2a-9e2a-1b2c3d4e5f6a"));
        Assert.False(FormatValidators.IsGuid("not-a-guid"));
        Assert.False(FormatValidators.IsGuid(""));
        Assert.False(FormatValidators.IsGuid(null));
    }

    [Fact]
    public void IsEmail_ReturnsTrue_ForValidEmail()
    {
        Assert.True(FormatValidators.IsEmail("user@example.com"));
        Assert.False(FormatValidators.IsEmail("userexample.com"));
        Assert.False(FormatValidators.IsEmail("user@.com"));
        Assert.False(FormatValidators.IsEmail(""));
        Assert.False(FormatValidators.IsEmail(null));
    }

    [Fact]
    public void IsUrl_ReturnsTrue_ForValidUrl()
    {
        Assert.True(FormatValidators.IsUrl("http://example.com"));
        Assert.True(FormatValidators.IsUrl("https://example.com/path?query=1"));
        Assert.True(FormatValidators.IsUrl("ftp://example.com/resource"));
        Assert.False(FormatValidators.IsUrl("example.com"));
        Assert.False(FormatValidators.IsUrl("http:/example.com"));
        Assert.False(FormatValidators.IsUrl(""));
        Assert.False(FormatValidators.IsUrl(null));
    }

    [Fact]
    public void IsBase64_ReturnsTrue_ForValidBase64()
    {
        Assert.True(FormatValidators.IsBase64("SGVsbG8gd29ybGQ=")); // "Hello world"
        Assert.False(FormatValidators.IsBase64("NotBase64!"));
        Assert.False(FormatValidators.IsBase64(""));
        Assert.False(FormatValidators.IsBase64(null));
    }

    [Fact]
    public void IsIdentifier_ReturnsTrue_ForValidIdentifiers()
    {
        Assert.True(FormatValidators.IsIdentifier("myVar"));
        Assert.True(FormatValidators.IsIdentifier("_myVar123"));
        Assert.False(FormatValidators.IsIdentifier("123abc"));
        Assert.False(FormatValidators.IsIdentifier("my-var"));
        Assert.False(FormatValidators.IsIdentifier(""));
        Assert.False(FormatValidators.IsIdentifier(null));
    }

    [Fact]
    public void IsStrongPassword_DefaultRules()
    {
        Assert.True(FormatValidators.IsStrongPassword("Abcdef1!"));
        Assert.False(FormatValidators.IsStrongPassword("abcdefg1!")); // No uppercase
        Assert.False(FormatValidators.IsStrongPassword("ABCDEFG1!")); // No lowercase
        Assert.False(FormatValidators.IsStrongPassword("Abcdefgh!")); // No digit
        Assert.False(FormatValidators.IsStrongPassword("Abcdefg1"));  // No special char
        Assert.False(FormatValidators.IsStrongPassword("Ab1!"));      // Too short
        Assert.False(FormatValidators.IsStrongPassword(""));
        Assert.False(FormatValidators.IsStrongPassword(null));
    }

    [Fact]
    public void IsStrongPassword_CustomRules()
    {
        // Only require length and digit
        Assert.True(FormatValidators.IsStrongPassword("12345678", minLength: 8, requireUpper: false, requireLower: false, requireDigit: true, requireSpecial: false));
        // Require special, but input has none
        Assert.False(FormatValidators.IsStrongPassword("Abcdef12", requireSpecial: true));
    }
}