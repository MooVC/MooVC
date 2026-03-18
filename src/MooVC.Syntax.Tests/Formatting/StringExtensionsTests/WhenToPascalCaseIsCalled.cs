namespace MooVC.Syntax.Formatting.StringExtensionsTests;

using System.Globalization;

public sealed class WhenToPascalCaseIsCalled
{
    private static readonly Faker generator = new();

    [Test]
    public async Task GivenValueIsNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        string? value = default;

        // Act
        Action action = () => value!.ToPascalCase();

        // Assert
        ArgumentNullException exception = await Assert.That(action).Throws<ArgumentNullException>();
        await Assert.That(exception.ParamName).IsEqualTo(nameof(value));
    }

    [Test]
    public async Task GivenValueIsEmptyThenArgumentExceptionIsThrown()
    {
        // Arrange
        string value = string.Empty;

        // Act
        Action action = () => value.ToPascalCase();

        // Assert
        ArgumentException exception = await Assert.That(action).Throws<ArgumentException>();
        await Assert.That(exception.ParamName).IsEqualTo(nameof(value));
    }

    [Test]
    [Arguments(" ")]
    [Arguments("   ")]
    [Arguments("\t")]
    [Arguments("\r\n")]
    public async Task GivenValueContainsOnlyWhitespaceThenArgumentExceptionIsThrown(string value)
    {
        // Arrange & Act
        Action action = () => value.ToPascalCase();

        // Assert
        ArgumentException exception = await Assert.That(action).Throws<ArgumentException>();
        await Assert.That(exception.ParamName).IsEqualTo(nameof(value));
    }

    [Test]
    [Arguments("A", "A")]
    [Arguments("a", "A")]
    [Arguments("FooBar", "FooBar")]
    [Arguments("fooBar", "FooBar")]
    [Arguments("upperCaseValue", "UpperCaseValue")]
    [Arguments("éclair", "Éclair")]
    [Arguments("σigma", "Σigma")]
    [Arguments("a1b2", "A1b2")]
    public async Task GivenValidValuesThenFirstCharacterIsUppercased(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToPascalCase();

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    [Arguments("1Example")]
    [Arguments("_Example")]
    [Arguments("-Example")]
    [Arguments("😀Example")]
    [Arguments(".example")]
    public async Task GivenValueStartsWithNonLetterThenOriginalIsReturned(string value)
    {
        // Arrange & Act
        string result = value.ToPascalCase();

        // Assert
        await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task GivenTurkishCultureIsActiveThenInvariantUppercasingIsUsed()
    {
        // Arrange
        CultureInfo originalCulture = CultureInfo.CurrentCulture;
        string value = "istanbul";

        // Act
        string result;

        try
        {
            CultureInfo.CurrentCulture = new CultureInfo("tr-TR");
            result = value.ToPascalCase();
        }
        finally
        {
            CultureInfo.CurrentCulture = originalCulture;
        }

        // Assert
        await Assert.That(result).IsEqualTo("Istanbul");
    }

    [Test]
    public async Task GivenWordsWhenInvokedTwiceThenResultIsIdempotent()
    {
        // Arrange
        const int wordCount = 10;

        string[] words = Enumerable
            .Range(0, wordCount)
            .Select(_ => generator.Lorem.Word())
            .ToArray();

        // Act & Assert
        foreach (string word in words)
        {
            string first = word.ToPascalCase();
            string second = first.ToPascalCase();

            // Assert
            await Assert.That(second).IsEqualTo(first);
        }
    }

    [Test]
    public async Task GivenValueWithInternalWhitespaceThenOnlyFirstCharacterIsChanged()
    {
        // Arrange
        string value = "hello World";

        // Act
        string result = value.ToPascalCase();

        // Assert
        await Assert.That(result).IsEqualTo("Hello World");
    }

    [Test]
    public async Task GivenValueWithLeadingWhitespaceThenOriginalIsReturned()
    {
        // Arrange
        string value = " hello";

        // Act
        string result = value.ToPascalCase();

        // Assert
        await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task GivenAlreadyPascalCaseThenResultIsUnchanged()
    {
        // Arrange
        string value = "AlreadyPascal";

        // Act
        string result = value.ToPascalCase();

        // Assert
        await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task GivenVeryLongValueThenOnlyFirstCharacterIsUppercased()
    {
        // Arrange
        string value = new('a', 10_000);

        // Act
        string result = value.ToPascalCase();

        // Assert
        await Assert.That(result[0]).IsEqualTo('A');
        await Assert.That(result.Length).IsEqualTo(value.Length);
        await Assert.That(result.Skip(1).All(character => character == 'a')).IsTrue();
    }

    [Test]
    public async Task GivenPunctuationAfterFirstLetterThenOnlyFirstCharacterIsChanged()
    {
        // Arrange
        string value = "x.Foo";

        // Act
        string result = value.ToPascalCase();

        // Assert
        await Assert.That(result).IsEqualTo("X.Foo");
    }
}