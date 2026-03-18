namespace MooVC.Syntax.CSharp.ParameterTests;

public sealed class WhenWithModifierIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsNewInstanceWithUpdatedModifier()
    {
        // Arrange
        Parameter original = ParameterTestsData.Create(@default: Snippet.From("value"));

        // Act
        Parameter result = original.WithModifier(Parameter.Mode.RefReadonly);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Modifier).IsEqualTo(Parameter.Mode.RefReadonly);
        _ = await Assert.That(result.Attributes).IsEqualTo(original.Attributes);
        _ = await Assert.That(result.Default).IsEqualTo(original.Default);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(original.Modifier).IsEqualTo(Parameter.Mode.None);
    }
}