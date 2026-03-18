namespace MooVC.Syntax.Formatting.StringExtensionsTests;

using System.Collections.Immutable;
using System.Linq;

public sealed class WhenCombineIsCalled
{
    private const string Separator = ",";
    private static readonly string[] samples = ["first", "second", "third"];

    [Test]
    public async Task GivenSeparatorIsNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        string? separator = default;

        // Act
        Action action = () => separator!.Combine(samples);

        // Assert
        ArgumentNullException exception = await Assert.That(action).Throws<ArgumentNullException>();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(separator));
    }

    [Test]
    public async Task GivenSeparatorIsEmptyThenArgumentExceptionIsThrown()
    {
        // Arrange
        string separator = string.Empty;

        // Act
        Action action = () => separator.Combine(samples);

        // Assert
        ArgumentException exception = await Assert.That(action).Throws<ArgumentException>();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(separator));
    }

    [Test]
    public async Task GivenValuesAreNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        string separator = Separator;
        string[]? values = default;

        // Act
        Action action = () => separator.Combine(values!);

        // Assert
        ArgumentNullException exception = await Assert.That(action).Throws<ArgumentNullException>();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(values));
    }

    [Test]
    public async Task GivenNoValuesThenAnEmptyStringIsReturned()
    {
        // Arrange
        string separator = Separator;

        // Act
        string result = separator.Combine(Array.Empty<string>());

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenSingleValueThenTheValueIsReturned()
    {
        // Arrange
        string separator = Separator;
        string value = samples[0];

        // Act
        string result = separator.Combine(value);

        // Assert
        _ = await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task GivenMultipleValuesThenTheyAreCombinedWithTheSeparator()
    {
        // Arrange
        string separator = Separator;

        // Act
        string result = separator.Combine(samples);

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Join(separator, samples));
    }

    [Test]
    public async Task GivenFormatterIsNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        string separator = Separator;
        var elements = ImmutableArray.Create(samples);
        Func<string, string>? formatter = default;

        // Act
        Action action = () => separator.Combine(elements, formatter!);

        // Assert
        ArgumentNullException exception = await Assert.That(action).Throws<ArgumentNullException>();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(formatter));
    }

    [Test]
    public async Task GivenElementsAreDefaultThenAnEmptyStringIsReturned()
    {
        // Arrange
        string separator = Separator;
        ImmutableArray<string> elements = default;

        // Act
        string result = separator.Combine(elements, value => value);

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenElementsAreEmptyThenAnEmptyStringIsReturned()
    {
        // Arrange
        string separator = Separator;
        ImmutableArray<string> elements = [];

        // Act
        string result = separator.Combine(elements, value => value);

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenSeparatorIsNullThenArgumentNullExceptionIsThrownWhenElementsAreProvided()
    {
        // Arrange
        string? separator = default;
        var elements = ImmutableArray.Create(samples);

        // Act
        Action action = () => separator!.Combine(elements, value => value);

        // Assert
        ArgumentNullException exception = await Assert.That(action).Throws<ArgumentNullException>();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(separator));
    }

    [Test]
    public async Task GivenSeparatorIsEmptyThenArgumentExceptionIsThrownWhenElementsAreProvided()
    {
        // Arrange
        string separator = string.Empty;
        var elements = ImmutableArray.Create(samples);

        // Act
        Action action = () => separator.Combine(elements, value => value);

        // Assert
        ArgumentException exception = await Assert.That(action).Throws<ArgumentException>();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(separator));
    }

    [Test]
    public async Task GivenMultipleElementsThenTheyAreFormattedAndCombinedWithTheSeparator()
    {
        // Arrange
        string separator = Separator;
        var elements = ImmutableArray.Create(samples);

        // Act
        string result = separator.Combine(elements, value => value.ToUpperInvariant());

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Join(separator, samples.Select(value => value.ToUpperInvariant())));
    }
}