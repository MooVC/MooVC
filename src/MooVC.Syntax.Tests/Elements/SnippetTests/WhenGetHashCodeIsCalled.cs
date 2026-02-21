namespace MooVC.Syntax.Elements.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenGetHashCodeIsCalled
{
    private static readonly ImmutableArray<string> different = ["Gamma"];
    private static readonly ImmutableArray<string> same = ["Alpha", "Beta"];

    [Fact]
    public void GivenMatchingValuesThenReturnsSameHash()
    {
        // Arrange
        var first = new Snippet(same);
        var second = new Snippet(same);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        var first = new Snippet(same);
        var second = new Snippet(different);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}