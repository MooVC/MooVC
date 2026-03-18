namespace MooVC.Syntax.CSharp.Elements.ParameterTests;

using System.Linq;
using Attribute = MooVC.Syntax.CSharp.Members.Attribute;

public sealed class WhenAttributedWithIsCalled
{
    [Test]
    public async Task GivenAttributesThenReturnsNewInstanceWithUpdatedAttributes()
    {
        // Arrange
        Attribute[] existing =
        [
            new Attribute
            {
                Name = new Symbol { Name = "Existing" },
            },
        ];

        Attribute[] additional =
        [
            new Attribute
            {
                Name = new Symbol { Name = "Additional" },
            },
        ];

        Parameter original = ParameterTestsData.Create(attributes: existing);

        // Act
        Parameter result = original.AttributedWith(additional);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Attributes.Length).IsEqualTo(existing.Length + additional.Length);
        await Assert.That(result.Attributes).IsEqualTo(original.Attributes.Concat(additional));
        await Assert.That(result.Default).IsEqualTo(original.Default);
        await Assert.That(result.Modifier).IsEqualTo(original.Modifier);
        await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}