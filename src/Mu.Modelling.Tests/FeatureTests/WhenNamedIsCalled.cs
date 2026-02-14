namespace Mu.Modelling.FeatureTests;

using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    private const string UpdatedNameValue = "Updated";

    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Feature original = ModellingTestData.CreateFeature();
        Identifier updated = ModellingTestData.CreateIdentifier(UpdatedNameValue);

        // Act
        Feature result = original.Named(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Parameters.ShouldBe(original.Parameters);
        result.Results.ShouldBe(original.Results);
        result.Type.ShouldBe(original.Type);
    }
}