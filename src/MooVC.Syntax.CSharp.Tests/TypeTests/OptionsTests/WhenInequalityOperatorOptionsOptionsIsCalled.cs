namespace MooVC.Syntax.CSharp.TypeTests.OptionsTests;

public sealed class WhenInequalityOperatorOptionsOptionsIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Type.Options();
        Type.Options right = new Type.Options().WithSnippets(Snippet.Options.Default.WithWhitespace("  "));

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEquivalentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Type.Options();
        var right = new Type.Options();

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}