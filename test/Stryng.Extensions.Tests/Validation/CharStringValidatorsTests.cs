using Stryng.Extensions.Validation;

namespace Stryng.Extensions.Tests.Validation
{
    public class CharStringValidatorsTests
    {
        [Fact]
        public void IsAlpha_ReturnsTrue_ForLettersOnly()
        {
            Assert.True(CharStringValidators.IsAlpha("abcXYZ"));
            Assert.False(CharStringValidators.IsAlpha("abc123"));
            Assert.False(CharStringValidators.IsAlpha(""));
            Assert.False(CharStringValidators.IsAlpha(null));
        }

        [Fact]
        public void IsUpperAlpha_ReturnsTrue_ForUppercaseLettersOnly()
        {
            Assert.True(CharStringValidators.IsUpperAlpha("ABC"));
            Assert.False(CharStringValidators.IsUpperAlpha("AbC"));
            Assert.False(CharStringValidators.IsUpperAlpha("123"));
        }

        [Fact]
        public void IsLowerAlpha_ReturnsTrue_ForLowercaseLettersOnly()
        {
            Assert.True(CharStringValidators.IsLowerAlpha("abc"));
            Assert.False(CharStringValidators.IsLowerAlpha("aBc"));
            Assert.False(CharStringValidators.IsLowerAlpha("123"));
        }

        [Fact]
        public void IsLowerCase_ReturnsTrue_IfAllLettersAreLower()
        {
            Assert.True(CharStringValidators.IsLowerCase("abc123"));
            Assert.False(CharStringValidators.IsLowerCase("Abc123"));
        }

        [Fact]
        public void IsUpperCase_ReturnsTrue_IfAllLettersAreUpper()
        {
            Assert.True(CharStringValidators.IsUpperCase("ABC123"));
            Assert.False(CharStringValidators.IsUpperCase("AbC123"));
        }

        [Fact]
        public void IsNumeric_ReturnsTrue_ForDigitsOnly()
        {
            Assert.True(CharStringValidators.IsNumeric("123456"));
            Assert.False(CharStringValidators.IsNumeric("123a"));
        }

        [Fact]
        public void IsBinary_ReturnsTrue_ForBinaryDigitsOnly()
        {
            Assert.True(CharStringValidators.IsBinary("10101"));
            Assert.False(CharStringValidators.IsBinary("10201"));
        }

        [Fact]
        public void IsHexadecimal_ReturnsTrue_ForHexCharsOnly()
        {
            Assert.True(CharStringValidators.IsHexadecimal("1A2b3C"));
            Assert.False(CharStringValidators.IsHexadecimal("1A2b3G"));
        }

        [Fact]
        public void IsAlphaNumeric_ReturnsTrue_ForLettersAndDigitsOnly()
        {
            Assert.True(CharStringValidators.IsAlphaNumeric("abc123"));
            Assert.False(CharStringValidators.IsAlphaNumeric("abc123!"));
        }

        [Fact]
        public void HasDigits_ReturnsTrue_IfContainsDigits()
        {
            Assert.True(CharStringValidators.HasDigits("abc123"));
            Assert.False(CharStringValidators.HasDigits("abc"));
        }

        [Fact]
        public void HasLetters_ReturnsTrue_IfContainsLetters()
        {
            Assert.True(CharStringValidators.HasLetters("123abc"));
            Assert.False(CharStringValidators.HasLetters("123"));
        }

        [Fact]
        public void HasSpecialChars_ReturnsTrue_IfContainsSpecialChars()
        {
            Assert.True(CharStringValidators.HasSpecialChars("abc!"));
            Assert.False(CharStringValidators.HasSpecialChars("abc"));
            Assert.True(CharStringValidators.HasSpecialChars("abc$", '$'));
        }

        [Fact]
        public void ContainsOnly_ReturnsTrue_IfContainsOnlySpecifiedChars()
        {
            Assert.True(CharStringValidators.ContainsOnly("aaa", 'a'));
            Assert.False(CharStringValidators.ContainsOnly("aab", 'a'));
        }

        [Fact]
        public void ContainsNone_ReturnsTrue_IfContainsNoneSpecifiedChars()
        {
            Assert.True(CharStringValidators.ContainsNone("abc", 'x', 'y', 'z'));
            Assert.False(CharStringValidators.ContainsNone("abcx", 'x'));
        }
    }
}