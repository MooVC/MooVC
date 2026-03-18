namespace MooVC.Syntax.CSharp.Generics.Constraints.NatureTests;

public sealed class WhenEqualityOperatorNatureNatureIsCalled
{
    private const string Same = "class";
    private const string Different = "struct";

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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