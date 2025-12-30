namespace MooVC.Syntax.Elements.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenImplicitOperatorToSegmentArrayIsCalled
{
    private static readonly Segment alpha = new("Alpha");
    private static readonly Segment beta = new("Beta");

    [Fact]
    public void GivenNullQualifierThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Qualifier? qualifier = default;

        // Act
        Func<Segment[]> result = () => qualifier;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenQualifierThenSegmentsAreReturned()
    {
        // Arrange
        ImmutableArray<Segment> value = [alpha, beta];
        var qualifier = new Qualifier(value);

        // Act
        Segment[] result = qualifier;

        // Assert
        result.ShouldBe([.. value]);
    }
}