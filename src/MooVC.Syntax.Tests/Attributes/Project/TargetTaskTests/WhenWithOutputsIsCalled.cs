namespace MooVC.Syntax.Attributes.Project.TargetTaskTests;

using System.Linq;
using MooVC.Syntax.Elements;

public sealed class WhenWithOutputsIsCalled
{
    [Fact]
    public void GivenOutputsThenReturnsUpdatedInstance()
    {
        // Arrange
        Output existing = TargetTaskTestsData.CreateOutput();

        var additional = new Output
        {
            ItemName = "Other",
            PropertyName = "Property",
            TaskParameter = "Parameter",
        };

        TargetTask original = TargetTaskTestsData.Create(output: existing);

        // Act
        TargetTask result = original.WithOutputs(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Outputs.ShouldBe(original.Outputs.Concat([additional]));
        result.Name.ShouldBe(original.Name);
        result.Condition.ShouldBe(original.Condition);
    }
}