namespace MooVC.Syntax.CSharp.StringExtensionsTests;

using System.Globalization;

public sealed class WhenToCamelCaseIsCalled
{
    private static readonly Faker generator = new();

    [Fact]
    public void GivenValueIsNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        string? value = default;

        // Act
        Action action = () => value!.ToCamelCase();

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(action);
        exception.ParamName.ShouldBe(nameof(value));
    }

    [Fact]
    public void GivenValueIsEmptyThenArgumentExceptionIsThrown()
    {
        // Arrange
        string value = string.Empty;

        // Act
        Action action = () => value.ToCamelCase();

        // Assert
        ArgumentException exception = Should.Throw<ArgumentException>(action);
        exception.ParamName.ShouldBe(nameof(value));
    }

    [Theory]
    [InlineData(" ")]
    [InlineData("   ")]
    [InlineData("\t")]
    [InlineData("\r\n")]
    public void GivenValueContainsOnlyWhitespaceThenArgumentExceptionIsThrown(string value)
    {
        // Arrange & Act
        Action action = () => value.ToCamelCase();

        // Assert
        ArgumentException exception = Should.Throw<ArgumentException>(action);
        exception.ParamName.ShouldBe(nameof(value));
    }

    [Theory]
    [InlineData("A", "a")]
    [InlineData("a", "a")]
    [InlineData("FooBar", "fooBar")]
    [InlineData("fooBar", "fooBar")]
    [InlineData("UpperCaseValue", "upperCaseValue")]
    [InlineData("Éclair", "éclair")]
    [InlineData("Σigma", "σigma")]
    public void GivenValidValuesThenFirstCharacterIsLowercased(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToCamelCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Theory]
    [InlineData("1Example")]
    [InlineData("_Example")]
    [InlineData("-Example")]
    [InlineData("😀Example")]
    public void GivenValueStartsWithNonLetterThenOriginalIsReturned(string value)
    {
        // Arrange & Act
        string result = value.ToCamelCase();

        // Assert
        result.ShouldBe(value);
    }

    [Fact]
    public void GivenTurkishCultureIsActiveThenInvariantLowercasingIsUsed()
    {
        // Arrange
        CultureInfo current = CultureInfo.CurrentCulture;
        string value = "Istanbul";

        // Act
        string result;

        try
        {
            CultureInfo.CurrentCulture = new CultureInfo("tr-TR");
            result = value.ToCamelCase();
        }
        finally
        {
            CultureInfo.CurrentCulture = current;
        }

        // Assert
        result.ShouldBe("istanbul");
    }

    [Fact]
    public void GivenWordsWhenInvokedTwiceThenResultIsIdempotent()
    {
        // Arrange
        const int WordCount = 10;
        const int FirstCharacterIndex = 0;
        const int RemainingCharactersOffset = 1;

        static string CapitalizeFirstLetter(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return word;
            }

            if (word.Length <= RemainingCharactersOffset)
            {
                return word.ToUpper(CultureInfo.InvariantCulture);
            }

            char first = char.ToUpper(word[FirstCharacterIndex], CultureInfo.InvariantCulture);
            string remaining = word[RemainingCharactersOffset..];

            return string.Concat(first, remaining);
        }

        string[] words = Enumerable
            .Range(0, WordCount)
            .Select(_ => generator.Lorem.Word())
            .Select(CapitalizeFirstLetter)
            .ToArray();

        // Act & Assert
        foreach (string word in words)
        {
            string first = word.ToCamelCase();
            string second = first.ToCamelCase();

            // Assert
            second.ShouldBe(first);
        }
    }

    [Fact]
    public void GivenValueWithInternalWhitespaceThenOnlyFirstCharacterIsChanged()
    {
        // Arrange
        string value = "Hello World";

        // Act
        string result = value.ToCamelCase();

        // Assert
        result.ShouldBe("hello World");
    }
}