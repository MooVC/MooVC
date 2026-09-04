namespace MooVC.Syntax.Project.TargetTests;

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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Inputs).IsEqualTo(updated);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}