namespace MooVC.Syntax.Formatting.StringExtensionsTests;

using System.Globalization;

public sealed class WhenToPascalCaseIsCalled
{
    private static readonly Faker generator = new();

    [Test]
    public void GivenValueIsNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        string? value = default;

        // Act
        Action action = () => value!.ToPascalCase();

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
        Action action = () => value.ToPascalCase();

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
        Action action = () => value.ToPascalCase();

        // Assert
        ArgumentException exception = Should.Throw<ArgumentException>(action);
        exception.ParamName.ShouldBe(nameof(value));
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
    public void GivenValidValuesThenFirstCharacterIsUppercased(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToPascalCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    [Arguments("1Example")]
    [Arguments("_Example")]
    [Arguments("-Example")]
    [Arguments("😀Example")]
    [Arguments(".example")]
    public void GivenValueStartsWithNonLetterThenOriginalIsReturned(string value)
    {
        // Arrange & Act
        string result = value.ToPascalCase();

        // Assert
        result.ShouldBe(value);
    }

    [Test]
    public void GivenTurkishCultureIsActiveThenInvariantUppercasingIsUsed()
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
        result.ShouldBe("Istanbul");
    }

    [Test]
    public void GivenWordsWhenInvokedTwiceThenResultIsIdempotent()
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
            second.ShouldBe(first);
        }
    }

    [Test]
    public void GivenValueWithInternalWhitespaceThenOnlyFirstCharacterIsChanged()
    {
        // Arrange
        string value = "hello World";

        // Act
        string result = value.ToPascalCase();

        // Assert
        result.ShouldBe("Hello World");
    }

    [Test]
    public void GivenValueWithLeadingWhitespaceThenOriginalIsReturned()
    {
        // Arrange
        string value = " hello";

        // Act
        string result = value.ToPascalCase();

        // Assert
        result.ShouldBe(value);
    }

    [Test]
    public void GivenAlreadyPascalCaseThenResultIsUnchanged()
    {
        // Arrange
        string value = "AlreadyPascal";

        // Act
        string result = value.ToPascalCase();

        // Assert
        result.ShouldBe(value);
    }

    [Test]
    public void GivenVeryLongValueThenOnlyFirstCharacterIsUppercased()
    {
        // Arrange
        string value = new('a', 10_000);

        // Act
        string result = value.ToPascalCase();

        // Assert
        result[0].ShouldBe('A');
        result.Length.ShouldBe(value.Length);
        result.Skip(1).All(character => character == 'a').ShouldBeTrue();
    }

    [Test]
    public void GivenPunctuationAfterFirstLetterThenOnlyFirstCharacterIsChanged()
    {
        // Arrange
        string value = "x.Foo";

        // Act
        string result = value.ToPascalCase();

        // Assert
        result.ShouldBe("X.Foo");
    }
}