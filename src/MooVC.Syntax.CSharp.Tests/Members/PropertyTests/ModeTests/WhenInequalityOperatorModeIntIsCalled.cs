namespace MooVC.Syntax.CSharp.Members.PropertyTests.ModeTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenInequalityOperatorModeIntIsCalled
{
    private const int Same = 1;
    private const int Different = 2;

    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Property.Mode? left = default;
        int? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Property.Mode? left = default;
        const int right = Same;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Property.Mode left = Property.Mode.Init;
        int? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Property.Mode left = Property.Mode.Init;
        const int right = Same;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Property.Mode left = Property.Mode.ReadOnly;
        const int right = Different;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}
