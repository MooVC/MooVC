namespace MooVC.Syntax.Attributes.Project.PropertyGroupTests;

using System.Linq;
using MooVC.Syntax.Elements;

public sealed class WhenWithPropertiesIsCalled
{
    [Fact]
    public void GivenPropertiesThenReturnsUpdatedInstance()
    {
        // Arrange
        Property existing = PropertyGroupTestsData.CreateProperty();

        var additional = new Property
        {
            Condition = Snippet.From("Extra"),
            Name = new Name("Other"),
            Value = Snippet.From("Value"),
        };

        PropertyGroup original = PropertyGroupTestsData.Create(property: existing);

        // Act
        PropertyGroup result = original.WithProperties(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Properties.ShouldBe(original.Properties.Concat([additional]));
        result.Condition.ShouldBe(original.Condition);
        result.Label.ShouldBe(original.Label);
    }
}