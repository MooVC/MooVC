namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using System.Collections.Immutable;
using System.Linq;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithAttributesIsCalled
{
    [Fact]
    public void GivenAttributesThenReturnsUpdatedInstance()
    {
        // Arrange
        Attribute[] existing =
        [
            new Attribute { Name = new Symbol { Name = new Variable("Existing") } },
        ];

        Attribute[] additional =
        [
            new Attribute { Name = new Symbol { Name = new Variable("Additional") } },
        ];

        Interface original = InterfaceTestsData.Create(attributes: existing.ToImmutableArray());

        // Act
        Interface result = original.WithAttributes(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Attributes.ShouldBe(original.Attributes.Concat(additional));
        result.Events.ShouldBe(original.Events);
        original.Attributes.ShouldBe(existing);
    }
}