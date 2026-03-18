namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

using MooVC.Syntax.CSharp.Operators.BinaryTests;

public sealed class WhenEqualityOperatorOperatorsOperatorsIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Operators? left = default;
        Operators? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Operators? left = default;
        Operators right = OperatorsSubjectData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Operators left = OperatorsSubjectData.Create();
        Operators? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Operators left = OperatorsSubjectData.Create(binaries: [BinaryTestsData.Create()]);
        Operators right = OperatorsSubjectData.Create(binaries: [BinaryTestsData.Create()]);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Operators left = OperatorsSubjectData.Create();
        Operators right = OperatorsSubjectData.Create(binaries: [BinaryTestsData.Create()]);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}