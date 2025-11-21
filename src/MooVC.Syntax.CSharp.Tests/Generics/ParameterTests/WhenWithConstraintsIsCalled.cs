namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using MooVC.Syntax.CSharp.Generics.Constraints;
using MooVC.Syntax.CSharp.Members.SymbolTests;

public sealed class WhenWithConstraintsIsCalled
{
    private const string Name = "TValue";

    [Fact]
    public void GivenAdditionalConstraintsThenReturnsNewInstanceWithCombinedValues()
    {
        // Arrange
        Constraint originalConstraint = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) };
        Parameter original = new Parameter
        {
            Name = new Identifier(Name),
            Constraints = [originalConstraint],
        };

        Constraint additionalConstraint = new Constraint { New = New.Required };

        // Act
        Parameter result = original.WithConstraints(additionalConstraint);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(original.Name);
        result.Constraints.ShouldBe(new[] { originalConstraint, additionalConstraint });
        original.Constraints.ShouldBe(new[] { originalConstraint });
    }
}
