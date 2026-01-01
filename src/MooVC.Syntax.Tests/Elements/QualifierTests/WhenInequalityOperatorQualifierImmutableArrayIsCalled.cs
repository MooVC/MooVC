namespace MooVC.Syntax.Elements.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenInequalityOperatorQualifierImmutableArrayIsCalled
{
    private static readonly ImmutableArray<Segment> different = ["Gamma"];
    private static readonly ImmutableArray<Segment> same = ["Alpha", "Beta"];

    [Fact]
    public void GivenLeftValueRightDefaultThenReturnsTrue()
    {
        // Arrange
        var left = new Qualifier(same);
        ImmutableArray<Segment> right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Qualifier(same);
        ImmutableArray<Segment> right = same;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Qualifier(same);
        ImmutableArray<Segment> right = different;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}