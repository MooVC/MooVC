namespace MooVC.Syntax.CSharp.Constructs.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultArrayThenInstanceIsCreated()
    {
        // Arrange
        ImmutableArray<Segment> value = default;

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Qualifier(value));
    }

    [Fact]
    public void GivenEmptyArrayThenInstanceIsCreated()
    {
        // Arrange
        ImmutableArray<Segment> value = ImmutableArray<Segment>.Empty;

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Qualifier(value));
    }

    [Fact]
    public void GivenSameSegmentsTwiceThenInstancesAreEqual()
    {
        // Arrange
        ImmutableArray<Segment> value = ImmutableArray.Create(new Segment("First"), new Segment("Second"));

        // Act
        var first = new Qualifier(value);
        var second = new Qualifier(value);

        // Assert
        first.Equals(second).ShouldBeTrue();
        (first == second).ShouldBeTrue();
        first.GetHashCode().ShouldBe(second.GetHashCode());
    }

    [Fact]
    public void GivenDifferentSegmentsTwiceThenInstancesAreNotEqual()
    {
        // Arrange
        ImmutableArray<Segment> left = ImmutableArray.Create(new Segment("First"));
        ImmutableArray<Segment> right = ImmutableArray.Create(new Segment("Second"));

        // Act
        var first = new Qualifier(left);
        var second = new Qualifier(right);

        // Assert
        first.Equals(second).ShouldBeFalse();
        (first != second).ShouldBeTrue();
    }
}
