namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using MooVC.Syntax.CSharp.Elements.SymbolTests;
using MooVC.Syntax.CSharp.Generics.Constraints;

public sealed class WhenWithConstraintsIsCalled
{
    private const string Name = "TValue";

    [Fact]
    public void GivenAdditionalConstraintsThenReturnsNewInstanceWithCombinedValues()
    {
        // Arrange
        var originalConstraint = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) };

        var original = new Parameter
        {
            Name = new Identifier(Name),
            Constraints = [originalConstraint],
        };

        var additionalConstraint = new Constraint { New = New.Required };

        // Act
        Parameter result = original.WithConstraints(additionalConstraint);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(original.Name);
        result.Constraints.ShouldBe(new[] { originalConstraint, additionalConstraint });
        original.Constraints.ShouldBe(new[] { originalConstraint });
    }
}