namespace MooVC.Syntax.CSharp.Elements.ParameterTests;

using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Modifier).IsEqualTo(Parameter.Mode.RefReadonly);
        await Assert.That(result.Attributes).IsEqualTo(original.Attributes);
        await Assert.That(result.Default).IsEqualTo(original.Default);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(original.Modifier).IsEqualTo(Parameter.Mode.None);
    }
}