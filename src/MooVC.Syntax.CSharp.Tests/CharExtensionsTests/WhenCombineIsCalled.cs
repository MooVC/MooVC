namespace MooVC.Syntax.CSharp.CharExtensionsTests;

using System.Collections.Immutable;
using System.Linq;

public sealed class WhenCombineIsCalled
{
    private const char Separator = ',';
    private static readonly string[] Samples = ["first", "second", "third"];

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
        string value = Samples[0];

        // Act
        string result = Separator.Combine(value);

        // Assert
        result.ShouldBe(value);
    }

    [Fact]
    public void GivenMultipleValuesThenTheyAreCombinedWithTheSeparator()
    {
        // Arrange

        // Act
        string result = Separator.Combine(Samples);

        // Assert
        result.ShouldBe(string.Join(Separator, Samples));
    }

    [Fact]
    public void GivenFormatterIsNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        var elements = ImmutableArray.Create(Samples);
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
        var elements = ImmutableArray.Create(Samples);

        // Act
        string result = Separator.Combine(elements, value => value.ToUpperInvariant());

        // Assert
        result.ShouldBe(string.Join(Separator, Samples.Select(value => value.ToUpperInvariant())));
    }
}
