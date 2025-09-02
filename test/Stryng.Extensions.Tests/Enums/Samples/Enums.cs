using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stryng.Extensions.Tests.Enums.Samples;

[Flags]
public enum FlagEnum
{
    None = 0,
    A = 1,
    B = 2,
    C = 4
}

public enum SampleEnum
{
    [Description("First Value")]
    [Display(Name = "First")]
    First = 1,

    [Description("Second Value")]
    [Display(Name = "Second")]
    Second = 2,

    Third = 4
}