namespace MooVC.Syntax.CSharp.Elements.VariableTests.OptionsTests;

public sealed class WhenUseUnderscoresIsCalled
{
    [Fact]
    public void GivenFlagThenReturnsNewInstanceWithUpdatedFlag()
    {
        // Arrange
        var original = new Variable.Options();

        // Act
        Variable.Options result = original.UseUnderscores(true);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Casing.ShouldBe(original.Casing);
        result.UseUnderscore.ShouldBeTrue();
        original.UseUnderscore.ShouldBeFalse();
    }
}