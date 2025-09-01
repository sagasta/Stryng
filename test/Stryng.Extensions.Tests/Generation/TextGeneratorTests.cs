using Stryng.Extensions.Generation;

namespace Stryng.Extensions.Tests.Generation;

public class TextGeneratorTests
{
    [Fact]
    public void GenerateRandomString_ReturnsCorrectLength_AndAlphaNumeric()
    {
        var result = TextGenerator.GenerateRandomString(10);
        Assert.Equal(10, result.Length);
        Assert.All(result, c => Assert.True(char.IsLetterOrDigit(c)));
    }

    [Fact]
    public void GenerateRandomAlpha_ReturnsCorrectLength_AndAlphaOnly()
    {
        var result = TextGenerator.GenerateRandomAlpha(8);
        Assert.Equal(8, result.Length);
        Assert.All(result, c => Assert.True(char.IsLetter(c)));
    }

    [Fact]
    public void GenerateRandomAlphaNumeric_ReturnsCorrectLength_AndAlphaNumeric()
    {
        var result = TextGenerator.GenerateRandomAlphaNumeric(12);
        Assert.Equal(12, result.Length);
        Assert.All(result, c => Assert.True(char.IsLetterOrDigit(c)));
    }

    [Fact]
    public void GenerateRandomPassword_ReturnsCorrectLength_AndContainsSpecialIfRequested()
    {
        var result = TextGenerator.GenerateRandomPassword(16, includeSpecial: true);
        Assert.Equal(16, result.Length);
        Assert.Contains(result, c => "!@#$%^&*()-_=+[]{}|;:'\",.<>?/`~".Contains(c));
    }

    [Fact]
    public void GenerateRandomPassword_ReturnsCorrectLength_AndNoSpecialIfNotRequested()
    {
        var result = TextGenerator.GenerateRandomPassword(16, includeSpecial: false);
        Assert.Equal(16, result.Length);
        Assert.All(result, c => Assert.True(char.IsLetterOrDigit(c)));
    }

    [Fact]
    public void Reverse_ReturnsReversedString()
    {
        Assert.Equal("cba", TextGenerator.Reverse("abc"));
        Assert.Equal("", TextGenerator.Reverse(""));
        Assert.Null(TextGenerator.Reverse(null!));
    }

    [Fact]
    public void Slugify_ReturnsUrlFriendlySlug()
    {
        Assert.Equal("hello-world", TextGenerator.Slugify("Hello World!"));
        Assert.Equal("", TextGenerator.Slugify(""));
        Assert.Equal("", TextGenerator.Slugify("   "));
    }

    [Fact]
    public void ToTitleCase_ReturnsTitleCasedString()
    {
        Assert.Equal("Hello World", TextGenerator.ToTitleCase("hello world"));
        Assert.Equal("", TextGenerator.ToTitleCase(""));
        Assert.Equal("", TextGenerator.ToTitleCase("   "));
    }

    [Fact]
    public void GenerateLoremIpsum_ReturnsCorrectWordCount()
    {
        var result = TextGenerator.GenerateLoremIpsum(5);
        Assert.Equal(5, result.Split(' ').Length);
        Assert.Equal("", TextGenerator.GenerateLoremIpsum(0));
        Assert.Equal("", TextGenerator.GenerateLoremIpsum(-1));
    }

    [Fact]
    public void GenerateRandomSentence_ReturnsSentenceWithPeriod()
    {
        var sentence = TextGenerator.GenerateRandomSentence();
        Assert.EndsWith(".", sentence);
        Assert.True(sentence.Length > 0);
    }

    [Fact]
    public void GenerateRandomParagraph_ReturnsCorrectSentenceCount()
    {
        var paragraph = TextGenerator.GenerateRandomParagraph();
        var sentences = paragraph.Split('.').Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
        Assert.Equal(3, sentences.Length);
        Assert.Equal("", TextGenerator.GenerateRandomParagraph(0));
        Assert.Equal("", TextGenerator.GenerateRandomParagraph(-1));
    }

    [Fact]
    public void GenerateRandomEmail_ReturnsValidEmailFormat()
    {
        var email = TextGenerator.GenerateRandomEmail();
        Assert.Matches(@"^[a-z0-9]+@[a-z0-9]+\.com$", email);
    }

    [Fact]
    public void GenerateRandomPhoneNumber_ReturnsTenDigitsOrWithCountryCode()
    {
        var phone = TextGenerator.GenerateRandomPhoneNumber();
        Assert.Matches(@"^\d{10}$", phone);

        var phoneWithCode = TextGenerator.GenerateRandomPhoneNumber("34");
        Assert.Matches(@"^\+34\d{10}$", phoneWithCode);
    }

    [Fact]
    public void WrapText_WrapsTextCorrectly()
    {
        var input = "This is a test of the text wrapping function.";
        var lines = TextGenerator.WrapText(input, 10).ToArray();
        Assert.All(lines, line => Assert.True(line.Length <= 10));
        Assert.Empty(TextGenerator.WrapText("", 10));
        Assert.Empty(TextGenerator.WrapText("abc", 0));
    }
}