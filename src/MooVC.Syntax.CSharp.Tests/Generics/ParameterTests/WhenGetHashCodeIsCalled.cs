namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using MooVC.Syntax.CSharp.Elements.SymbolTests;
using MooVC.Syntax.CSharp.Generics.Constraints;

public sealed class WhenGetHashCodeIsCalled
{
    private const string DefaultName = "TValue";

    [Fact]
    public void GivenMatchingParametersThenReturnSameHash()
    {
        // Arrange
        Parameter first = Create();
        Parameter second = Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Fact]
    public void GivenDifferentParametersThenReturnDifferentHashes()
    {
        // Arrange
        Parameter first = Create();
        Parameter second = Create(name: DefaultName + "Alternative");

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }

    private static Parameter Create(string name = DefaultName)
    {
        return new Parameter
        {
            Name = new Identifier(name),
            Constraints = [new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) }],
        };
    }
}