namespace MooVC.Syntax.Attributes.Project.TargetTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithOutputsIsCalled
{
    private const string UpdatedOutputs = "UpdatedOutputs";

    [Test]
    public async Task GivenOutputsThenReturnsUpdatedInstance()
    {
        // Arrange
        Target original = TargetTestsData.Create(task: TargetTestsData.CreateTask());
        var updated = Snippet.From(UpdatedOutputs);

        // Act
        Target result = original.WithOutputs(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Outputs).IsEqualTo(updated);
        _ = await Assert.That(result.Returns).IsEqualTo(original.Returns);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}