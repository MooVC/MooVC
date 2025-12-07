namespace MooVC.Syntax.CSharp.Members.PropertyTests.ModeTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualityOperatorModeIntIsCalled
{
    private const int Same = 1;
    private const int Different = 0;

    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Property.Mode? left = default;
        int? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Property.Mode? left = default;
        const int right = Same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Property.Mode left = Property.Mode.ReadOnly;
        int? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Property.Mode left = Property.Mode.ReadOnly;
        const int right = Same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Property.Mode left = Property.Mode.Init;
        const int right = Different;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}
