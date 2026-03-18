namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using System.Collections.Immutable;
using System.Linq;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Parameters).IsEqualTo(original.Parameters.Concat(additional));
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
        await Assert.That(original.Parameters).IsEqualTo(existing);
    }
}