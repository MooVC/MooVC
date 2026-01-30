namespace MooVC.Syntax.CSharp.Syntax.BoolExtensionsTests;

public sealed class WhenPartialIsCalled
{
    [Fact]
    public void GivenTrueThenReturnsPartialKeyword()
    {
        // Arrange
        bool subject = true;

        // Act
        string result = subject.Partial();

        // Assert
        result.ShouldBe("partial");
    }

    [Fact]
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