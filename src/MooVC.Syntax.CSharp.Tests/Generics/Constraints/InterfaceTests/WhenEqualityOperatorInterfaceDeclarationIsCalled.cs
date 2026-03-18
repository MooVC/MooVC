namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualityOperatorInterfaceDeclarationIsCalled
{
    private const string Same = "IAlpha";
    private const string Different = "IBeta";

    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Interface? left = default;
        Declaration? right = default;

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
        Declaration? right = default;

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
        var right = new Declaration { Name = Same };

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
        var right = new Declaration { Name = Different };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}