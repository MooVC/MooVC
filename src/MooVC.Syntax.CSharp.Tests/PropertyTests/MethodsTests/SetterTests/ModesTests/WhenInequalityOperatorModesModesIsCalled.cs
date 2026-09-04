namespace MooVC.Syntax.CSharp.PropertyTests.MethodsTests.SetterTests.ModesTests;

public sealed class WhenInequalityOperatorModesModesIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Property.Methods.Setter.Modes? left = default;
        Property.Methods.Setter.Modes? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Property.Methods.Setter.Modes left = Property.Methods.Setter.Modes.Set;
        Property.Methods.Setter.Modes right = Property.Methods.Setter.Modes.Init;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Property.Methods.Setter.Modes left = Property.Methods.Setter.Modes.Set;
        Property.Methods.Setter.Modes right = Property.Methods.Setter.Modes.Set;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Property.Methods.Setter.Modes? left = default;
        Property.Methods.Setter.Modes right = Property.Methods.Setter.Modes.Init;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Property.Methods.Setter.Modes left = Property.Methods.Setter.Modes.Init;
        Property.Methods.Setter.Modes? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        Property.Methods.Setter.Modes first = Property.Methods.Setter.Modes.ReadOnly;
        Property.Methods.Setter.Modes second = first;

        // Act
        bool result = first != second;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}