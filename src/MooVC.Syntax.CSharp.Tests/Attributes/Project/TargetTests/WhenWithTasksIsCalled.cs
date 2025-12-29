namespace MooVC.Syntax.CSharp.Attributes.Project.TargetTests;

using System.Linq;
using MooVC.Syntax.CSharp.Elements;

public sealed class WhenWithTasksIsCalled
{
    [Fact]
    public void GivenTasksThenReturnsUpdatedInstance()
    {
        // Arrange
        TargetTask existing = TargetTestsData.CreateTask();
        TargetTask additional = new TargetTask { Name = new Identifier("Other") };
        Target original = TargetTestsData.Create(task: existing);

        // Act
        Target result = original.WithTasks(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Tasks.ShouldBe(original.Tasks.Concat(new[] { additional }));
        result.Name.ShouldBe(original.Name);
        result.Label.ShouldBe(original.Label);
    }
}