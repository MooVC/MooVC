namespace MooVC.Syntax.Formatting.StringExtensionsTests;

using System.Globalization;

public sealed class WhenToCamelCaseIsCalled
{
    private static readonly Faker _generator = new();

    [Test]
    public async Task GivenAlreadyCamelCaseThenResultIsUnchanged()
    {
        // Arrange
        string value = "alreadyCamel";

        // Act
        string result = value.ToCamelCase();

        // Assert
        _ = await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task GivenPunctuationAfterFirstLetterThenOnlyFirstCharacterIsChanged()
    {
        // Arrange
        string value = "X.Foo";

        // Act
        string result = value.ToCamelCase();

        // Assert
        _ = await Assert.That(result).IsEqualTo("x.Foo");
    }

    [Test]
    public async Task GivenTurkishCultureIsActiveThenInvariantLowercasingIsUsed()
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
        _ = await Assert.That(result).IsEqualTo("istanbul");
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
    public async Task GivenValidValuesThenFirstCharacterIsLowercased(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToCamelCase();

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    [Arguments(" ")]
    [Arguments("   ")]
    [Arguments("\t")]
    [Arguments("\r\n")]
    public async Task GivenValueContainsOnlyWhitespaceThenArgumentExceptionIsThrown(string value)
    {
        // Arrange & Act
        Action act = () => value.ToCamelCase();

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
        Action act = () => value.ToCamelCase();

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
        Action act = () => value!.ToCamelCase();

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(value));
    }

    [Test]
    [Arguments("1Example")]
    [Arguments("_Example")]
    [Arguments("-Example")]
    [Arguments("😀Example")]
    [Arguments(".Example")]
    public async Task GivenValueStartsWithNonLetterThenOriginalIsReturned(string value)
    {
        // Arrange & Act
        string result = value.ToCamelCase();

        // Assert
        _ = await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task GivenValueWithInternalWhitespaceThenOnlyFirstCharacterIsChanged()
    {
        // Arrange
        string value = "Hello World";

        // Act
        string result = value.ToCamelCase();

        // Assert
        _ = await Assert.That(result).IsEqualTo("hello World");
    }

    [Test]
    public async Task GivenValueWithLeadingWhitespaceThenOriginalIsReturned()
    {
        // Arrange
        string value = " Hello";

        // Act
        string result = value.ToCamelCase();

        // Assert
        _ = await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task GivenVeryLongValueThenOnlyFirstCharacterIsLowercased()
    {
        // Arrange
        string value = new('A', 10_000);

        // Act
        string result = value.ToCamelCase();

        // Assert
        _ = await Assert.That(result[0]).IsEqualTo('a');
        _ = await Assert.That(result.Length).IsEqualTo(value.Length);
        _ = await Assert.That(result.Skip(1).All(character => character == 'A')).IsTrue();
    }

    [Test]
    public async Task GivenWordsWhenInvokedTwiceThenResultIsIdempotent()
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

        string[] words = [.. Enumerable
            .Range(0, WordCount)
            .Select(_ => _generator.Lorem.Word())
            .Select(CapitalizeFirstLetter)];

        // Act & Assert
        foreach (string word in words)
        {
            string first = word.ToCamelCase();
            string second = first.ToCamelCase();

            _ = await Assert.That(second).IsEqualTo(first);
        }
    }
}