namespace MooVC.Syntax.CSharp.Elements.ResultTests.KindTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenNoneThenReturnsEmpty()
    {
        // Arrange
        Result.Kind subject = Result.Kind.None;

        // Act
        string representation = subject.ToString();

        // Assert
        await Assert.That(representation).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenRefReadOnlyThenReturnsCombinedKeyword()
    {
        // Arrange
        Result.Kind subject = Result.Kind.RefReadOnly;

        // Act
        string representation = subject.ToString();

        // Assert
        await Assert.That(representation).IsEqualTo("ref readonly");
    }

    [Test]
    public async Task GivenUnsafeThenReturnsUnsafeKeyword()
    {
        // Arrange
        Result.Kind subject = Result.Kind.Unsafe;

        // Act
        string representation = subject.ToString();

        // Assert
        await Assert.That(representation).IsEqualTo("unsafe");
    }
}