namespace MooVC.Syntax.Attributes.Project.TargetTests;

public sealed class WhenKeepDuplicateOutputsIsCalled
{
    [Test]
    public async Task GivenKeepDuplicateOutputsThenReturnsUpdatedInstance()
    {
        // Arrange
        Target original = TargetTestsData.Create(task: TargetTestsData.CreateTask());
        const bool updated = true;

        // Act
        Target result = original.KeepDuplicateOutputs(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.KeepDuplicateOutputs).IsEqualTo(updated);
        await Assert.That(result.Outputs).IsEqualTo(original.Outputs);
        await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}