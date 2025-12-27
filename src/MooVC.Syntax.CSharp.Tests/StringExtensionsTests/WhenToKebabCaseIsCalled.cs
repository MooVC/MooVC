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
        // Arrange & Act
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
        // Arrange & Act
        string result = value.ToKebabCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Theory]
    [InlineData("A", "a")]
    [InlineData("ABC", "abc")]
    [InlineData("XMLHttpRequest", "xml-http-request")]
    public void GivenAcronymsAndTransitionsThenBoundariesAreHandled(string value, string expected)
    {
        // Arrange & Act
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

    [Theory]
    [InlineData("__", "")]
    [InlineData("---", "")]
    [InlineData("___---___", "")]
    public void GivenOnlySeparatorsThenResultIsEmpty(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToKebabCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Theory]
    [InlineData("123", "123")]
    [InlineData("9lives", "9lives")]
    [InlineData("Version2Alpha3", "version2-alpha3")]
    public void GivenNumericScenariosThenDigitsArePreserved(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToKebabCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void GivenInternationalUppercaseThenLowercaseIsInvariant()
    {
        // Arrange
        CultureInfo originalCulture = CultureInfo.CurrentCulture;
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
            CultureInfo.CurrentCulture = originalCulture;
        }

        // Assert
        result.ShouldBe("istanbul-city");
    }

    [Fact]
    public void GivenWordsTwiceThenResultIsIdempotent()
    {
        // Arrange
        const int WordCount = 10;
        const int FirstCharacterIndex = 0;
        const int RemainingCharactersOffset = 1;

        static string ToPascalCase(string word, int firstIndex, int remainingOffset)
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
            .Range(0, WordCount)
            .Select(_ => generator.Lorem.Word())
            .Select(word => ToPascalCase(word, FirstCharacterIndex, RemainingCharactersOffset))
            .ToArray();

        // Act & Assert
        foreach (string word in words)
        {
            string firstResult = word.ToKebabCase();
            string secondResult = firstResult.ToKebabCase();
            secondResult.ShouldBe(firstResult);
        }
    }

    [Fact]
    public void GivenVeryLongValueThenProcessorHandlesLengthAndProducesExpectedResult()
    {
        // Arrange
        string value = new('A', 16_384);

        // Act
        string result = value.ToKebabCase();

        // Assert
        result.ShouldBe(new string('a', 16_384));
    }
}