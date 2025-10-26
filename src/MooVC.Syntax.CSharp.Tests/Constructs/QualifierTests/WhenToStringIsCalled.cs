namespace MooVC.Syntax.CSharp.Constructs.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenEmptyValueThenReturnsEmptyString()
    {
        // Arrange
        var qualifier = new Qualifier(ImmutableArray<Segment>.Empty);

        // Act
        string result = qualifier.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenSegmentsThenReturnsPeriodSeparatedValue()
    {
        // Arrange
        ImmutableArray<Segment> value = ImmutableArray.Create(new Segment("Alpha"), new Segment("Beta"), new Segment("Gamma"));
        var qualifier = new Qualifier(value);

        // Act
        string result = qualifier.ToString();

        // Assert
        result.ShouldBe("Alpha.Beta.Gamma");
    }
}
