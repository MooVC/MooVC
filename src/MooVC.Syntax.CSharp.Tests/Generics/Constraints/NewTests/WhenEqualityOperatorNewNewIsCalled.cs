namespace MooVC.Syntax.CSharp.Generics.Constraints.NewTests;

public sealed class WhenEqualityOperatorNewNewIsCalled
{
    private const string Same = "new()";
    private const string Different = "";

    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        New? left = default;
        New? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEitherSideNullThenReturnsFalse()
    {
        // Arrange
        New left = Same;
        New? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        New left = Same;
        New right = Same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        New left = Same;
        New right = Different;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}