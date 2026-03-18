namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using System.Collections.Immutable;

public sealed class WhenAttributedWithIsCalled
{
    [Test]
    public async Task GivenAttributesThenReturnsUpdatedInstance()
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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Attributes).IsEquivalentTo([.. original.Attributes, .. additional]);
        _ = await Assert.That(result.Constructors).IsEquivalentTo(original.Constructors);
        _ = await Assert.That(original.Attributes).IsEquivalentTo(existing);
    }
}