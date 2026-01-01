namespace MooVC.Syntax.CSharp.Elements.VariableTests.OptionsTests;

public sealed class WhenUseUnderscoreIsCalled
{
    [Fact]
    public void GivenFlagThenReturnsNewInstanceWithUpdatedFlag()
    {
        // Arrange
        var original = new Variable.Options();

        // Act
        Variable.Options result = original.UseUnderscore(true);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Casing.ShouldBe(original.Casing);
        result.UseUnderscore.ShouldBeTrue();
        original.UseUnderscore.ShouldBeFalse();
    }
}