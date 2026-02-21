namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using System.Collections.Immutable;
using System.Linq;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenAttributedWithIsCalled
{
    [Fact]
    public void GivenAttributesThenReturnsUpdatedInstance()
    {
        // Arrange
        Attribute[] existing =
        [
            new Attribute { Name = new Symbol { Name = "Existing" } },
        ];

        Attribute[] additional =
        [
            new Attribute { Name = new Symbol { Name = "Additional" } },
        ];

        Struct original = StructTestsData.Create(attributes: existing.ToImmutableArray());

        // Act
        Struct result = original.AttributedWith(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Attributes.ShouldBe(original.Attributes.Concat(additional));
        result.Constructors.ShouldBe(original.Constructors);
        original.Attributes.ShouldBe(existing);
    }
}