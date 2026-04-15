namespace MooVC.Syntax.CSharp.TypeTests.OptionsTests;

public sealed class WhenEqualityOperatorOptionsOptionsIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Type.Options();
        var right = new Type.Options().WithSnippets(Snippet.Options.Default.WithWhitespace("  "));

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEquivalentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Type.Options();
        var right = new Type.Options();

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}