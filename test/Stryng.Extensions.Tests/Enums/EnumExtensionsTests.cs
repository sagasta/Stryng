using Stryng.Extensions.Enums;
using Stryng.Extensions.Tests.Enums.Samples;
using System.ComponentModel;

namespace Stryng.Extensions.Tests.Enums;

public class EnumExtensionsTests
{
    [Fact]
    public void ToEnum_ValidString_ReturnsEnum()
    {
        var result = "First".ToEnum<SampleEnum>();
        Assert.Equal(SampleEnum.First, result);
    }

    [Fact]
    public void ToEnum_InvalidString_Throws()
    {
        Assert.Throws<ArgumentException>(() => "".ToEnum<SampleEnum>());
        Assert.Throws<ArgumentException>(() => ((string)null!).ToEnum<SampleEnum>());
        Assert.Throws<ArgumentException>(() => "Invalid".ToEnum<SampleEnum>());
    }

    [Fact]
    public void TryToEnum_ValidString_ReturnsTrue()
    {
        var success = "Second".TryToEnum<SampleEnum>(out var result);
        Assert.True(success);
        Assert.Equal(SampleEnum.Second, result);
    }

    [Fact]
    public void TryToEnum_InvalidString_ReturnsFalse()
    {
        var success = "Invalid".TryToEnum<SampleEnum>(out _);
        Assert.False(success);
    }

    [Fact]
    public void ToEnumOrDefault_ValidString_ReturnsEnum()
    {
        var result = "Third".ToEnumOrDefault(SampleEnum.First);
        Assert.Equal(SampleEnum.Third, result);
    }

    [Fact]
    public void ToEnumOrDefault_InvalidString_ReturnsDefault()
    {
        var result = "Invalid".ToEnumOrDefault(SampleEnum.Second);
        Assert.Equal(SampleEnum.Second, result);
    }

    [Fact]
    public void GetDescription_ReturnsDescriptionOrName()
    {
        Assert.Equal("First Value", SampleEnum.First.GetDescription());
        Assert.Equal("Second Value", SampleEnum.Second.GetDescription());
        Assert.Equal("Third", SampleEnum.Third.GetDescription());
    }

    [Fact]
    public void GetDisplayName_ReturnsDisplayNameOrDescription()
    {
        Assert.Equal("First", SampleEnum.First.GetDisplayName());
        Assert.Equal("Second", SampleEnum.Second.GetDisplayName());
        Assert.Equal("Third", SampleEnum.Third.GetDisplayName());
    }

    [Fact]
    public void GetAttribute_ReturnsAttributeOrNull()
    {
        var desc = SampleEnum.First.GetAttribute<DescriptionAttribute>();
        Assert.NotNull(desc);
        Assert.Equal("First Value", desc.Description);

        var noAttr = SampleEnum.Third.GetAttribute<DescriptionAttribute>();
        Assert.Null(noAttr);
    }

    [Fact]
    public void GetValues_ReturnsAllEnumValues()
    {
        var values = EnumExtensions.GetValues<SampleEnum>().ToArray();
        Assert.Contains(SampleEnum.First, values);
        Assert.Contains(SampleEnum.Second, values);
        Assert.Contains(SampleEnum.Third, values);
    }

    [Fact]
    public void GetNames_ReturnsAllEnumNames()
    {
        var names = EnumExtensions.GetNames<SampleEnum>().ToArray();
        Assert.Contains("First", names);
        Assert.Contains("Second", names);
        Assert.Contains("Third", names);
    }

    [Fact]
    public void ToDictionary_ReturnsEnumDescriptionDictionary()
    {
        var dict = EnumExtensions.ToDictionary<SampleEnum>();
        Assert.Equal("First Value", dict[SampleEnum.First]);
        Assert.Equal("Second Value", dict[SampleEnum.Second]);
        Assert.Equal("Third", dict[SampleEnum.Third]);
    }

    [Fact]
    public void IsDefined_ReturnsTrueForDefinedValue()
    {
        Assert.True(SampleEnum.First.IsDefined());
        Assert.False(((SampleEnum)99).IsDefined());
    }

    [Fact]
    public void HasFlagFast_WorksForFlags()
    {
        var value = FlagEnum.A | FlagEnum.B;
        Assert.True(value.HasFlagFast(FlagEnum.A));
        Assert.True(value.HasFlagFast(FlagEnum.B));
        Assert.False(value.HasFlagFast(FlagEnum.C));
    }

    [Fact]
    public void AddFlag_AddsFlag()
    {
        var value = FlagEnum.A;
        var result = value.AddFlag(FlagEnum.B);
        Assert.True(result.HasFlagFast(FlagEnum.A));
        Assert.True(result.HasFlagFast(FlagEnum.B));
    }

    [Fact]
    public void RemoveFlag_RemovesFlag()
    {
        var value = FlagEnum.A | FlagEnum.B;
        var result = value.RemoveFlag(FlagEnum.A);
        Assert.False(result.HasFlagFast(FlagEnum.A));
        Assert.True(result.HasFlagFast(FlagEnum.B));
    }

    [Fact]
    public void ToggleFlag_TogglesFlag()
    {
        var value = FlagEnum.A;
        var result = value.ToggleFlag(FlagEnum.A);
        Assert.False(result.HasFlagFast(FlagEnum.A));
        result = result.ToggleFlag(FlagEnum.A);
        Assert.True(result.HasFlagFast(FlagEnum.A));
    }
}