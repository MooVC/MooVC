namespace Mu.Modelling.ViewTests;

using System.Collections.Immutable;
using System.Linq;
using ModellingAttribute = Mu.Modelling.Attribute;

public sealed class WhenAttributedWithIsCalled
{
    [Fact]
    public void GivenAttributeThenReturnsUpdatedInstance()
    {
        // Arrange
        ModellingAttribute existing = ModellingTestData.CreateAttribute();
        ModellingAttribute additional = ModellingTestData.CreateAttribute(name: ModellingTestData.CreateAlternateName());
        View original = ModellingTestData.CreateView(attributes: ImmutableArray.Create(existing));

        // Act
        View result = original.AttributedWith(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Attributes.ShouldBe(original.Attributes.Concat([additional]));
        result.Name.ShouldBe(original.Name);
    }
}