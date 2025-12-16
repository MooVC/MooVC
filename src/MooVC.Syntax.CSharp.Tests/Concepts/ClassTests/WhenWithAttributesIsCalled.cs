namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using System.Collections.Immutable;
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

        Class original = ClassTestsData.Create(attributes: existing.ToImmutableArray());

        // Act
        Class result = original.WithAttributes(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Attributes.ShouldBe(original.Attributes.Concat(additional));
        result.Constructors.ShouldBe(original.Constructors);
        original.Attributes.ShouldBe(existing);
    }
}