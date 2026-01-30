namespace MooVC.Syntax.Elements.IdentifierTests.OptionsTests;

public sealed class WhenWithCasingIsCalled
{
    [Fact]
    public void GivenCasingThenReturnsNewInstanceWithUpdatedCasing()
    {
        // Arrange
        var original = new Identifier.Options();

        // Act
        Identifier.Options result = original.WithCasing(Identifier.Casing.Pascal);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Casing.ShouldBe(Identifier.Casing.Pascal);
        original.Casing.ShouldBe(Identifier.Casing.Camel);
    }
}