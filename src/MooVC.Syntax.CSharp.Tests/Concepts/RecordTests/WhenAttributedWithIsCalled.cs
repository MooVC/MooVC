namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

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

        Record original = RecordTestsData.Create(attributes: existing.ToImmutableArray());

        // Act
        Record result = original.AttributedWith(additional);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Attributes).IsEquivalentTo([.. original.Attributes, .. additional]);
        _ = await Assert.That(result.Constructors).IsEquivalentTo(original.Constructors);
        _ = await Assert.That(original.Attributes).IsEquivalentTo(existing);
    }
}