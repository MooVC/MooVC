namespace MooVC.Syntax.CSharp.TypeTests.OptionsTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentRepresentations()
    {
        // Arrange
        var left = new Type.Options();
        Type.Options right = new Type.Options().WithSnippets(Snippet.Options.Default.WithWhitespace("  "));

        // Act
        string leftValue = left.ToString();
        string rightValue = right.ToString();

        // Assert
        _ = await Assert.That(leftValue).IsNotEqualTo(rightValue);
    }

    [Test]
    public async Task GivenEquivalentValuesThenReturnsSameRepresentation()
    {
        // Arrange
        var left = new Type.Options();
        var right = new Type.Options();

        // Act
        string leftValue = left.ToString();
        string rightValue = right.ToString();

        // Assert
        _ = await Assert.That(leftValue).IsEqualTo(rightValue);
    }
}