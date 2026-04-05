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
            Alias = new(Alias),
            Qualifier = new(["MooVC", "Syntax"]),
        };

        var second = new Directive
        {
            Alias = new(Alias + "Alternative"),
            Qualifier = new(["MooVC", "Syntax"]),
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
            Alias = new(Alias),
            Qualifier = new(["MooVC", "Syntax"]),
        };

        var second = new Directive
        {
            Alias = new(Alias),
            Qualifier = new(["MooVC", "Syntax"]),
        };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}