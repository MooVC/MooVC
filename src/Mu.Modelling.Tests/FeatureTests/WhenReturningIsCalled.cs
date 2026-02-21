namespace Mu.Modelling.FeatureTests;

using System.Collections.Immutable;

public sealed class WhenReturningIsCalled
{
    [Fact]
    public void GivenResultThenReturnsUpdatedInstance()
    {
        // Arrange
        Result existing = ModellingTestData.CreateResult();
        Result additional = ModellingTestData.CreateResult(name: ModellingTestData.CreateAlternateName());
        Feature original = ModellingTestData.CreateFeature();

        // Act
        Feature result = original.Returning(existing).Returning(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Results.ShouldBe(ImmutableArray.Create(existing, additional));
        result.Name.ShouldBe(original.Name);
    }
}