namespace MooVC.Syntax.CSharp.Syntax.BoolExtensionsTests;

public sealed class WhenPartialIsCalled
{
    [Test]
    public void GivenTrueThenReturnsPartialKeyword()
    {
        // Arrange
        bool subject = true;

        // Act
        string result = subject.Partial();

        // Assert
        result.ShouldBe("partial");
    }

    [Test]
    public void GivenFalseThenReturnsEmpty()
    {
        // Arrange
        bool subject = false;

        // Act
        string result = subject.Partial();

        // Assert
        result.ShouldBe(string.Empty);
    }
}