namespace Mu.Modelling.UnitTests;

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
        Unit original = ModellingTestData.CreateUnit(attributes: ImmutableArray.Create(existing));

        // Act
        Unit result = original.AttributedWith(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Attributes.ShouldBe(original.Attributes.Concat([additional]));
        result.Name.ShouldBe(original.Name);
    }
}