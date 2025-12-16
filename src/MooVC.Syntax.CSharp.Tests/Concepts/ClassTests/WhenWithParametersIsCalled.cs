namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using System.Linq;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithParametersIsCalled
{
    [Fact]
    public void GivenParametersThenReturnsUpdatedInstance()
    {
        // Arrange
        Parameter[] existing = [new Parameter { Name = new Identifier("value"), Type = typeof(int) }];
        Parameter[] additional = [new Parameter { Name = new Identifier("text"), Type = typeof(string) }];
        Class original = ClassTestsData.Create(parameters: existing);

        // Act
        Class result = original.WithParameters(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Parameters.ShouldBe(original.Parameters.Concat(additional));
        result.Scope.ShouldBe(original.Scope);
        original.Parameters.ShouldBe(existing);
    }
}
