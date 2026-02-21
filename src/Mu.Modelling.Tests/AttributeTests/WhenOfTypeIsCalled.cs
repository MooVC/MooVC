namespace Mu.Modelling.AttributeTests;

using MooVC.Syntax.CSharp.Elements;
using ModellingAttribute = Mu.Modelling.Attribute;

public sealed class WhenOfTypeIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        ModellingAttribute original = ModellingTestData.CreateAttribute();
        Symbol updated = ModellingTestData.CreateSymbol(typeof(Guid));

        // Act
        ModellingAttribute result = original.OfType(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Type.ShouldBe(updated);
        result.Default.ShouldBe(original.Default);
        result.Name.ShouldBe(original.Name);
    }
}