namespace MooVC.Syntax.CSharp.Constructs.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenImplicitOperatorToSegmentArrayIsCalled
{
    private static readonly Segment Alpha = new("Alpha");
    private static readonly Segment Beta = new("Beta");

    [Fact]
    public void GivenNullQualifierThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Qualifier? qualifier = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = (Segment[])qualifier!);

        // Assert
        exception.ParamName.ShouldBe("qualifier");
    }

    [Fact]
    public void GivenQualifierThenSegmentsAreReturned()
    {
        // Arrange
        ImmutableArray<Segment> value = ImmutableArray.Create(Alpha, Beta);
        var qualifier = new Qualifier(value);

        // Act
        Segment[] result = qualifier;

        // Assert
        result.ShouldBe(value.ToArray());
    }
}
