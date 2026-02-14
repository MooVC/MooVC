namespace Mu.Modelling.UnitTests;

using System.Collections.Immutable;
using System.Linq;

public sealed class WhenSeenAsIsCalled
{
    [Fact]
    public void GivenViewThenReturnsUpdatedInstance()
    {
        // Arrange
        View existing = ModellingTestData.CreateView();
        View additional = ModellingTestData.CreateView(name: ModellingTestData.CreateAlternateName());
        Unit original = ModellingTestData.CreateUnit(views: ImmutableArray.Create(existing));

        // Act
        Unit result = original.SeenAs(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Views.ShouldBe(original.Views.Concat([additional]));
        result.Name.ShouldBe(original.Name);
    }
}