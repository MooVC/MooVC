namespace MooVC.Syntax.CSharp.Members.ResultTests.ModalityTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenInequalityOperatorModalityStringIsCalled
{
    private const string Same = "async";
    private const string Different = "";

    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Result.Modality? left = default;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Result.Modality? left = default;
        const string right = Same;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Result.Modality left = Result.Modality.Asynchronous;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Result.Modality left = Result.Modality.Asynchronous;
        const string right = Same;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Result.Modality left = Result.Modality.Asynchronous;
        const string right = Different;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}
