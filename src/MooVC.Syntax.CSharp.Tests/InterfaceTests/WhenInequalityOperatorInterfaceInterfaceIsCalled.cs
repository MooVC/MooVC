namespace MooVC.Syntax.CSharp.InterfaceTests;

public sealed class WhenInequalityOperatorInterfaceInterfaceIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Interface? left = default;
        Interface? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentNamesThenReturnsTrue()
    {
        // Arrange
        Interface left = InterfaceTestsData.Create();
        Interface right = InterfaceTestsData.Create(name: new Declaration { Name = "Other" });

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentScopesThenReturnsTrue()
    {
        // Arrange
        Interface left = InterfaceTestsData.Create(scope: Scope.Internal);
        Interface right = InterfaceTestsData.Create(scope: Scope.Private);

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Interface left = InterfaceTestsData.Create(scope: Scope.Internal);
        Interface right = InterfaceTestsData.Create(scope: Scope.Internal);

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Interface? left = default;
        Interface right = InterfaceTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Interface left = InterfaceTestsData.Create();
        Interface? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        Interface first = InterfaceTestsData.Create();
        Interface second = first;

        // Act
        bool result = first != second;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}