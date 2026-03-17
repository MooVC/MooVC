namespace MooVC.Syntax.Formatting.StringExtensionsTests;

using System.Collections.Immutable;
using System.Linq;

public sealed class WhenCombineIsCalled
{
    private const string Separator = ",";
    private static readonly string[] samples = ["first", "second", "third"];

    [Test]
    public void GivenSeparatorIsNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        string? separator = default;

        // Act
        Action action = () => separator!.Combine(samples);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(action);
        exception.ParamName.ShouldBe(nameof(separator));
    }

    [Test]
    public void GivenSeparatorIsEmptyThenArgumentExceptionIsThrown()
    {
        // Arrange
        string separator = string.Empty;

        // Act
        Action action = () => separator.Combine(samples);

        // Assert
        ArgumentException exception = Should.Throw<ArgumentException>(action);
        exception.ParamName.ShouldBe(nameof(separator));
    }

    [Test]
    public void GivenValuesAreNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        string separator = Separator;
        string[]? values = default;

        // Act
        Action action = () => separator.Combine(values!);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(action);
        exception.ParamName.ShouldBe(nameof(values));
    }

    [Test]
    public void GivenNoValuesThenAnEmptyStringIsReturned()
    {
        // Arrange
        string separator = Separator;

        // Act
        string result = separator.Combine(Array.Empty<string>());

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Test]
    public void GivenSingleValueThenTheValueIsReturned()
    {
        // Arrange
        string separator = Separator;
        string value = samples[0];

        // Act
        string result = separator.Combine(value);

        // Assert
        result.ShouldBe(value);
    }

    [Test]
    public void GivenMultipleValuesThenTheyAreCombinedWithTheSeparator()
    {
        // Arrange
        string separator = Separator;

        // Act
        string result = separator.Combine(samples);

        // Assert
        result.ShouldBe(string.Join(separator, samples));
    }

    [Test]
    public void GivenFormatterIsNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        string separator = Separator;
        var elements = ImmutableArray.Create(samples);
        Func<string, string>? formatter = default;

        // Act
        Action action = () => separator.Combine(elements, formatter!);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(action);
        exception.ParamName.ShouldBe(nameof(formatter));
    }

    [Test]
    public void GivenElementsAreDefaultThenAnEmptyStringIsReturned()
    {
        // Arrange
        string separator = Separator;
        ImmutableArray<string> elements = default;

        // Act
        string result = separator.Combine(elements, value => value);

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Test]
    public void GivenElementsAreEmptyThenAnEmptyStringIsReturned()
    {
        // Arrange
        string separator = Separator;
        ImmutableArray<string> elements = [];

        // Act
        string result = separator.Combine(elements, value => value);

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Test]
    public void GivenSeparatorIsNullThenArgumentNullExceptionIsThrownWhenElementsAreProvided()
    {
        // Arrange
        string? separator = default;
        var elements = ImmutableArray.Create(samples);

        // Act
        Action action = () => separator!.Combine(elements, value => value);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(action);
        exception.ParamName.ShouldBe(nameof(separator));
    }

    [Test]
    public void GivenSeparatorIsEmptyThenArgumentExceptionIsThrownWhenElementsAreProvided()
    {
        // Arrange
        string separator = string.Empty;
        var elements = ImmutableArray.Create(samples);

        // Act
        Action action = () => separator.Combine(elements, value => value);

        // Assert
        ArgumentException exception = Should.Throw<ArgumentException>(action);
        exception.ParamName.ShouldBe(nameof(separator));
    }

    [Test]
    public void GivenMultipleElementsThenTheyAreFormattedAndCombinedWithTheSeparator()
    {
        // Arrange
        string separator = Separator;
        var elements = ImmutableArray.Create(samples);

        // Act
        string result = separator.Combine(elements, value => value.ToUpperInvariant());

        // Assert
        result.ShouldBe(string.Join(separator, samples.Select(value => value.ToUpperInvariant())));
    }
}