namespace MooVC.Syntax.CSharp.Members.IndexerTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEquivalentValuesThenHashesMatch()
    {
        // Arrange
        var first = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        var second = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Fact]
    public void GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        var first = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        var second = new Indexer.Methods
        {
            Set = Snippet.From("value"),
        };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }

    [Fact]
    public void GivenDifferentGetValuesThenHashesDiffer()
    {
        // Arrange
        var first = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        var second = new Indexer.Methods
        {
            Get = Snippet.From("alternative"),
        };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }

    [Fact]
    public void GivenDifferentSetValuesThenHashesDiffer()
    {
        // Arrange
        var first = new Indexer.Methods
        {
            Set = Snippet.From("value"),
        };

        var second = new Indexer.Methods
        {
            Set = Snippet.From("alternative"),
        };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}