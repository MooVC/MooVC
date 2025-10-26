namespace MooVC.Syntax.CSharp.Constructs.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenEqualsImmutableArrayIsCalled
{
    private static readonly ImmutableArray<Segment> Same = ImmutableArray.Create(new Segment("Alpha"), new Segment("Beta"));
    private static readonly ImmutableArray<Segment> Different = ImmutableArray.Create(new Segment("Gamma"));

    [Fact]
    public void GivenLeftValueRightDefaultThenReturnsFalse()
    {
        // Arrange
        var left = new Qualifier(Same);
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
        var left = new Qualifier(Same);
        ImmutableArray<Segment> right = Same;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Qualifier(Same);
        ImmutableArray<Segment> right = Different;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }
}
