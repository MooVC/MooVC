namespace MooVC.Syntax.Attributes.Project.PropertyGroupTests;

using System.Linq;
using MooVC.Syntax.Elements;

public sealed class WhenWithPropertiesIsCalled
{
    [Test]
    public async Task GivenPropertiesThenReturnsUpdatedInstance()
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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Properties).IsEqualTo(original.Properties.Concat([additional]));
        await Assert.That(result.Condition).IsEqualTo(original.Condition);
        await Assert.That(result.Label).IsEqualTo(original.Label);
    }
}