namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using MooVC.Syntax.CSharp.Elements.SymbolTests;
using MooVC.Syntax.CSharp.Generics.Constraints;
using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    private const string DefaultName = "TValue";
    private const string NewName = "TOther";

    [Test]
    public async Task GivenValueThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        var constraint = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) };

        var original = new Parameter
        {
            Name = new Name(DefaultName),
            Constraints = [constraint],
        };

        // Act
        Parameter result = original.Named(NewName);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Name).IsEqualTo(new Name(NewName));
        _ = await Assert.That(result.Constraints).IsEqualTo(original.Constraints);
        _ = await Assert.That(original.Name).IsEqualTo(new Name(DefaultName));
    }
}