namespace MooVC.Syntax.Formatting.StringExtensionsTests;

using System.Globalization;

public sealed class WhenToSnakeCaseIsCalled
{
    private static readonly Faker _generator = new();

    [Test]
    [Arguments("A", "a")]
    [Arguments("ABC", "abc")]
    [Arguments("XMLHttpRequest", "xml_http_request")]
    public async Task GivenAcronymsAndTransitionsThenBoundariesAreHandled(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToSnakeCase();

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenDigitBeforeUppercaseThenSeparatorIsInserted()
    {
        // Arrange
        string value = "Part3Revision";

        // Act
        string result = value.ToSnakeCase();

        // Assert
        _ = await Assert.That(result).IsEqualTo("part3_revision");
    }

    [Test]
    public async Task GivenMixedWhitespaceAndSeparatorsThenLeadingAndTrailingAreRemoved()
    {
        // Arrange
        string value = "  _Alpha__Beta- ";

        // Act
        string result = value.ToSnakeCase();

        // Assert
        _ = await Assert.That(result).IsEqualTo("alpha_beta");
    }

    [Test]
    public async Task GivenMultipleSeparatorsThenSeparatorsAreCollapsed()
    {
        // Arrange
        string value = "alpha  beta---gamma___delta";

        // Act
        string result = value.ToSnakeCase();

        // Assert
        _ = await Assert.That(result).IsEqualTo("alpha_beta_gamma_delta");
    }

    [Test]
    [Arguments("123", "123")]
    [Arguments("9lives", "9lives")]
    [Arguments("Version2Alpha3", "version2_alpha3")]
    public async Task GivenNumericScenariosThenDigitsArePreserved(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToSnakeCase();

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    [Arguments("__", "")]
    [Arguments("---", "")]
    [Arguments("___---___", "")]
    public async Task GivenOnlySeparatorsThenResultIsEmpty(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToSnakeCase();

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenUnicodeUppercaseThenLowercaseIsInvariant()
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
        _ = await Assert.That(result).IsEqualTo("istanbul_city");
    }

    [Test]
    [Arguments(" ")]
    [Arguments("\t")]
    [Arguments("\r\n")]
    [Arguments("   ")]
    public async Task GivenValueContainsOnlyWhitespaceThenArgumentExceptionIsThrown(string value)
    {
        // Arrange & Act
        Action act = () => value.ToSnakeCase();

        // Assert
        ArgumentException exception = await Assert.That(act).Throws<ArgumentException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(value));
    }

    [Test]
    public async Task GivenValueIsEmptyThenArgumentExceptionIsThrown()
    {
        // Arrange
        string value = string.Empty;

        // Act
        Action act = () => value.ToSnakeCase();

        // Assert
        ArgumentException exception = await Assert.That(act).Throws<ArgumentException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(value));
    }

    [Test]
    public async Task GivenValueIsNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        string? value = default;

        // Act
        Action act = () => value!.ToSnakeCase();

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(value));
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
    public async Task GivenValuesThenExpectedSnakeCaseIsReturned(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToSnakeCase();

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenVeryLongValueThenProcessorHandlesLengthAndProducesExpectedResult()
    {
        // Arrange
        string value = new('A', 16_384);

        // Act
        string result = value.ToSnakeCase();

        // Assert
        _ = await Assert.That(result).IsEqualTo(new string('a', 16_384));
    }

    [Test]
    public async Task GivenWordsTwiceThenResultIsIdempotent()
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

        string[] words = [.. Enumerable
            .Range(0, wordCount)
            .Select(_ => _generator.Lorem.Word())
            .Select(word => ToPascalCase(word, firstCharacterIndex, remainingCharactersOffset))];

        // Act & Assert
        foreach (string word in words)
        {
            string firstResult = word.ToSnakeCase();
            string secondResult = firstResult.ToSnakeCase();
            _ = await Assert.That(secondResult).IsEqualTo(firstResult);
        }
    }
}