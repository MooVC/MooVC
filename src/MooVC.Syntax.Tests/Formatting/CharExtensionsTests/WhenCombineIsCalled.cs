namespace MooVC.Syntax.Formatting.CharExtensionsTests;

using System.Collections.Immutable;
using System.Linq;

public sealed class WhenCombineIsCalled
{
    private const char Separator = ',';
    private static readonly string[] samples = ["first", "second", "third"];

    [Test]
    public async Task GivenValuesAreNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        string[]? values = default;

        // Act
        Action action = () => Separator.Combine(values!);

        // Assert
        _ = await Assert.That(action).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenSingleValueThenTheValueIsReturned()
    {
        // Arrange
        string value = samples[0];

        // Act
        string result = Separator.Combine(value);

        // Assert
        _ = await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task GivenMultipleValuesThenTheyAreCombinedWithTheSeparator()
    {
        // Arrange
        string expected = string.Join(Separator, samples);

        // Act
        string result = Separator.Combine(samples);

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenFormatterIsNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        var elements = ImmutableArray.Create(samples);
        Func<string, string>? formatter = default;

        // Act
        Action action = () => Separator.Combine(elements, formatter!);

        // Assert
        _ = await Assert.That(action).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenElementsThenTheyAreFormattedAndCombined()
    {
        // Arrange
        var elements = ImmutableArray.Create(samples);
        string expected = string.Join(Separator, samples.Select(value => value.ToUpperInvariant()));

        // Act
        string result = Separator.Combine(elements, value => value.ToUpperInvariant());

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }
}