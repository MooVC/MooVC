namespace MooVC.Syntax.Attributes.Project.OutputTests;

using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.PropertyName).IsEqualTo(updated);
        await Assert.That(result.ItemName).IsEqualTo(original.ItemName);
        await Assert.That(result.Condition).IsEqualTo(original.Condition);
    }
}