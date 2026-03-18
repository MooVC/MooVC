namespace MooVC.Syntax.Attributes.Project.TargetTaskTests;

using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    private const string UpdatedName = "UpdatedName";

    [Test]
    public async Task GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        TargetTask original = TargetTaskTestsData.Create(output: TargetTaskTestsData.CreateOutput());
        var updated = new Name(UpdatedName);

        // Act
        TargetTask result = original.Named(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Name).IsEqualTo(updated);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
        _ = await Assert.That(result.ContinueOnError).IsEqualTo(original.ContinueOnError);
    }
}