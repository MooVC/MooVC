namespace MooVC.Syntax.CSharp.Members.ResultTests.KindTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenInequalityOperatorKindKindIsCalled
{
    private const string Same = "ref";
    private const string Different = "unsafe";

    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Result.Kind? left = default;
        Result.Kind? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Result.Kind? left = default;
        Result.Kind right = Same;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Result.Kind left = Same;
        Result.Kind? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        Result.Kind first = Same;
        Result.Kind second = first;

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Result.Kind left = Same;
        Result.Kind right = Same;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Result.Kind left = Same;
        Result.Kind right = Different;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }
}
