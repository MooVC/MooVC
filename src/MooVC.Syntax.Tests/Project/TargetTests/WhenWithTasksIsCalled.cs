namespace MooVC.Syntax.Project.TargetTests;

public sealed class WhenWithTasksIsCalled
{
    [Test]
    public async Task GivenTasksThenReturnsUpdatedInstance()
    {
        // Arrange
        TargetTask existing = TargetTestsData.CreateTask();
        var additional = new TargetTask { Name = new Name("Other") };
        Target original = TargetTestsData.Create(task: existing);

        // Act
        Target result = original.WithTasks(additional);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Tasks).IsEquivalentTo([.. original.Tasks, additional]);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Label).IsEqualTo(original.Label);
    }
}