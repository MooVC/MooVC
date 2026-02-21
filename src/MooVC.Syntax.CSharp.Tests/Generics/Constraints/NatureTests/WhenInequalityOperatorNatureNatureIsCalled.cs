namespace MooVC.Syntax.CSharp.Generics.Constraints.NatureTests;

public sealed class WhenInequalityOperatorNatureNatureIsCalled
{
    private const string Same = "class";
    private const string Different = "struct";

    [Fact]
    public void GivenBothSidesNullThenReturnsFalse()
    {
        // Arrange
        Nature? left = default;
        Nature? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEitherSideNullThenReturnsTrue()
    {
        // Arrange
        Nature left = Same;
        Nature? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Nature left = Same;
        Nature right = Same;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Nature left = Same;
        Nature right = Different;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}