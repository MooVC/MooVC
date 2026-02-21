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
            Add = "value",
        };

        var second = new Event.Methods
        {
            Add = "value",
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
            Add = "value",
        };

        var second = new Event.Methods
        {
            Remove = "value",
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
            Add = "value",
        };

        var second = new Event.Methods
        {
            Add = "alternative",
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
            Remove = "value",
        };

        var second = new Event.Methods
        {
            Remove = "alternative",
        };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}