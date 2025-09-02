using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Stryng.Extensions.Enums;

public static class EnumExtensions
{
    public static TEnum ToEnum<TEnum>(this string value, bool ignoreCase = true)
        where TEnum : struct, Enum
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Value cannot be null or empty.", nameof(value));

        return (TEnum)Enum.Parse(typeof(TEnum), value, ignoreCase);
    }

    public static bool TryToEnum<TEnum>(this string value, out TEnum result, bool ignoreCase = true)
        where TEnum : struct, Enum
    {
        return Enum.TryParse(value, ignoreCase, out result);
    }

    public static TEnum ToEnumOrDefault<TEnum>(this string value, TEnum defaultValue, bool ignoreCase = true)
        where TEnum : struct, Enum
    {
        return Enum.TryParse(value, ignoreCase, out TEnum result)
            ? result
            : defaultValue;
    }

    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        if (field == null) return value.ToString();

        var attribute = field.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? value.ToString();
    }

    public static string GetDisplayName(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        if (field == null) return value.ToString();

        var attribute = field.GetCustomAttribute<DisplayAttribute>();
        return attribute?.Name ?? value.GetDescription();
    }

    public static TAttribute? GetAttribute<TAttribute>(this Enum value)
        where TAttribute : Attribute
    {
        var field = value.GetType().GetField(value.ToString());
        return field?.GetCustomAttribute<TAttribute>();
    }

    public static IEnumerable<TEnum> GetValues<TEnum>() where TEnum : struct, Enum
        => Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

    public static IEnumerable<string> GetNames<TEnum>() where TEnum : struct, Enum
        => Enum.GetNames(typeof(TEnum));

    public static Dictionary<TEnum, string> ToDictionary<TEnum>() where TEnum : struct, Enum
    {
        return Enum.GetValues(typeof(TEnum))
            .Cast<TEnum>()
            .ToDictionary(
                e => e,
                e => e.GetDescription()
            );
    }

    public static bool IsDefined<TEnum>(this TEnum value) where TEnum : struct, Enum
        => Enum.IsDefined(typeof(TEnum), value);

    public static bool HasFlagFast<TEnum>(this TEnum value, TEnum flag) where TEnum : struct, Enum
    {
        var valueAsLong = Convert.ToInt64(value);
        var flagAsLong = Convert.ToInt64(flag);
        return (valueAsLong & flagAsLong) == flagAsLong;
    }

    public static TEnum AddFlag<TEnum>(this TEnum value, TEnum flag) where TEnum : struct, Enum
    {
        var valueAsLong = Convert.ToInt64(value);
        var flagAsLong = Convert.ToInt64(flag);
        return (TEnum)Enum.ToObject(typeof(TEnum), valueAsLong | flagAsLong);
    }

    public static TEnum RemoveFlag<TEnum>(this TEnum value, TEnum flag) where TEnum : struct, Enum
    {
        var valueAsLong = Convert.ToInt64(value);
        var flagAsLong = Convert.ToInt64(flag);
        return (TEnum)Enum.ToObject(typeof(TEnum), valueAsLong & ~flagAsLong);
    }

    public static TEnum ToggleFlag<TEnum>(this TEnum value, TEnum flag) where TEnum : struct, Enum
    {
        var valueAsLong = Convert.ToInt64(value);
        var flagAsLong = Convert.ToInt64(flag);
        return (TEnum)Enum.ToObject(typeof(TEnum), valueAsLong ^ flagAsLong);
    }
}