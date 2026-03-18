namespace MooVC.Syntax.Attributes.Project.TargetTaskTests;

using System.Linq;
using MooVC.Syntax.Elements;

public sealed class WhenWithOutputsIsCalled
{
    [Test]
    public async Task GivenOutputsThenReturnsUpdatedInstance()
    {
        // Arrange
        Output existing = TargetTaskTestsData.CreateOutput();

        var additional = new Output
        {
            ItemName = new Name("Other"),
            PropertyName = new Name("Property"),
            TaskParameter = new Name("Parameter"),
        };

        TargetTask original = TargetTaskTestsData.Create(output: existing);

        // Act
        TargetTask result = original.WithOutputs(additional);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Outputs).IsEqualTo(original.Outputs.Concat([additional]));
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Condition).IsEqualTo(original.Condition);
    }
}