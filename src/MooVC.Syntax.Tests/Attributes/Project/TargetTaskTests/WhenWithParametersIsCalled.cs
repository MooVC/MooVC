namespace MooVC.Syntax.Attributes.Project.TargetTaskTests;

using System.Linq;
using MooVC.Syntax.Elements;

public sealed class WhenWithParametersIsCalled
{
    [Fact]
    public void GivenParametersThenReturnsUpdatedInstance()
    {
        // Arrange
        TaskParameter existing = TargetTaskTestsData.CreateParameter();

        var additional = new TaskParameter
        {
            Name = new Identifier("Other"),
            Value = Snippet.From("Value"),
        };

        TargetTask original = TargetTaskTestsData.Create(parameter: existing);

        // Act
        TargetTask result = original.WithParameters(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Parameters.ShouldBe(original.Parameters.Concat([additional]));
        result.Name.ShouldBe(original.Name);
        result.Condition.ShouldBe(original.Condition);
    }
}