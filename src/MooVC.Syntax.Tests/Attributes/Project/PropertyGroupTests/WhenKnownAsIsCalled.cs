namespace MooVC.Syntax.Attributes.Project.PropertyGroupTests;

using MooVC.Syntax.Elements;

public sealed class WhenKnownAsIsCalled
{
    private const string UpdatedLabel = "UpdatedLabel";

    [Test]
    public async Task GivenLabelThenReturnsUpdatedInstance()
    {
        // Arrange
        PropertyGroup original = PropertyGroupTestsData.Create(property: PropertyGroupTestsData.CreateProperty());
        var updated = Snippet.From(UpdatedLabel);

        // Act
        PropertyGroup result = original.KnownAs(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Label).IsEqualTo(updated);
        await Assert.That(result.Condition).IsEqualTo(original.Condition);
        await Assert.That(result.Properties).IsEqualTo(original.Properties);
    }
}