namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using System.Linq;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithAttributesIsCalled
{
    [Fact]
    public void GivenAttributesThenReturnsUpdatedInstance()
    {
        // Arrange
        Attribute[] existing =
        [
            new Attribute { Name = new Symbol { Name = new Identifier("Existing") } },
        ];

        Attribute[] additional =
        [
            new Attribute { Name = new Symbol { Name = new Identifier("Additional") } },
        ];

        Interface original = InterfaceTestsData.Create(attributes: existing);

        // Act
        Interface result = original.WithAttributes(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Attributes.ShouldBe(original.Attributes.Concat(additional));
        result.Events.ShouldBe(original.Events);
        original.Attributes.ShouldBe(existing);
    }
}
