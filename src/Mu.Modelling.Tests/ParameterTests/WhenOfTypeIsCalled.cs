namespace Mu.Modelling.ParameterTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenOfTypeIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Parameter original = ModellingTestData.CreateParameter();
        Symbol updated = ModellingTestData.CreateSymbol(typeof(Guid));

        // Act
        Parameter result = original.OfType(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Type.ShouldBe(updated);
        result.Default.ShouldBe(original.Default);
        result.Name.ShouldBe(original.Name);
    }
}