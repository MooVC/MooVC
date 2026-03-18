namespace MooVC.Syntax.Attributes.Project.TargetTests;

using System.Linq;
using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Tasks).IsEqualTo(original.Tasks.Concat([additional]));
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Label).IsEqualTo(original.Label);
    }
}