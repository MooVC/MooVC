namespace MooVC.Syntax.CSharp.PropertyTests.MethodsTests.SetterTests.ModesTests;

public sealed class WhenEqualsModesIsCalled
{
    [Test]
    public async Task GivenDifferentInstanceThenFalseIsReturned()
    {
        // Arrange
        Property.Methods.Setter.Modes subject = Property.Methods.Setter.Modes.Set;
        Property.Methods.Setter.Modes target = Property.Methods.Setter.Modes.Init;

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEquivalentInstanceThenTrueIsReturned()
    {
        // Arrange
        Property.Methods.Setter.Modes subject = Property.Methods.Setter.Modes.ReadOnly;
        Property.Methods.Setter.Modes target = Property.Methods.Setter.Modes.ReadOnly;

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullThenFalseIsReturned()
    {
        // Arrange
        Property.Methods.Setter.Modes? subject = Property.Methods.Setter.Modes.Set;
        Property.Methods.Setter.Modes? target = default;

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenTrueIsReturned()
    {
        // Arrange
        Property.Methods.Setter.Modes subject = Property.Methods.Setter.Modes.Init;
        Property.Methods.Setter.Modes target = subject;

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}