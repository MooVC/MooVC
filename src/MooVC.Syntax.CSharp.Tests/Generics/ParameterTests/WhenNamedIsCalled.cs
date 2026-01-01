namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using MooVC.Syntax.CSharp.Elements.SymbolTests;
using MooVC.Syntax.CSharp.Generics.Constraints;

public sealed class WhenNamedIsCalled
{
    private const string DefaultName = "TValue";
    private const string NewName = "TOther";

    [Fact]
    public void GivenValueThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        var constraint = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) };

        var original = new Parameter
        {
            Name = new Identifier(DefaultName),
            Constraints = [constraint],
        };

        // Act
        Parameter result = original.Named(NewName);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(new Identifier(NewName));
        result.Constraints.ShouldBe(original.Constraints);
        original.Name.ShouldBe(new Identifier(DefaultName));
    }
}