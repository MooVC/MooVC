namespace MooVC.Syntax.Attributes.Project.OutputTests;

using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.ItemName).IsEqualTo(updated);
        await Assert.That(result.PropertyName).IsEqualTo(original.PropertyName);
        await Assert.That(result.TaskParameter).IsEqualTo(original.TaskParameter);
        await Assert.That(result.Condition).IsEqualTo(original.Condition);
    }
}