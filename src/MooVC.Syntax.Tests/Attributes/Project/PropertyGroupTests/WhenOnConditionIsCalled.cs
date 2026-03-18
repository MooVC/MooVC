namespace MooVC.Syntax.Attributes.Project.PropertyGroupTests;

using MooVC.Syntax.Elements;

public sealed class WhenOnConditionIsCalled
{
    private const string UpdatedCondition = "UpdatedCondition";

    [Test]
    public async Task GivenConditionThenReturnsUpdatedInstance()
    {
        // Arrange
        PropertyGroup original = PropertyGroupTestsData.Create(property: PropertyGroupTestsData.CreateProperty());
        var updated = Snippet.From(UpdatedCondition);

        // Act
        PropertyGroup result = original.OnCondition(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Condition).IsEqualTo(updated);
        await Assert.That(result.Label).IsEqualTo(original.Label);
        await Assert.That(result.Properties).IsEqualTo(original.Properties);
    }
}