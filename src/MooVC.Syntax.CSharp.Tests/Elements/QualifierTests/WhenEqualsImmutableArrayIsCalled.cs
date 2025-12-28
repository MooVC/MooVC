namespace MooVC.Syntax.CSharp.Elements.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenEqualsImmutableArrayIsCalled
{
    private static readonly ImmutableArray<Segment> different = ["Gamma"];
    private static readonly ImmutableArray<Segment> same = ["Alpha", "Beta"];

    [Fact]
    public void GivenLeftValueRightDefaultThenReturnsFalse()
    {
        // Arrange
        var left = new Qualifier(same);
        ImmutableArray<Segment> right = default;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Qualifier(same);
        ImmutableArray<Segment> right = same;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Qualifier(same);
        ImmutableArray<Segment> right = different;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }
}