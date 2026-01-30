namespace Mu.Modelling.FeatureTests;

public sealed class WhenOfTypeIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Feature original = ModellingTestData.CreateFeature();

        // Act
        Feature result = original.OfType(Feature.Kind.NonMutational);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Type.ShouldBe(Feature.Kind.NonMutational);
        result.Name.ShouldBe(original.Name);
    }
}