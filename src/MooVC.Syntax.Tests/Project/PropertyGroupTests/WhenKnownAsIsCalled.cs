namespace MooVC.Syntax.Project.PropertyGroupTests;

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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Label).IsEqualTo(updated);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
        _ = await Assert.That(result.Properties).IsEqualTo(original.Properties);
    }
}