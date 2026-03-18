namespace MooVC.Syntax.Elements.IdentifierTests.OptionsTests;

public sealed class WhenWithCasingIsCalled
{
    [Test]
    public async Task GivenCasingThenReturnsNewInstanceWithUpdatedCasing()
    {
        // Arrange
        var original = new Identifier.Options();

        // Act
        Identifier.Options result = original.WithCasing(Identifier.Casing.Pascal);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Casing).IsEqualTo(Identifier.Casing.Pascal);
        _ = await Assert.That(original.Casing).IsEqualTo(Identifier.Casing.Camel);
    }
}