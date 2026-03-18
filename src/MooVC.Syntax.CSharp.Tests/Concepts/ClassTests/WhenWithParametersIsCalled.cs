namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using System.Collections.Immutable;

public sealed class WhenWithParametersIsCalled
{
    [Test]
    public async Task GivenParametersThenReturnsUpdatedInstance()
    {
        // Arrange
        Parameter[] existing = [new Parameter { Name = new Variable("value"), Type = typeof(int) }];
        Parameter[] additional = [new Parameter { Name = new Variable("text"), Type = typeof(string) }];
        Class original = ClassTestsData.Create(parameters: existing.ToImmutableArray());

        // Act
        Class result = original.WithParameters(additional);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Parameters).IsEquivalentTo([.. original.Parameters, .. additional]);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
        _ = await Assert.That(original.Parameters).IsEquivalentTo(existing);
    }
}