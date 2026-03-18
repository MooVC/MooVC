namespace MooVC.Syntax.Attributes.Project.OutputTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithTaskParameterIsCalled
{
    [Test]
    public async Task GivenTaskParameterThenReturnsUpdatedInstance()
    {
        // Arrange
        Output original = OutputTestsData.Create();
        var updated = new Name("Other");

        // Act
        Output result = original.WithTaskParameter(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.TaskParameter).IsEqualTo(updated);
        await Assert.That(result.ItemName).IsEqualTo(original.ItemName);
        await Assert.That(result.PropertyName).IsEqualTo(original.PropertyName);
    }
}