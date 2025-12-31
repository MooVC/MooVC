namespace MooVC.Syntax.CSharp.Elements.VariableTests.OptionsTests;

public sealed class WhenWithCasingIsCalled
{
    [Fact]
    public void GivenCasingThenReturnsNewInstanceWithUpdatedCasing()
    {
        // Arrange
        var original = new Variable.Options();

        // Act
        Variable.Options result = original.WithCasing(Variable.Casing.Pascal);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Casing.ShouldBe(Variable.Casing.Pascal);
        result.UseUnderscore.ShouldBe(original.UseUnderscore);
        original.Casing.ShouldBe(Variable.Casing.Camel);
    }
}