namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using System.Collections.Immutable;
using System.Linq;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Attributes).IsEqualTo(original.Attributes.Concat(additional));
        await Assert.That(result.Constructors).IsEqualTo(original.Constructors);
        await Assert.That(original.Attributes).IsEqualTo(existing);
    }
}