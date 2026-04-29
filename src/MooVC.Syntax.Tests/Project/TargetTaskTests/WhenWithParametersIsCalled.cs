namespace MooVC.Syntax.Project.TargetTaskTests;

public sealed class WhenWithParametersIsCalled
{
    [Test]
    public async Task GivenParametersThenReturnsUpdatedInstance()
    {
        // Arrange
        Parameter existing = TargetTaskTestsData.CreateParameter();

        var additional = new Parameter
        {
            Name = new("Other"),
            Value = Snippet.From("Value"),
        };

        TargetTask original = TargetTaskTestsData.Create(parameter: existing);

        // Act
        TargetTask result = original.WithParameters(additional);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Parameters).IsEquivalentTo([.. original.Parameters, additional]);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
    }
}