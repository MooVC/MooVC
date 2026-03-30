namespace MooVC.Syntax.CSharp.OperatorsTests;

using MooVC.Syntax.CSharp.BinaryTests;

public sealed class WhenEqualityOperatorOperatorsOperatorsIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Operators? left = default;
        Operators? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Operators left = OperatorsSubjectData.Create();
        Operators right = OperatorsSubjectData.Create(binaries: [BinaryTestsData.Create()]);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Operators left = OperatorsSubjectData.Create(binaries: [BinaryTestsData.Create()]);
        Operators right = OperatorsSubjectData.Create(binaries: [BinaryTestsData.Create()]);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Operators? left = default;
        Operators right = OperatorsSubjectData.Create();

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Operators left = OperatorsSubjectData.Create();
        Operators? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}