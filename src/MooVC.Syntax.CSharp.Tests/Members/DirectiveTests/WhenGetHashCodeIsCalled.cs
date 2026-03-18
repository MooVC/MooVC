namespace MooVC.Syntax.CSharp.Members.DirectiveTests;

using MooVC.Syntax.Elements;

public sealed class WhenGetHashCodeIsCalled
{
    private const string Alias = "Alias";

    [Test]
    public void GivenMatchingDirectivesThenReturnSameHash()
    {
        // Arrange
        var first = new Directive
        {
            Alias = new Name(Alias),
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };

        var second = new Directive
        {
            Alias = new Name(Alias),
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Test]
    public void GivenDifferentDirectivesThenReturnDifferentHashes()
    {
        // Arrange
        var first = new Directive
        {
            Alias = new Name(Alias),
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };

        var second = new Directive
        {
            Alias = new Name(Alias + "Alternative"),
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}