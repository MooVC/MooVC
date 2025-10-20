namespace MooVC.Syntax.CSharp.StringExtensionsTests;

using System.Globalization;

public sealed class WhenToKebabCaseIsCalled
{
    private static readonly Faker generator = new();

    [Fact]
    public void GivenValueIsNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        string? value = default;

        // Act
        Action action = () => value!.ToKebabCase();

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
        Action action = () => value.ToKebabCase();

        // Assert
        ArgumentException exception = Should.Throw<ArgumentException>(action);
        exception.ParamName.ShouldBe(nameof(value));
    }

    [Theory]
    [InlineData(" ")]
    [InlineData("\t")]
    [InlineData("\r\n")]
    [InlineData("   ")]
    public void GivenValueContainsOnlyWhitespaceThenArgumentExceptionIsThrown(string value)
    {
        // Arrange
        // Act
        Action action = () => value.ToKebabCase();

        // Assert
        ArgumentException exception = Should.Throw<ArgumentException>(action);
        exception.ParamName.ShouldBe(nameof(value));
    }

    [Theory]
    [InlineData("already-kebab-case", "already-kebab-case")]
    [InlineData("already_snake_case", "already-snake-case")]
    [InlineData("simple", "simple")]
    [InlineData("Single", "single")]
    [InlineData("PascalCase", "pascal-case")]
    [InlineData("camelCaseValue", "camel-case-value")]
    [InlineData("Hello World", "hello-world")]
    [InlineData("Hello-World", "hello-world")]
    [InlineData("Hello__World", "hello-world")]
    [InlineData("_Hello", "hello")]
    [InlineData("-Hello", "hello")]
    [InlineData(" Hello ", "hello")]
    [InlineData("Section2Update", "section2-update")]
    [InlineData("ÉclairDeluxe", "éclair-deluxe")]
    [InlineData("ΣigmaValue", "σigma-value")]
    public void GivenValuesThenExpectedKebabCaseIsReturned(string value, string expected)
    {
        // Arrange
        // Act
        string result = value.ToKebabCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void GivenMultipleSeparatorsThenSeparatorsAreCollapsed()
    {
        // Arrange
        string value = "alpha  beta---gamma___delta";

        // Act
        string result = value.ToKebabCase();

        // Assert
        result.ShouldBe("alpha-beta-gamma-delta");
    }

    [Fact]
    public void GivenMixedWhitespaceAndSeparatorsThenLeadingAndTrailingAreRemoved()
    {
        // Arrange
        string value = "  _Alpha__Beta- ";

        // Act
        string result = value.ToKebabCase();

        // Assert
        result.ShouldBe("alpha-beta");
    }

    [Fact]
    public void GivenDigitBeforeUppercaseThenSeparatorIsInserted()
    {
        // Arrange
        string value = "Part3Revision";

        // Act
        string result = value.ToKebabCase();

        // Assert
        result.ShouldBe("part3-revision");
    }

    [Fact]
    public void GivenInternationalUppercaseThenLowercaseIsInvariant()
    {
        // Arrange
        CultureInfo previous = CultureInfo.CurrentCulture;
        string value = "IstanbulCity";

        // Act
        string result;

        try
        {
            CultureInfo.CurrentCulture = new CultureInfo("tr-TR");
            result = value.ToKebabCase();
        }
        finally
        {
            CultureInfo.CurrentCulture = previous;
        }

        // Assert
        result.ShouldBe("istanbul-city");
    }

    [Fact]
    public void GivenWordsTwiceThenResultIsIdempotent()
    {
        // Arrange
        const int wordCount = 10;
        const int firstCharacterIndex = 0;
        const int remainingCharactersOffset = 1;

        static string ToPascal(string word, int firstIndex, int remainingOffset)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return word;
            }

            if (word.Length <= remainingOffset)
            {
                return word.ToUpper(CultureInfo.InvariantCulture);
            }

            char first = char.ToUpper(word[firstIndex], CultureInfo.InvariantCulture);
            string remaining = word[remainingOffset..];

            return string.Concat(first, remaining);
        }

        string[] words = Enumerable
            .Range(0, wordCount)
            .Select(_ => generator.Lorem.Word())
            .Select(w => ToPascal(w, firstCharacterIndex, remainingCharactersOffset))
            .ToArray();

        // Act & Assert
        foreach (string word in words)
        {
            string once = word.ToKebabCase();
            string twice = once.ToKebabCase();

            // Assert
            twice.ShouldBe(once);
        }
    }
}