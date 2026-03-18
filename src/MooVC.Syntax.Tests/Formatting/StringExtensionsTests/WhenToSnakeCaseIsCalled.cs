namespace MooVC.Syntax.Formatting.StringExtensionsTests;

using System.Globalization;

public sealed class WhenToSnakeCaseIsCalled
{
    private static readonly Faker generator = new();

    [Test]
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

    [Test]
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

    [Test]
    [Arguments(" ")]
    [Arguments("\t")]
    [Arguments("\r\n")]
    [Arguments("   ")]
    public void GivenValueContainsOnlyWhitespaceThenArgumentExceptionIsThrown(string value)
    {
        // Arrange & Act
        Action action = () => value.ToSnakeCase();

        // Assert
        ArgumentException exception = Should.Throw<ArgumentException>(action);
        exception.ParamName.ShouldBe(nameof(value));
    }

    [Test]
    [Arguments("already_snake_case", "already_snake_case")]
    [Arguments("simple", "simple")]
    [Arguments("Single", "single")]
    [Arguments("PascalCase", "pascal_case")]
    [Arguments("camelCaseValue", "camel_case_value")]
    [Arguments("Hello World", "hello_world")]
    [Arguments("Hello-World", "hello_world")]
    [Arguments("Hello__World", "hello_world")]
    [Arguments("_Hello", "hello")]
    [Arguments("-Hello", "hello")]
    [Arguments(" Hello ", "hello")]
    [Arguments("Section2Update", "section2_update")]
    [Arguments("ÉclairDeluxe", "éclair_deluxe")]
    [Arguments("ΣigmaValue", "σigma_value")]
    public void GivenValuesThenExpectedSnakeCaseIsReturned(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToSnakeCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    [Arguments("A", "a")]
    [Arguments("ABC", "abc")]
    [Arguments("XMLHttpRequest", "xml_http_request")]
    public void GivenAcronymsAndTransitionsThenBoundariesAreHandled(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToSnakeCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    public void GivenMultipleSeparatorsThenSeparatorsAreCollapsed()
    {
        // Arrange
        string value = "alpha  beta---gamma___delta";

        // Act
        string result = value.ToSnakeCase();

        // Assert
        result.ShouldBe("alpha_beta_gamma_delta");
    }

    [Test]
    public void GivenMixedWhitespaceAndSeparatorsThenLeadingAndTrailingAreRemoved()
    {
        // Arrange
        string value = "  _Alpha__Beta- ";

        // Act
        string result = value.ToSnakeCase();

        // Assert
        result.ShouldBe("alpha_beta");
    }

    [Test]
    public void GivenDigitBeforeUppercaseThenSeparatorIsInserted()
    {
        // Arrange
        string value = "Part3Revision";

        // Act
        string result = value.ToSnakeCase();

        // Assert
        result.ShouldBe("part3_revision");
    }

    [Test]
    [Arguments("__", "")]
    [Arguments("---", "")]
    [Arguments("___---___", "")]
    public void GivenOnlySeparatorsThenResultIsEmpty(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToSnakeCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    [Arguments("123", "123")]
    [Arguments("9lives", "9lives")]
    [Arguments("Version2Alpha3", "version2_alpha3")]
    public void GivenNumericScenariosThenDigitsArePreserved(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToSnakeCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
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

    [Test]
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

    [Test]
    public void GivenVeryLongValueThenProcessorHandlesLengthAndProducesExpectedResult()
    {
        // Arrange
        string value = new('A', 16_384);

        // Act
        string result = value.ToSnakeCase();

        // Assert
        result.ShouldBe(new string('a', 16_384));
    }
}