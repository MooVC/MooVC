namespace MooVC.Syntax.CSharp.StringExtensionsTests;

using System.Globalization;

public sealed class WhenToPascalCaseIsCalled
{
    private static readonly Faker generator = new();

    [Fact]
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

    [Fact]
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

    [Theory]
    [InlineData(" ")]
    [InlineData("   ")]
    [InlineData("\t")]
    [InlineData("\r\n")]
    public void GivenValueContainsOnlyWhitespaceThenArgumentExceptionIsThrown(string value)
    {
        // Arrange & Act
        Action action = () => value.ToPascalCase();

        // Assert
        ArgumentException exception = Should.Throw<ArgumentException>(action);
        exception.ParamName.ShouldBe(nameof(value));
    }

    [Theory]
    [InlineData("A", "A")]
    [InlineData("a", "A")]
    [InlineData("FooBar", "FooBar")]
    [InlineData("fooBar", "FooBar")]
    [InlineData("upperCaseValue", "UpperCaseValue")]
    [InlineData("éclair", "Éclair")]
    [InlineData("σigma", "Σigma")]
    [InlineData("a1b2", "A1b2")]
    public void GivenValidValuesThenFirstCharacterIsUppercased(string value, string expected)
    {
        // Arrange & Act
        string result = value.ToPascalCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Theory]
    [InlineData("1Example")]
    [InlineData("_Example")]
    [InlineData("-Example")]
    [InlineData("😀Example")]
    [InlineData(".example")]
    public void GivenValueStartsWithNonLetterThenOriginalIsReturned(string value)
    {
        // Arrange & Act
        string result = value.ToPascalCase();

        // Assert
        result.ShouldBe(value);
    }

    [Fact]
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

    [Fact]
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

    [Fact]
    public void GivenValueWithInternalWhitespaceThenOnlyFirstCharacterIsChanged()
    {
        // Arrange
        string value = "hello World";

        // Act
        string result = value.ToPascalCase();

        // Assert
        result.ShouldBe("Hello World");
    }

    [Fact]
    public void GivenValueWithLeadingWhitespaceThenOriginalIsReturned()
    {
        // Arrange
        string value = " hello";

        // Act
        string result = value.ToPascalCase();

        // Assert
        result.ShouldBe(value);
    }

    [Fact]
    public void GivenAlreadyPascalCaseThenResultIsUnchanged()
    {
        // Arrange
        string value = "AlreadyPascal";

        // Act
        string result = value.ToPascalCase();

        // Assert
        result.ShouldBe(value);
    }

    [Fact]
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

    [Fact]
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