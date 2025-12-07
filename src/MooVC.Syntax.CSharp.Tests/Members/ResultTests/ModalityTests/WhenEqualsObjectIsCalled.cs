namespace MooVC.Syntax.CSharp.Members.ResultTests.ModalityTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Result.Modality subject = Result.Modality.Asynchronous;
        object? comparison = default;

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        Result.Modality subject = Result.Modality.Asynchronous;
        object comparison = string.Empty;

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValueThenReturnsTrue()
    {
        // Arrange
        Result.Modality subject = Result.Modality.Asynchronous;
        object comparison = Result.Modality.Asynchronous;

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Result.Modality subject = Result.Modality.Asynchronous;
        object comparison = Result.Modality.Synchronous;

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeFalse();
    }
}
