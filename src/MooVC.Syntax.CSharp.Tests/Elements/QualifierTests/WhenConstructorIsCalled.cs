namespace MooVC.Syntax.CSharp.Elements.QualifierTests;

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
        ImmutableArray<Segment> value = [];

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Qualifier(value));
    }

    [Fact]
    public void GivenSameSegmentsTwiceThenInstancesAreEqual()
    {
        // Arrange
        ImmutableArray<Segment> value = ["First", "Second"];

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
        ImmutableArray<Segment> left = ["First"];
        ImmutableArray<Segment> right = ["Second"];

        // Act
        var first = new Qualifier(left);
        var second = new Qualifier(right);

        // Assert
        first.Equals(second).ShouldBeFalse();
        (first != second).ShouldBeTrue();
    }
}