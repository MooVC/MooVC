namespace MooVC.Syntax.CSharp.DirectiveTests;

public sealed class WhenGetHashCodeIsCalled
{
    private const string Alias = "Alias";

    [Test]
    public async Task GivenDifferentDirectivesThenReturnDifferentHashes()
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
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenMatchingDirectivesThenReturnSameHash()
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
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}