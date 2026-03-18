namespace MooVC.Syntax.CSharp.Syntax.BoolExtensionsTests;

public sealed class WhenPartialIsCalled
{
    [Test]
    public async Task GivenTrueThenReturnsPartialKeyword()
    {
        // Arrange
        bool subject = true;

        // Act
        string result = subject.Partial();

        // Assert
        await Assert.That(result).IsEqualTo("partial");
    }

    [Test]
    public async Task GivenFalseThenReturnsEmpty()
    {
        // Arrange
        bool subject = false;

        // Act
        string result = subject.Partial();

        // Assert
        await Assert.That(result).IsEqualTo(string.Empty);
    }
}