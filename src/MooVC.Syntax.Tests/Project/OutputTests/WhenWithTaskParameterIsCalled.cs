namespace MooVC.Syntax.Project.OutputTests;

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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.TaskParameter).IsEqualTo(updated);
        _ = await Assert.That(result.ItemName).IsEqualTo(original.ItemName);
        _ = await Assert.That(result.PropertyName).IsEqualTo(original.PropertyName);
    }
}