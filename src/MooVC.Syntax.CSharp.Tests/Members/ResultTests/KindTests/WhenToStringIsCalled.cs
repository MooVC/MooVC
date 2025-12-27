namespace MooVC.Syntax.CSharp.Members.ResultTests.KindTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenNoneThenReturnsEmpty()
    {
        // Arrange
        Result.Kind subject = Result.Kind.None;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenRefReadOnlyThenReturnsCombinedKeyword()
    {
        // Arrange
        Result.Kind subject = Result.Kind.RefReadOnly;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe("ref readonly");
    }

    [Fact]
    public void GivenUnsafeThenReturnsUnsafeKeyword()
    {
        // Arrange
        Result.Kind subject = Result.Kind.Unsafe;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe("unsafe");
    }
}