namespace MooVC.Syntax.CSharp.Members.IdentifierTests.OptionsTests;

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
        result.UseUnderscores.ShouldBe(original.UseUnderscores);
        original.Casing.ShouldBe(Identifier.Casing.Camel);
    }
}