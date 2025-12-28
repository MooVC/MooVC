namespace MooVC.Syntax.CSharp.Elements.ParameterTests;

public sealed class WhenWithModifierIsCalled
{
    [Fact]
    public void GivenValueThenReturnsNewInstanceWithUpdatedModifier()
    {
        // Arrange
        Parameter original = ParameterTestsData.Create(@default: Snippet.From("value"));

        // Act
        Parameter result = original.WithModifier(Parameter.Mode.RefReadonly);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Modifier.ShouldBe(Parameter.Mode.RefReadonly);
        result.Attributes.ShouldBe(original.Attributes);
        result.Default.ShouldBe(original.Default);
        result.Name.ShouldBe(original.Name);
        original.Modifier.ShouldBe(Parameter.Mode.None);
    }
}