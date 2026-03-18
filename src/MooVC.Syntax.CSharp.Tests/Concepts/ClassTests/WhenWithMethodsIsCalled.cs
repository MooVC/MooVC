namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using System.Collections.Immutable;
using System.Linq;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithMethodsIsCalled
{
    [Test]
    public async Task GivenMethodsThenReturnsUpdatedInstance()
    {
        // Arrange
        Method[] existing = [new Method { Name = new Declaration { Name = "First" } }];
        Method[] additional = [new Method { Name = new Declaration { Name = "Second" } }];
        Class original = ClassTestsData.Create(methods: existing.ToImmutableArray());

        // Act
        Class result = original.WithMethods(additional);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Methods).IsEqualTo(original.Methods.Concat(additional));
        _ = await Assert.That(result.Declaration).IsEqualTo(original.Declaration);
        _ = await Assert.That(original.Methods).IsEqualTo(existing);
    }
}