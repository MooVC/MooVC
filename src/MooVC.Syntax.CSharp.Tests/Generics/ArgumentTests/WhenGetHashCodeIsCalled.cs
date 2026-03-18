namespace MooVC.Syntax.CSharp.Generics.ArgumentTests;

using MooVC.Syntax.CSharp.SymbolTests;

public sealed class WhenGetHashCodeIsCalled
{
    private const string DefaultName = "TValue";

    [Test]
    public async Task GivenMatchingArgumentsThenReturnSameHash()
    {
        // Arrange
        Argument first = Create();
        Argument second = Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentArgumentsThenReturnDifferentHashes()
    {
        // Arrange
        Argument first = Create();
        Argument second = Create(name: DefaultName + "Alternative");

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    private static Argument Create(string name = DefaultName)
    {
        return new Argument
        {
            Name = new Name(name),
            Constraints = [new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) }],
        };
    }
}