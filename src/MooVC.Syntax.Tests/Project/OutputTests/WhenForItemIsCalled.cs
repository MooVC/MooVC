namespace MooVC.Syntax.Project.OutputTests;

public sealed class WhenForItemIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Output original = OutputTestsData.Create();
        var updated = new Name("Other");

        // Act
        Output result = original.ForItem(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.ItemName).IsEqualTo(updated);
        _ = await Assert.That(result.PropertyName).IsEqualTo(original.PropertyName);
        _ = await Assert.That(result.TaskParameter).IsEqualTo(original.TaskParameter);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
    }
}