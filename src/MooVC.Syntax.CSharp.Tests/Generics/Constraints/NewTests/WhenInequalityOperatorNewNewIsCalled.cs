namespace MooVC.Syntax.CSharp.Generics.Constraints.NewTests;

public sealed class WhenInequalityOperatorNewNewIsCalled
{
    private const string Same = "new()";
    private const string Different = "";

    [Test]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        New? left = default;
        New? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEitherSideNullThenReturnsTrue()
    {
        // Arrange
        New left = Same;
        New? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        New left = Same;
        New right = Same;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        New left = Same;
        New right = Different;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}