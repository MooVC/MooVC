namespace MooVC.Syntax.CSharp.Members.ResultTests.ModalityTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualityOperatorModalityModalityIsCalled
{
    private const string Same = "async";
    private const string Different = "";

    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Result.Modality? left = default;
        Result.Modality? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Result.Modality? left = default;
        Result.Modality right = Same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Result.Modality left = Same;
        Result.Modality? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Result.Modality first = Same;
        Result.Modality second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Result.Modality left = Same;
        Result.Modality right = Same;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Result.Modality left = Same;
        Result.Modality right = Different;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}
