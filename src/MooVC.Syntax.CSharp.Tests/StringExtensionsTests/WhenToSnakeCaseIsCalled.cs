namespace MooVC.Syntax.CSharp.StringExtensionsTests;

using System.Globalization;

public sealed class WhenToSnakeCaseIsCalled
{
    private static readonly Faker generator = new();

    [Fact]
    public void GivenValueIsNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        string? value = default;

        // Act
        Action action = () => value!.ToSnakeCase();

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
        Action action = () => value.ToSnakeCase();

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
        Action action = () => value.ToSnakeCase();

        // Assert
        ArgumentException exception = Should.Throw<ArgumentException>(action);
        exception.ParamName.ShouldBe(nameof(value));
    }

    [Theory]
    [InlineData("already_snake_case", "already_snake_case")]
    [InlineData("simple", "simple")]
    [InlineData("Single", "single")]
    [InlineData("PascalCase", "pascal_case")]
    [InlineData("camelCaseValue", "camel_case_value")]
    [InlineData("Hello World", "hello_world")]
    [InlineData("Hello-World", "hello_world")]
    [InlineData("Hello__World", "hello_world")]
    [InlineData("_Hello", "hello")]
    [InlineData("-Hello", "hello")]
    [InlineData(" Hello ", "hello")]
    [InlineData("Section2Update", "section2_update")]
    [InlineData("ÉclairDeluxe", "éclair_deluxe")]
    [InlineData("ΣigmaValue", "σigma_value")]
    public void GivenValuesThenExpectedSnakeCaseIsReturned(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToSnakeCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Theory]
    [InlineData("A", "a")]
    [InlineData("ABC", "abc")]
    [InlineData("XMLHttpRequest", "xml_http_request")]
    public void GivenAcronymsAndTransitionsThenBoundariesAreHandled(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToSnakeCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void GivenMultipleSeparatorsThenSeparatorsAreCollapsed()
    {
        // Arrange
        string value = "alpha  beta---gamma___delta";

        // Act
        string result = value.ToSnakeCase();

        // Assert
        result.ShouldBe("alpha_beta_gamma_delta");
    }

    [Fact]
    public void GivenMixedWhitespaceAndSeparatorsThenLeadingAndTrailingAreRemoved()
    {
        // Arrange
        string value = "  _Alpha__Beta- ";

        // Act
        string result = value.ToSnakeCase();

        // Assert
        result.ShouldBe("alpha_beta");
    }

    [Fact]
    public void GivenDigitBeforeUppercaseThenSeparatorIsInserted()
    {
        // Arrange
        string value = "Part3Revision";

        // Act
        string result = value.ToSnakeCase();

        // Assert
        result.ShouldBe("part3_revision");
    }

    [Theory]
    [InlineData("__", "")]
    [InlineData("---", "")]
    [InlineData("___---___", "")]
    public void GivenOnlySeparatorsThenResultIsEmpty(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToSnakeCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Theory]
    [InlineData("123", "123")]
    [InlineData("9lives", "9lives")]
    [InlineData("Version2Alpha3", "version2_alpha3")]
    public void GivenNumericScenariosThenDigitsArePreserved(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToSnakeCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void GivenUnicodeUppercaseThenLowercaseIsInvariant()
    {
        // Arrange
        CultureInfo originalCulture = CultureInfo.CurrentCulture;
        string value = "IstanbulCity";

        // Act
        string result;

        try
        {
            CultureInfo.CurrentCulture = new CultureInfo("tr-TR");
            result = value.ToSnakeCase();
        }
        finally
        {
            CultureInfo.CurrentCulture = originalCulture;
        }

        // Assert
        result.ShouldBe("istanbul_city");
    }

    [Fact]
    public void GivenWordsTwiceThenResultIsIdempotent()
    {
        // Arrange
        const int wordCount = 10;
        const int firstCharacterIndex = 0;
        const int remainingCharactersOffset = 1;

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
            .Range(0, wordCount)
            .Select(_ => generator.Lorem.Word())
            .Select(word => ToPascalCase(word, firstCharacterIndex, remainingCharactersOffset))
            .ToArray();

        // Act & Assert
        foreach (string word in words)
        {
            string firstResult = word.ToSnakeCase();
            string secondResult = firstResult.ToSnakeCase();
            secondResult.ShouldBe(firstResult);
        }
    }

    [Fact]
    public void GivenVeryLongValueThenProcessorHandlesLengthAndProducesExpectedResult()
    {
        // Arrange
        string value = new string('A', 16_384);

        // Act
        string result = value.ToSnakeCase();

        // Assert
        result.ShouldBe(new string('a', 16_384));
    }
}