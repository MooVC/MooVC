namespace MooVC.Syntax.CSharp.Members.ExtensibilityTests;

public sealed class WhenEqualityOperatorExtensibilityExtensibilityIsCalled
{
    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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