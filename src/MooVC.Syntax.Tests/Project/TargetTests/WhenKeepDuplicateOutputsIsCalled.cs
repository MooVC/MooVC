namespace MooVC.Syntax.Project.TargetTests;

public sealed class WhenKeepDuplicateOutputsIsCalled
{
    [Test]
    public async Task GivenKeepDuplicateOutputsThenReturnsUpdatedInstance()
    {
        // Arrange
        Target original = TargetTestsData.Create(task: TargetTestsData.CreateTask());

        // Act
        Target result = original.KeepDuplicateOutputs(true);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.KeepDuplicateOutputs).IsTrue();
        _ = await Assert.That(result.Outputs).IsEqualTo(original.Outputs);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}