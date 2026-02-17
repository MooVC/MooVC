namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using System.Collections.Immutable;
using System.Linq;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithMethodsIsCalled
{
    [Fact]
    public void GivenMethodsThenReturnsUpdatedInstance()
    {
        // Arrange
        Method[] existing = [new Method { Name = new Declaration { Name = "First" } }];
        Method[] additional = [new Method { Name = new Declaration { Name = "Second" } }];
        Class original = ClassTestsData.Create(methods: existing.ToImmutableArray());

        // Act
        Class result = original.WithMethods(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Methods.ShouldBe(original.Methods.Concat(additional));
        result.Declaration.ShouldBe(original.Declaration);
        original.Methods.ShouldBe(existing);
    }
}