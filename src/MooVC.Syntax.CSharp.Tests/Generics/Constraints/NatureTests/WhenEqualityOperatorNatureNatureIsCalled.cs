namespace MooVC.Syntax.CSharp.Generics.Constraints.NatureTests;

public sealed class WhenEqualityOperatorNatureNatureIsCalled
{
    private const string Same = "class";
    private const string Different = "struct";

    [Fact]
    public void GivenBothSidesNullThenReturnsTrue()
    {
        // Arrange
        Nature? left = default;
        Nature? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEitherSideNullThenReturnsFalse()
    {
        // Arrange
        Nature left = Same;
        Nature? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Nature left = Same;
        Nature right = Same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Nature left = Same;
        Nature right = Different;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}
