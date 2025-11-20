namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualityOperatorInterfaceInterfaceIsCalled
{
    private const string Same = "IAlpha";
    private const string Different = "IBeta";

    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Interface? left = default;
        Interface? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEitherSideNullThenReturnsFalse()
    {
        // Arrange
        Interface left = new Declaration { Name = new Identifier(Same) };
        Interface? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Interface left = new Declaration { Name = new Identifier(Same) };
        Interface right = new Declaration { Name = new Identifier(Same) };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Interface left = new Declaration { Name = new Identifier(Same) };
        Interface right = new Declaration { Name = new Identifier(Different) };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}
