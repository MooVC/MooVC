namespace MooVC.Syntax.Formatting.StringExtensionsTests;

using System.Globalization;

public sealed class WhenToKebabCaseIsCalled
{
    private static readonly Faker generator = new();

    [Test]
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

    [Test]
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

    [Test]
    [Arguments(" ")]
    [Arguments("\t")]
    [Arguments("\r\n")]
    [Arguments("   ")]
    public void GivenValueContainsOnlyWhitespaceThenArgumentExceptionIsThrown(string value)
    {
        // Arrange & Act
        Action action = () => value.ToKebabCase();

        // Assert
        ArgumentException exception = Should.Throw<ArgumentException>(action);
        exception.ParamName.ShouldBe(nameof(value));
    }

    [Test]
    [Arguments("already-kebab-case", "already-kebab-case")]
    [Arguments("already_snake_case", "already-snake-case")]
    [Arguments("simple", "simple")]
    [Arguments("Single", "single")]
    [Arguments("PascalCase", "pascal-case")]
    [Arguments("camelCaseValue", "camel-case-value")]
    [Arguments("Hello World", "hello-world")]
    [Arguments("Hello-World", "hello-world")]
    [Arguments("Hello__World", "hello-world")]
    [Arguments("_Hello", "hello")]
    [Arguments("-Hello", "hello")]
    [Arguments(" Hello ", "hello")]
    [Arguments("Section2Update", "section2-update")]
    [Arguments("ÉclairDeluxe", "éclair-deluxe")]
    [Arguments("ΣigmaValue", "σigma-value")]
    public void GivenValuesThenExpectedKebabCaseIsReturned(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToKebabCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    [Arguments("A", "a")]
    [Arguments("ABC", "abc")]
    [Arguments("XMLHttpRequest", "xml-http-request")]
    public void GivenAcronymsAndTransitionsThenBoundariesAreHandled(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToKebabCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    public void GivenMultipleSeparatorsThenSeparatorsAreCollapsed()
    {
        // Arrange
        string value = "alpha  beta---gamma___delta";

        // Act
        string result = value.ToKebabCase();

        // Assert
        result.ShouldBe("alpha-beta-gamma-delta");
    }

    [Test]
    public void GivenMixedWhitespaceAndSeparatorsThenLeadingAndTrailingAreRemoved()
    {
        // Arrange
        string value = "  _Alpha__Beta- ";

        // Act
        string result = value.ToKebabCase();

        // Assert
        result.ShouldBe("alpha-beta");
    }

    [Test]
    public void GivenDigitBeforeUppercaseThenSeparatorIsInserted()
    {
        // Arrange
        string value = "Part3Revision";

        // Act
        string result = value.ToKebabCase();

        // Assert
        result.ShouldBe("part3-revision");
    }

    [Test]
    [Arguments("__", "")]
    [Arguments("---", "")]
    [Arguments("___---___", "")]
    public void GivenOnlySeparatorsThenResultIsEmpty(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToKebabCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    [Arguments("123", "123")]
    [Arguments("9lives", "9lives")]
    [Arguments("Version2Alpha3", "version2-alpha3")]
    public void GivenNumericScenariosThenDigitsArePreserved(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToKebabCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
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

    [Test]
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

    [Test]
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