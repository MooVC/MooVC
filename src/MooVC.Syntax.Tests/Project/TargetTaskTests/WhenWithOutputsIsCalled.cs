namespace MooVC.Syntax.Project.TargetTaskTests;

public sealed class WhenWithOutputsIsCalled
{
    [Test]
    public async Task GivenOutputsThenReturnsUpdatedInstance()
    {
        // Arrange
        Output existing = TargetTaskTestsData.CreateOutput();

        var additional = new Output
        {
            ItemName = new("Other"),
            PropertyName = new("Property"),
            TaskParameter = new("Parameter"),
        };

        TargetTask original = TargetTaskTestsData.Create(output: existing);

        // Act
        TargetTask result = original.WithOutputs(additional);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Outputs).IsEquivalentTo([.. original.Outputs, additional]);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
    }
}