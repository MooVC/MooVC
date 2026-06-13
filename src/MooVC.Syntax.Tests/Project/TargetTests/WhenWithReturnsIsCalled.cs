namespace MooVC.Syntax.Project.TargetTests;

public sealed class WhenWithReturnsIsCalled
{
    private const string UpdatedReturns = "UpdatedReturns";

    [Test]
    public async Task GivenReturnsThenReturnsUpdatedInstance()
    {
        // Arrange
        Target original = TargetTestsData.Create(task: TargetTestsData.CreateTask());
        var updated = Snippet.From(UpdatedReturns);

        // Act
        Target result = original.WithReturns(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Returns).IsEqualTo(updated);
        _ = await Assert.That(result.Outputs).IsEqualTo(original.Outputs);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}