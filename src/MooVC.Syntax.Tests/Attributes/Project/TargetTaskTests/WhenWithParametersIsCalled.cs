namespace MooVC.Syntax.Attributes.Project.TargetTaskTests;

using System.Linq;
using MooVC.Syntax.Elements;

public sealed class WhenWithParametersIsCalled
{
    [Test]
    public async Task GivenParametersThenReturnsUpdatedInstance()
    {
        // Arrange
        Parameter existing = TargetTaskTestsData.CreateParameter();

        var additional = new Parameter
        {
            Name = new Name("Other"),
            Value = Snippet.From("Value"),
        };

        TargetTask original = TargetTaskTestsData.Create(parameter: existing);

        // Act
        TargetTask result = original.WithParameters(additional);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Parameters).IsEqualTo(original.Parameters.Concat([additional]));
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Condition).IsEqualTo(original.Condition);
    }
}