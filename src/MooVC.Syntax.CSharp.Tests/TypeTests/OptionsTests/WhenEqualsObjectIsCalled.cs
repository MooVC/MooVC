namespace MooVC.Syntax.CSharp.TypeTests.OptionsTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenEquivalentInstanceThenReturnsTrue()
    {
        // Arrange
        var subject = new Type.Options();
        object other = new Type.Options();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNonEquivalentInstanceThenReturnsFalse()
    {
        // Arrange
        var subject = new Type.Options();
        object other = new Type.Options().WithSnippets(Snippet.Options.Default.WithWhitespace("  "));

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        var subject = new Type.Options();
        object other = new object();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}