namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEquivalentValuesThenHashesMatch()
    {
        // Arrange
        var first = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        var second = new Event.Methods
        {
            Add = Snippet.From("value"),
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
        var first = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        var second = new Event.Methods
        {
            Remove = Snippet.From("value"),
        };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }

    [Fact]
    public void GivenDifferentAddValuesThenHashesDiffer()
    {
        // Arrange
        var first = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        var second = new Event.Methods
        {
            Add = Snippet.From("alternative"),
        };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }

    [Fact]
    public void GivenDifferentRemoveValuesThenHashesDiffer()
    {
        // Arrange
        var first = new Event.Methods
        {
            Remove = Snippet.From("value"),
        };

        var second = new Event.Methods
        {
            Remove = Snippet.From("alternative"),
        };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}