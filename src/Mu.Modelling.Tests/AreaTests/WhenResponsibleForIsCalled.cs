namespace Mu.Modelling.AreaTests;

using System.Linq;

public sealed class WhenResponsibleForIsCalled
{
    [Fact]
    public void GivenUnitThenReturnsUpdatedInstance()
    {
        // Arrange
        Unit existing = ModellingTestData.CreateUnit();
        Unit additional = ModellingTestData.CreateUnit(ModellingTestData.CreateAlternateName());
        Area original = ModellingTestData.CreateArea(units: existing);

        // Act
        Area result = original.ResponsibleFor(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Units.ShouldBe(original.Units.Concat([additional]));
        result.Name.ShouldBe(original.Name);
    }
}