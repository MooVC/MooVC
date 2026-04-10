namespace MooVC.Syntax.CSharp.ResultTests.ModifiersTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenNoneThenReturnsEmpty()
    {
        // Arrange
        Result.Modifiers subject = Result.Modifiers.None;

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenRefReadOnlyThenReturnsCombinedKeyword()
    {
        // Arrange
        Result.Modifiers subject = Result.Modifiers.RefReadOnly;

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo("ref readonly");
    }

    [Test]
    public async Task GivenUnsafeThenReturnsUnsafeKeyword()
    {
        // Arrange
        Result.Modifiers subject = Result.Modifiers.Unsafe;

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo("unsafe");
    }
}