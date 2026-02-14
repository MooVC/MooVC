namespace Mu.Modelling.ModelTests;

using System.Linq;

public sealed class WhenWithAreaIsCalled
{
    [Fact]
    public void GivenAreaThenReturnsUpdatedInstance()
    {
        // Arrange
        Area existing = ModellingTestData.CreateArea();
        Area additional = ModellingTestData.CreateArea(name: ModellingTestData.CreateAlternateName());
        Model original = ModellingTestData.CreateModel(areas: existing);

        // Act
        Model result = original.WithArea(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Areas.ShouldBe(original.Areas.Concat([additional]));
        result.Name.ShouldBe(original.Name);
    }
}