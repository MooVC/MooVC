namespace MooVC.Syntax.Attributes.Project.PropertyGroupTests;

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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Properties).IsEquivalentTo([.. original.Properties, additional]);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
        _ = await Assert.That(result.Label).IsEqualTo(original.Label);
    }
}