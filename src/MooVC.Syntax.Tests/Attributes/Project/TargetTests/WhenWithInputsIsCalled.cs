namespace MooVC.Syntax.Attributes.Project.TargetTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithInputsIsCalled
{
    private const string UpdatedInputs = "UpdatedInputs";

    [Test]
    public async Task GivenInputsThenReturnsUpdatedInstance()
    {
        // Arrange
        Target original = TargetTestsData.Create(task: TargetTestsData.CreateTask());
        var updated = Snippet.From(UpdatedInputs);

        // Act
        Target result = original.WithInputs(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Inputs).IsEqualTo(updated);
        await Assert.That(result.Condition).IsEqualTo(original.Condition);
        await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}