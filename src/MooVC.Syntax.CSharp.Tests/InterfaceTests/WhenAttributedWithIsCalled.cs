namespace MooVC.Syntax.CSharp.InterfaceTests;

using System.Collections.Immutable;

public sealed class WhenAttributedWithIsCalled
{
    [Test]
    public async Task GivenAttributesThenReturnsUpdatedInstance()
    {
        // Arrange
        Attribute[] existing =
        [
            new Attribute { Name = new() { Name = "Existing" } },
        ];

        Attribute[] additional =
        [
            new Attribute { Name = new() { Name = "Additional" } },
        ];

        Interface original = InterfaceTestsData.Create(attributes: existing.ToImmutableArray());

        // Act
        Interface result = original.AttributedWith(additional);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Attributes).IsEquivalentTo([.. original.Attributes, .. additional]);
        _ = await Assert.That(result.Events).IsEquivalentTo(original.Events);
        _ = await Assert.That(original.Attributes).IsEquivalentTo(existing);
    }
}