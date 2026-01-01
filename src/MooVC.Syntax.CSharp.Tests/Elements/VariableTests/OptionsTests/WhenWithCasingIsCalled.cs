namespace MooVC.Syntax.CSharp.Elements.VariableTests.OptionsTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithCasingIsCalled
{
    [Fact]
    public void GivenCasingThenReturnsNewInstanceWithUpdatedCasing()
    {
        // Arrange
        var original = new Variable.Options();

        // Act
        Variable.Options result = original.WithCasing(Identifier.Casing.Pascal);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Casing.ShouldBe(Identifier.Casing.Pascal);
        result.UseUnderscore.ShouldBe(original.UseUnderscore);
        original.Casing.ShouldBe(Identifier.Casing.Camel);
    }
}