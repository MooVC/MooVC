namespace Mu.Modelling.AttributeTests;

using MooVC.Syntax.Elements;
using ModellingAttribute = Mu.Modelling.Attribute;

public sealed class WhenDefaultedToIsCalled
{
    private const string UpdatedDefaultValue = "Updated";

    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        ModellingAttribute original = ModellingTestData.CreateAttribute();
        Snippet updated = Snippet.From(UpdatedDefaultValue);

        // Act
        ModellingAttribute result = original.DefaultedTo(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Default.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
        result.Type.ShouldBe(original.Type);
    }
}