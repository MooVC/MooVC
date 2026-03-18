namespace MooVC.Syntax.Elements.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultArrayThenInstanceIsCreated()
    {
        // Arrange
        ImmutableArray<Name> value = default;

        // Act & Assert
        _ = await Assert.That(() => _ = new Qualifier(value)).ThrowsNothing();
    }

    [Test]
    public async Task GivenEmptyArrayThenInstanceIsCreated()
    {
        // Arrange
        ImmutableArray<Name> value = [];

        // Act & Assert
        _ = await Assert.That(() => _ = new Qualifier(value)).ThrowsNothing();
    }

    [Test]
    public async Task GivenSameSegmentsTwiceThenInstancesAreEqual()
    {
        // Arrange
        ImmutableArray<Name> value = ["First", "Second"];

        // Act
        var first = new Qualifier(value);
        var second = new Qualifier(value);

        // Assert
        _ = await Assert.That(first.Equals(second)).IsTrue();
        _ = await Assert.That((first == second)).IsTrue();
        _ = await Assert.That(first.GetHashCode()).IsEqualTo(second.GetHashCode());
    }

    [Test]
    public async Task GivenDifferentSegmentsTwiceThenInstancesAreNotEqual()
    {
        // Arrange
        ImmutableArray<Name> left = ["First"];
        ImmutableArray<Name> right = ["Second"];

        // Act
        var first = new Qualifier(left);
        var second = new Qualifier(right);

        // Assert
        _ = await Assert.That(first.Equals(second)).IsFalse();
        _ = await Assert.That((first != second)).IsTrue();
    }
}