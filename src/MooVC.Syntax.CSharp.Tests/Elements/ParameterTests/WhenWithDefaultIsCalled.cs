namespace MooVC.Syntax.CSharp.Elements.ParameterTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithDefaultIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsNewInstanceWithUpdatedDefault()
    {
        // Arrange
        Parameter original = ParameterTestsData.Create(modifier: Parameter.Mode.In);
        var @default = Snippet.From("value");

        // Act
        Parameter result = original.WithDefault(@default);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Default).IsEqualTo(@default);
        await Assert.That(result.Attributes).IsEqualTo(original.Attributes);
        await Assert.That(result.Modifier).IsEqualTo(original.Modifier);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(original.Default).IsEqualTo(Snippet.Empty);
    }
}