namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using System.Collections.Immutable;
using System.Linq;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;

public sealed class WhenWithPropertiesIsCalled
{
    [Fact]
    public void GivenPropertiesThenReturnsUpdatedInstance()
    {
        // Arrange
        Property[] existing = [new Property { Name = "First", Type = typeof(int) }];
        Property[] additional = [new Property { Name = "Second", Type = typeof(string) }];
        Class original = ClassTestsData.Create(properties: existing.ToImmutableArray());

        // Act
        Class result = original.WithProperties(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Properties.ShouldBe(original.Properties.Concat(additional));
        result.Declaration.ShouldBe(original.Declaration);
        original.Properties.ShouldBe(existing);
    }
}