namespace Mu.Modelling.ViewTests;

using System.Collections.Immutable;
using System.Linq;
using MooVC.Syntax.Elements;

public sealed class WhenRenderedOnIsCalled
{
    private const string SecondaryQualifierValue = "Mu.Modelling.Secondary";

    [Fact]
    public void GivenQualifierThenReturnsUpdatedInstance()
    {
        // Arrange
        Qualifier existing = ModellingTestData.CreateQualifier();
        Qualifier additional = ModellingTestData.CreateQualifier(SecondaryQualifierValue);
        View original = ModellingTestData.CreateView(facts: ImmutableArray.Create(existing));

        // Act
        View result = original.RenderedOn(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Facts.ShouldBe(original.Facts.Concat([additional]));
        result.Name.ShouldBe(original.Name);
    }
}