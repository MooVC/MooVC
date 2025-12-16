namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using System.Linq;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithMethodsIsCalled
{
    [Fact]
    public void GivenMethodsThenReturnsUpdatedInstance()
    {
        // Arrange
        Method[] existing = [new Method { Name = new Identifier("First") }];
        Method[] additional = [new Method { Name = new Identifier("Second") }];
        Class original = ClassTestsData.Create(methods: existing);

        // Act
        Class result = original.WithMethods(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Methods.ShouldBe(original.Methods.Concat(additional));
        result.Name.ShouldBe(original.Name);
        original.Methods.ShouldBe(existing);
    }
}
