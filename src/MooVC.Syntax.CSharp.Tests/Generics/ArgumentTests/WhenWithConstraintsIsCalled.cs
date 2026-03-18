namespace MooVC.Syntax.CSharp.Generics.ArgumentTests;

using MooVC.Syntax.CSharp.SymbolTests;

public sealed class WhenWithConstraintsIsCalled
{
    private const string Name = "TValue";

    [Test]
    public async Task GivenAdditionalConstraintsThenReturnsNewInstanceWithCombinedValues()
    {
        // Arrange
        var originalConstraint = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) };

        var original = new Generic
        {
            Name = new Name(Name),
            Constraints = [originalConstraint],
        };

        var additionalConstraint = new Constraint { New = New.Required };

        // Act
        Generic result = original.WithConstraints(additionalConstraint);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Constraints).IsEquivalentTo([originalConstraint, additionalConstraint]);
        _ = await Assert.That(original.Constraints).IsEquivalentTo([originalConstraint]);
    }
}