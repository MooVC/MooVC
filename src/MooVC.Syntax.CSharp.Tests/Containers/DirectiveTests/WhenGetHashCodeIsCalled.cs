namespace MooVC.Syntax.CSharp.Containers.DirectiveTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenGetHashCodeIsCalled
{
    private const string Alias = "Alias";

    [Fact]
    public void GivenMatchingDirectivesThenReturnSameHash()
    {
        // Arrange
        var first = new Directive
        {
            Alias = new Identifier(Alias),
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };

        var second = new Directive
        {
            Alias = new Identifier(Alias),
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Fact]
    public void GivenDifferentDirectivesThenReturnDifferentHashes()
    {
        // Arrange
        var first = new Directive
        {
            Alias = new Identifier(Alias),
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };

        var second = new Directive
        {
            Alias = new Identifier(Alias + "Alternative"),
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}