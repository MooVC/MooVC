namespace MooVC.Syntax.CSharp.Members.ResultTests.ModalityTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenCodesMatch()
    {
        // Arrange
        Result.Modality left = Result.Modality.Asynchronous;
        Result.Modality right = Result.Modality.Asynchronous;

        // Act
        int leftCode = left.GetHashCode();
        int rightCode = right.GetHashCode();

        // Assert
        leftCode.ShouldBe(rightCode);
    }

    [Fact]
    public void GivenDifferentValuesThenCodesDiffer()
    {
        // Arrange
        Result.Modality left = Result.Modality.Asynchronous;
        Result.Modality right = Result.Modality.Synchronous;

        // Act
        int leftCode = left.GetHashCode();
        int rightCode = right.GetHashCode();

        // Assert
        leftCode.ShouldNotBe(rightCode);
    }
}
