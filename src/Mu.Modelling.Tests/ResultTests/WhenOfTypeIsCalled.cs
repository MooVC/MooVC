namespace Mu.Modelling.ResultTests;

using Symbol = MooVC.Syntax.CSharp.Elements.Symbol;

public sealed class WhenOfTypeIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Result original = ModellingTestData.CreateResult();
        Symbol updated = ModellingTestData.CreateSymbol(typeof(Guid));

        // Act
        Result result = original.OfType(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Type.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
    }
}