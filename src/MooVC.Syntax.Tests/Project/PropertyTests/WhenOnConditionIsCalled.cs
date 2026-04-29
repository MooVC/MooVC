namespace MooVC.Syntax.Project.PropertyTests;

public sealed class WhenOnConditionIsCalled
{
    private const string UpdatedCondition = "UpdatedCondition";

    [Test]
    public async Task GivenConditionThenReturnsUpdatedInstance()
    {
        // Arrange
        Property original = PropertyTestsData.Create();
        var updated = Snippet.From(UpdatedCondition);

        // Act
        Property result = original.OnCondition(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Condition).IsEqualTo(updated);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Value).IsEqualTo(original.Value);
    }
}