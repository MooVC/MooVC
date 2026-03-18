namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualityOperatorInterfaceInterfaceIsCalled
{
    private const string Same = "IAlpha";
    private const string Different = "IBeta";

    [Test]
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

    [Test]
    public void GivenEitherSideNullThenReturnsFalse()
    {
        // Arrange
        Interface left = new Declaration { Name = Same };
        Interface? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Interface left = new Declaration { Name = Same };
        Interface right = new Declaration { Name = Same };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Interface left = new Declaration { Name = Same };
        Interface right = new Declaration { Name = Different };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}