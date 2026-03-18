namespace MooVC.Syntax.Attributes.Project.TargetTests;

using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Returns).IsEqualTo(updated);
        await Assert.That(result.Outputs).IsEqualTo(original.Outputs);
        await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}