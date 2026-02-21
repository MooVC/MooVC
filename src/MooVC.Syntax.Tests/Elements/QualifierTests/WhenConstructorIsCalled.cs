namespace MooVC.Syntax.Elements.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultArrayThenInstanceIsCreated()
    {
        // Arrange
        ImmutableArray<Name> value = default;

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Qualifier(value));
    }

    [Fact]
    public void GivenEmptyArrayThenInstanceIsCreated()
    {
        // Arrange
        ImmutableArray<Name> value = [];

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Qualifier(value));
    }

    [Fact]
    public void GivenSameSegmentsTwiceThenInstancesAreEqual()
    {
        // Arrange
        ImmutableArray<Name> value = ["First", "Second"];

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
        ImmutableArray<Name> left = ["First"];
        ImmutableArray<Name> right = ["Second"];

        // Act
        var first = new Qualifier(left);
        var second = new Qualifier(right);

        // Assert
        first.Equals(second).ShouldBeFalse();
        (first != second).ShouldBeTrue();
    }
}