using Stryng.Extensions.Validation;

namespace Stryng.Extensions.Tests.Validation;

public class StructuredDataValidatorsTests
{
    [Fact]
    public void IsJson_ReturnsTrue_ForValidJson()
    {
        const string validJson = "{\"name\":\"John\",\"age\":30}";
        Assert.True(StructuredDataValidators.IsJson(validJson));
    }

    [Fact]
    public void IsJson_ReturnsFalse_ForInvalidJson()
    {
        const string invalidJson = "{name:John,age:30}";
        Assert.False(StructuredDataValidators.IsJson(invalidJson));
    }

    [Fact]
    public void IsJson_ReturnsFalse_ForNullOrWhitespace()
    {
        Assert.False(StructuredDataValidators.IsJson(null));
        Assert.False(StructuredDataValidators.IsJson(""));
        Assert.False(StructuredDataValidators.IsJson("   "));
    }

    [Fact]
    public void IsXml_ReturnsTrue_ForValidXml()
    {
        const string validXml = "<person><name>John</name><age>30</age></person>";
        Assert.True(StructuredDataValidators.IsXml(validXml));
    }

    [Fact]
    public void IsXml_ReturnsFalse_ForInvalidXml()
    {
        const string invalidXml = "<person><name>John<name><age>30</age></person>";
        Assert.False(StructuredDataValidators.IsXml(invalidXml));
    }

    [Fact]
    public void IsXml_ReturnsFalse_ForNullOrWhitespace()
    {
        Assert.False(StructuredDataValidators.IsXml(null));
        Assert.False(StructuredDataValidators.IsXml(""));
        Assert.False(StructuredDataValidators.IsXml("   "));
    }
}