namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

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
}
