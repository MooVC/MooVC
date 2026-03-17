namespace MooVC.Syntax.CSharp.Members.PropertyTests.ModeTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualsModeIsCalled
{
    [Test]
    public void GivenNullThenFalseIsReturned()
    {
        // Arrange
        Property.Mode? subject = Property.Mode.Set;
        Property.Mode? target = default;

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenTrueIsReturned()
    {
        // Arrange
        Property.Mode subject = Property.Mode.Init;
        Property.Mode target = subject;

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEquivalentInstanceThenTrueIsReturned()
    {
        // Arrange
        Property.Mode subject = Property.Mode.ReadOnly;
        Property.Mode target = Property.Mode.ReadOnly;

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentInstanceThenFalseIsReturned()
    {
        // Arrange
        Property.Mode subject = Property.Mode.Set;
        Property.Mode target = Property.Mode.Init;

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeFalse();
    }
}