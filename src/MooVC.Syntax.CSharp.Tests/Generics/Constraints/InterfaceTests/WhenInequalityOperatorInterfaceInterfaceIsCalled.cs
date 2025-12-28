namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenInequalityOperatorInterfaceInterfaceIsCalled
{
    private const string Same = "IAlpha";
    private const string Different = "IBeta";

    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Interface? left = default;
        Interface? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEitherSideNullThenReturnsTrue()
    {
        // Arrange
        Interface left = new Declaration { Name = Same };
        Interface? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Interface left = new Declaration { Name = Same };
        Interface right = new Declaration { Name = Same };

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Interface left = new Declaration { Name = Same };
        Interface right = new Declaration { Name = Different };

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}