namespace MooVC.Syntax.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenGetHashCodeIsCalled
{
    private static readonly ImmutableArray<string> _different = ["Gamma"];
    private static readonly ImmutableArray<string> _same = ["Alpha", "Beta"];

    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        var first = new Snippet(_same);
        var second = new Snippet(_different);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenMatchingValuesThenReturnsSameHash()
    {
        // Arrange
        var first = new Snippet(_same);
        var second = new Snippet(_same);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}