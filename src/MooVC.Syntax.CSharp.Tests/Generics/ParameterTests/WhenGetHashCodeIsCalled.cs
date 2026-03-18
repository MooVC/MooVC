namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using MooVC.Syntax.CSharp.Elements.SymbolTests;
using MooVC.Syntax.CSharp.Generics.Constraints;
using MooVC.Syntax.Elements;

public sealed class WhenGetHashCodeIsCalled
{
    private const string DefaultName = "TValue";

    [Test]
    public async Task GivenMatchingParametersThenReturnSameHash()
    {
        // Arrange
        Parameter first = Create();
        Parameter second = Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        await Assert.That(firstHash).IsEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentParametersThenReturnDifferentHashes()
    {
        // Arrange
        Parameter first = Create();
        Parameter second = Create(name: DefaultName + "Alternative");

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    private static Parameter Create(string name = DefaultName)
    {
        return new Parameter
        {
            Name = new Name(name),
            Constraints = [new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) }],
        };
    }
}