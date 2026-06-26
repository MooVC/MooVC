namespace MooVC.Syntax.Project.OutputTests;

public sealed class WhenForPropertyIsCalled
{
    [Test]
    public async Task GivenPropertyNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Output original = OutputTestsData.Create();
        var updated = new Name("Other");

        // Act
        Output result = original.ForProperty(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.PropertyName).IsEqualTo(updated);
        _ = await Assert.That(result.ItemName).IsEqualTo(original.ItemName);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
    }
}