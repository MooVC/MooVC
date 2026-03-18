namespace MooVC.Syntax.CSharp.GenericTests;

using MooVC.Syntax.CSharp.SymbolTests;

public sealed class WhenNamedIsCalled
{
    private const string DefaultName = "TValue";
    private const string NewName = "TOther";

    [Test]
    public async Task GivenValueThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        var constraint = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) };

        var original = new Generic
        {
            Name = new Name(DefaultName),
            Constraints = [constraint],
        };

        // Act
        Generic result = original.Named(NewName);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Name).IsEqualTo(new Name(NewName));
        _ = await Assert.That(result.Constraints).IsEqualTo(original.Constraints);
        _ = await Assert.That(original.Name).IsEqualTo(new Name(DefaultName));
    }
}