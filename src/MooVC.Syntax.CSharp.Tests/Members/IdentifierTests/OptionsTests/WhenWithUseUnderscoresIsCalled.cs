namespace MooVC.Syntax.CSharp.Members.IdentifierTests.OptionsTests;

public sealed class WhenWithUseUnderscoresIsCalled
{
    [Fact]
    public void GivenFlagThenReturnsNewInstanceWithUpdatedFlag()
    {
        // Arrange
        var original = new Identifier.Options();

        // Act
        Identifier.Options result = original.WithUseUnderscores(true);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Casing.ShouldBe(original.Casing);
        result.UseUnderscores.ShouldBeTrue();
        original.UseUnderscores.ShouldBeFalse();
    }
}
