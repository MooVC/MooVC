namespace MooVC.Syntax.Elements.IdentifierTests.OptionsTests;

public sealed class WhenUseUnderscoresIsCalled
{
    [Fact]
    public void GivenFlagThenReturnsNewInstanceWithUpdatedFlag()
    {
        // Arrange
        var original = new Identifier.Options();

        // Act
        Identifier.Options result = original.UseUnderscores(true);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Casing.ShouldBe(original.Casing);
        result.UseUnderscores.ShouldBeTrue();
        original.UseUnderscores.ShouldBeFalse();
    }
}