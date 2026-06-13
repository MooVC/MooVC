namespace MooVC.Syntax.Formatting.StringExtensionsTests;

using System.Collections.Immutable;
using System.Linq;

public sealed class WhenCombineIsCalled
{
    private const string Separator = ",";
    private static readonly string[] _samples = ["first", "second", "third"];

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
    public async Task GivenFormatterIsNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        string separator = Separator;
        var elements = ImmutableArray.Create(_samples);
        Func<string, string>? formatter = default;

        // Act
        Action act = () => separator.Combine(elements, formatter!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(formatter));
    }

    [Test]
    public async Task GivenMultipleElementsThenTheyAreFormattedAndCombinedWithTheSeparator()
    {
        // Arrange
        string separator = Separator;
        var elements = ImmutableArray.Create(_samples);

        // Act
        string result = separator.Combine(elements, value => value.ToUpperInvariant());

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Join(separator, _samples.Select(value => value.ToUpperInvariant())));
    }

    [Test]
    public async Task GivenMultipleValuesThenTheyAreCombinedWithTheSeparator()
    {
        // Arrange
        string separator = Separator;

        // Act
        string result = separator.Combine(_samples);

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Join(separator, _samples));
    }

    [Test]
    public async Task GivenNoValuesThenAnEmptyStringIsReturned()
    {
        // Arrange
        string separator = Separator;

        // Act
        string result = separator.Combine();

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenSeparatorIsEmptyThenArgumentExceptionIsThrown()
    {
        // Arrange
        string separator = string.Empty;

        // Act
        Action act = () => separator.Combine(_samples);

        // Assert
        ArgumentException exception = await Assert.That(act).Throws<ArgumentException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(separator));
    }

    [Test]
    public async Task GivenSeparatorIsEmptyThenArgumentExceptionIsThrownWhenElementsAreProvided()
    {
        // Arrange
        string separator = string.Empty;
        var elements = ImmutableArray.Create(_samples);

        // Act
        Action act = () => separator.Combine(elements, value => value);

        // Assert
        ArgumentException exception = await Assert.That(act).Throws<ArgumentException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(separator));
    }

    [Test]
    public async Task GivenSeparatorIsNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        string? separator = default;

        // Act
        Action act = () => separator!.Combine(_samples);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(separator));
    }

    [Test]
    public async Task GivenSeparatorIsNullThenArgumentNullExceptionIsThrownWhenElementsAreProvided()
    {
        // Arrange
        string? separator = default;
        var elements = ImmutableArray.Create(_samples);

        // Act
        Action act = () => separator!.Combine(elements, value => value);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(separator));
    }

    [Test]
    public async Task GivenSingleValueThenTheValueIsReturned()
    {
        // Arrange
        string separator = Separator;
        string value = _samples[0];

        // Act
        string result = separator.Combine(value);

        // Assert
        _ = await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task GivenValuesAreNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        string separator = Separator;
        string[]? values = default;

        // Act
        Action act = () => separator.Combine(values!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(values));
    }
}