namespace Mu.Modelling.FeatureTests;

using System.Linq;

public sealed class WhenUsingIsCalled
{
    [Fact]
    public void GivenParameterThenReturnsUpdatedInstance()
    {
        // Arrange
        Parameter existing = ModellingTestData.CreateParameter();
        Parameter additional = ModellingTestData.CreateParameter(name: ModellingTestData.CreateAlternateName());
        Feature original = ModellingTestData.CreateFeature(parameters: existing);

        // Act
        Feature result = original.Using(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Parameters.ShouldBe(original.Parameters.Concat([additional]));
        result.Name.ShouldBe(original.Name);
    }
}