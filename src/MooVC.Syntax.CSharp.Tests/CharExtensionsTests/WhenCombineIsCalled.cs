namespace MooVC.Syntax.CSharp.CharExtensionsTests;

using System.Collections.Immutable;
using System.Linq;

public sealed class WhenCombineIsCalled
{
    private const char Separator = ',';
    private static readonly string[] samples = ["first", "second", "third"];

    [Fact]
    public void GivenValuesAreNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        string[]? values = default;

        // Act
        Action action = () => Separator.Combine(values!);

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenSingleValueThenTheValueIsReturned()
    {
        // Arrange
        string value = samples[0];

        // Act
        string result = Separator.Combine(value);

        // Assert
        result.ShouldBe(value);
    }

    [Fact]
    public void GivenMultipleValuesThenTheyAreCombinedWithTheSeparator()
    {
        // Arrange
        string expected = string.Join(Separator, samples);

        // Act
        string result = Separator.Combine(samples);

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void GivenFormatterIsNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        var elements = ImmutableArray.Create(samples);
        Func<string, string>? formatter = default;

        // Act
        Action action = () => Separator.Combine(elements, formatter!);

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenElementsThenTheyAreFormattedAndCombined()
    {
        // Arrange
        var elements = ImmutableArray.Create(samples);
        string expected = string.Join(Separator, samples.Select(value => value.ToUpperInvariant()));

        // Act
        string result = Separator.Combine(elements, value => value.ToUpperInvariant());

        // Assert
        result.ShouldBe(expected);
    }
}