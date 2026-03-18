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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Methods).IsEqualTo(original.Methods.Concat(additional));
        await Assert.That(result.Declaration).IsEqualTo(original.Declaration);
        await Assert.That(original.Methods).IsEqualTo(existing);
    }
}