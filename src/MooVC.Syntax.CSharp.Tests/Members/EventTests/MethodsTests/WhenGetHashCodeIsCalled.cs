namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEquivalentValuesThenHashesMatch()
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
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentValuesThenHashesDiffer()
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
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentAddValuesThenHashesDiffer()
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
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentRemoveValuesThenHashesDiffer()
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
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }
}