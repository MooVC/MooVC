namespace MooVC.Syntax.CSharp.GenericTests;

using MooVC.Syntax.CSharp.SymbolTests;

public sealed class WhenGetHashCodeIsCalled
{
    private const string DefaultName = "TValue";

    [Test]
    public async Task GivenDifferentArgumentsThenReturnDifferentHashes()
    {
        // Arrange
        Generic first = Create();
        Generic second = Create(name: DefaultName + "Alternative");

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenMatchingArgumentsThenReturnSameHash()
    {
        // Arrange
        Generic first = Create();
        Generic second = Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }

    private static Generic Create(string name = DefaultName)
    {
        return new Generic
        {
            Name = new Name(name),
            Constraints = [new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) }],
        };
    }
}