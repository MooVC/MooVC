namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualityOperatorInterfaceInterfaceIsCalled
{
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
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Interface? left = default;
        Interface right = InterfaceTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Interface left = InterfaceTestsData.Create();
        Interface? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Interface first = InterfaceTestsData.Create();
        Interface second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Interface left = InterfaceTestsData.Create(scope: Scope.Internal);
        Interface right = InterfaceTestsData.Create(scope: Scope.Internal);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentNamesThenReturnsFalse()
    {
        // Arrange
        Interface left = InterfaceTestsData.Create();
        Interface right = InterfaceTestsData.Create(name: new Declaration { Name = new Identifier("Other") });

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentScopesThenReturnsFalse()
    {
        // Arrange
        Interface left = InterfaceTestsData.Create(scope: Scope.Internal);
        Interface right = InterfaceTestsData.Create(scope: Scope.Private);

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}