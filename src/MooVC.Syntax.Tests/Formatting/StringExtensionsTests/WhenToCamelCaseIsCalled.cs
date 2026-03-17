namespace MooVC.Syntax.Formatting.StringExtensionsTests;

using System.Globalization;

public sealed class WhenToCamelCaseIsCalled
{
    private static readonly Faker generator = new();

    [Test]
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

    [Test]
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

    [Test]
    [Arguments(" ")]
    [Arguments("   ")]
    [Arguments("\t")]
    [Arguments("\r\n")]
    public void GivenValueContainsOnlyWhitespaceThenArgumentExceptionIsThrown(string value)
    {
        // Arrange & Act
        Action action = () => value.ToCamelCase();

        // Assert
        ArgumentException exception = Should.Throw<ArgumentException>(action);
        exception.ParamName.ShouldBe(nameof(value));
    }

    [Test]
    [Arguments("A", "a")]
    [Arguments("a", "a")]
    [Arguments("FooBar", "fooBar")]
    [Arguments("fooBar", "fooBar")]
    [Arguments("UpperCaseValue", "upperCaseValue")]
    [Arguments("Éclair", "éclair")]
    [Arguments("Σigma", "σigma")]
    [Arguments("A1b2", "a1b2")]
    public void GivenValidValuesThenFirstCharacterIsLowercased(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToCamelCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    [Arguments("1Example")]
    [Arguments("_Example")]
    [Arguments("-Example")]
    [Arguments("😀Example")]
    [Arguments(".Example")]
    public void GivenValueStartsWithNonLetterThenOriginalIsReturned(string value)
    {
        // Arrange & Act
        string result = value.ToCamelCase();

        // Assert
        result.ShouldBe(value);
    }

    [Test]
    public void GivenTurkishCultureIsActiveThenInvariantLowercasingIsUsed()
    {
        // Arrange
        CultureInfo originalCulture = CultureInfo.CurrentCulture;
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
            CultureInfo.CurrentCulture = originalCulture;
        }

        // Assert
        result.ShouldBe("istanbul");
    }

    [Test]
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

            second.ShouldBe(first);
        }
    }

    [Test]
    public void GivenValueWithInternalWhitespaceThenOnlyFirstCharacterIsChanged()
    {
        // Arrange
        string value = "Hello World";

        // Act
        string result = value.ToCamelCase();

        // Assert
        result.ShouldBe("hello World");
    }

    [Test]
    public void GivenValueWithLeadingWhitespaceThenOriginalIsReturned()
    {
        // Arrange
        string value = " Hello";

        // Act
        string result = value.ToCamelCase();

        // Assert
        result.ShouldBe(value);
    }

    [Test]
    public void GivenAlreadyCamelCaseThenResultIsUnchanged()
    {
        // Arrange
        string value = "alreadyCamel";

        // Act
        string result = value.ToCamelCase();

        // Assert
        result.ShouldBe(value);
    }

    [Test]
    public void GivenVeryLongValueThenOnlyFirstCharacterIsLowercased()
    {
        // Arrange
        string value = new('A', 10_000);

        // Act
        string result = value.ToCamelCase();

        // Assert
        result[0].ShouldBe('a');
        result.Length.ShouldBe(value.Length);
        result.Skip(1).All(character => character == 'A').ShouldBeTrue();
    }

    [Test]
    public void GivenPunctuationAfterFirstLetterThenOnlyFirstCharacterIsChanged()
    {
        // Arrange
        string value = "X.Foo";

        // Act
        string result = value.ToCamelCase();

        // Assert
        result.ShouldBe("x.Foo");
    }
}