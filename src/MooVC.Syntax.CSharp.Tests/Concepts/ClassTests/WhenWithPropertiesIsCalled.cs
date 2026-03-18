namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using System.Collections.Immutable;
using System.Linq;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;

public sealed class WhenWithPropertiesIsCalled
{
    [Test]
    public async Task GivenPropertiesThenReturnsUpdatedInstance()
    {
        // Arrange
        Property[] existing = [new Property { Name = new Name("First"), Type = typeof(int) }];
        Property[] additional = [new Property { Name = new Name("Second"), Type = typeof(string) }];
        Class original = ClassTestsData.Create(properties: existing.ToImmutableArray());

        // Act
        Class result = original.WithProperties(additional);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Properties).IsEqualTo(original.Properties.Concat(additional));
        _ = await Assert.That(result.Declaration).IsEqualTo(original.Declaration);
        _ = await Assert.That(original.Properties).IsEqualTo(existing);
    }
}