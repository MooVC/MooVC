namespace MooVC.Syntax.CSharp.Members.PropertyTests.ModeTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualsModeIsCalled
{
    [Test]
    public async Task GivenNullThenFalseIsReturned()
    {
        // Arrange
        Property.Mode? subject = Property.Mode.Set;
        Property.Mode? target = default;

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenTrueIsReturned()
    {
        // Arrange
        Property.Mode subject = Property.Mode.Init;
        Property.Mode target = subject;

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEquivalentInstanceThenTrueIsReturned()
    {
        // Arrange
        Property.Mode subject = Property.Mode.ReadOnly;
        Property.Mode target = Property.Mode.ReadOnly;

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentInstanceThenFalseIsReturned()
    {
        // Arrange
        Property.Mode subject = Property.Mode.Set;
        Property.Mode target = Property.Mode.Init;

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}