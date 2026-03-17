namespace MooVC.Syntax.CSharp.Elements.ResultTests.KindTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public void GivenNoneThenReturnsEmpty()
    {
        // Arrange
        Result.Kind subject = Result.Kind.None;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Test]
    public void GivenRefReadOnlyThenReturnsCombinedKeyword()
    {
        // Arrange
        Result.Kind subject = Result.Kind.RefReadOnly;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe("ref readonly");
    }

    [Test]
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