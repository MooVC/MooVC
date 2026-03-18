namespace MooVC.Syntax.CSharp.Elements.ExtensibilityTests;

public sealed class WhenEqualityOperatorExtensibilityExtensibilityIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Extensibility? left = default;
        Extensibility? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Extensibility? left = default;
        Extensibility right = Extensibility.Static;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Extensibility left = Extensibility.Static;
        Extensibility? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Extensibility first = Extensibility.Static;
        Extensibility second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Extensibility left = Extensibility.Static;
        Extensibility right = Extensibility.Abstract;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}