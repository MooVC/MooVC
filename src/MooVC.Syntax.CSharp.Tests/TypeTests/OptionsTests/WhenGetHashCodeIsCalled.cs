namespace MooVC.Syntax.CSharp.TypeTests.OptionsTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenHashCodesDiffer()
    {
        // Arrange
        var left = new Type.Options();
        Type.Options right = new Type.Options().WithSnippets(Snippet.Options.Default.WithWhitespace("  "));

        // Act
        int leftHashCode = left.GetHashCode();
        int rightHashCode = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHashCode).IsNotEqualTo(rightHashCode);
    }

    [Test]
    public async Task GivenEquivalentValuesThenHashCodesMatch()
    {
        // Arrange
        var left = new Type.Options();
        var right = new Type.Options();

        // Act
        int leftHashCode = left.GetHashCode();
        int rightHashCode = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHashCode).IsEqualTo(rightHashCode);
    }
}