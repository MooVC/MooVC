namespace Mu.Modelling.UnitTests;

using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    private const string UpdatedNameValue = "Updated";

    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Unit original = ModellingTestData.CreateUnit();
        Identifier updated = ModellingTestData.CreateIdentifier(UpdatedNameValue);

        // Act
        Unit result = original.Named(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Attributes.ShouldBe(original.Attributes);
        result.Features.ShouldBe(original.Features);
        result.Views.ShouldBe(original.Views);
    }
}