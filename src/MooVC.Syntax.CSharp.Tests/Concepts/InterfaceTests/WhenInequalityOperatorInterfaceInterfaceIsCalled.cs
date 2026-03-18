namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenInequalityOperatorInterfaceInterfaceIsCalled
{
    [Test]
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

    [Test]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Interface? left = default;
        Interface right = InterfaceTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Interface left = InterfaceTestsData.Create();
        Interface? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        Interface first = InterfaceTestsData.Create();
        Interface second = first;

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Interface left = InterfaceTestsData.Create(scope: Scope.Internal);
        Interface right = InterfaceTestsData.Create(scope: Scope.Internal);

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentNamesThenReturnsTrue()
    {
        // Arrange
        Interface left = InterfaceTestsData.Create();
        Interface right = InterfaceTestsData.Create(name: new Declaration { Name = "Other" });

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentScopesThenReturnsTrue()
    {
        // Arrange
        Interface left = InterfaceTestsData.Create(scope: Scope.Internal);
        Interface right = InterfaceTestsData.Create(scope: Scope.Private);

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}