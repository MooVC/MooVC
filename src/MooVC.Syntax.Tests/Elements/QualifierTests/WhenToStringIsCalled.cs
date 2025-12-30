namespace MooVC.Syntax.Elements.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenEmptyValueThenReturnsEmptyString()
    {
        // Arrange
        var qualifier = new Qualifier([]);

        // Act
        string result = qualifier.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenSegmentsThenReturnsPeriodSeparatedValue()
    {
        // Arrange
        ImmutableArray<Segment> value = ["Alpha", "Beta", "Gamma"];
        var qualifier = new Qualifier(value);

        // Act
        string result = qualifier.ToString();

        // Assert
        result.ShouldBe("Alpha.Beta.Gamma");
    }
}