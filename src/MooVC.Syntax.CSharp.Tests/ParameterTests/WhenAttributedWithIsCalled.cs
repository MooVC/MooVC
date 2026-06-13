namespace MooVC.Syntax.CSharp.ParameterTests;

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
                Name = new() { Name = "Existing" },
            },
        ];

        Attribute[] additional =
        [
            new Attribute
            {
                Name = new() { Name = "Additional" },
            },
        ];

        Parameter original = ParameterTestsData.Create(attributes: existing);

        // Act
        Parameter result = original.AttributedWith(additional);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Attributes.Length).IsEqualTo(existing.Length + additional.Length);
        _ = await Assert.That(result.Attributes).IsEquivalentTo([.. original.Attributes, .. additional]);
        _ = await Assert.That(result.Default).IsEqualTo(original.Default);
        _ = await Assert.That(result.Modifier).IsEqualTo(original.Modifier);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}