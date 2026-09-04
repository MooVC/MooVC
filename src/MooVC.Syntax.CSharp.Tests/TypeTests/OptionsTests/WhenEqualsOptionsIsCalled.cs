namespace MooVC.Syntax.CSharp.TypeTests.OptionsTests;

public sealed class WhenEqualsOptionsIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Type.Options();
        Type.Options right = new Type.Options().WithSnippets(Snippet.Options.Default.WithWhitespace("  "));

        // Act
        bool result = left.Equals(right);

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
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Type.Options();
        Type.Options? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}