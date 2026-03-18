namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using MooVC.Syntax.CSharp.Elements.SymbolTests;
using MooVC.Syntax.CSharp.Generics.Constraints;
using MooVC.Syntax.Elements;

public sealed class WhenWithConstraintsIsCalled
{
    private const string Name = "TValue";

    [Test]
    public async Task GivenAdditionalConstraintsThenReturnsNewInstanceWithCombinedValues()
    {
        // Arrange
        var originalConstraint = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) };

        var original = new Parameter
        {
            Name = new Name(Name),
            Constraints = [originalConstraint],
        };

        var additionalConstraint = new Constraint { New = New.Required };

        // Act
        Parameter result = original.WithConstraints(additionalConstraint);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Constraints).IsEqualTo(new[] { originalConstraint, additionalConstraint });
        _ = await Assert.That(original.Constraints).IsEqualTo(new[] { originalConstraint });
    }
}