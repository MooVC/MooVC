namespace Mu.Modelling.UnitTests;

using System.Collections.Immutable;
using System.Linq;

public sealed class WhenFeaturingIsCalled
{
    [Fact]
    public void GivenFeatureThenReturnsUpdatedInstance()
    {
        // Arrange
        Feature existing = ModellingTestData.CreateFeature();
        Feature additional = ModellingTestData.CreateFeature(name: ModellingTestData.CreateAlternateName());
        Unit original = ModellingTestData.CreateUnit(features: ImmutableArray.Create(existing));

        // Act
        Unit result = original.Featuring(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Features.ShouldBe(original.Features.Concat([additional]));
        result.Name.ShouldBe(original.Name);
    }
}