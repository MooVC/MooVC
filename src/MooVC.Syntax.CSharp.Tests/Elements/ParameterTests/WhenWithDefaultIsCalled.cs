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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Default).IsEqualTo(@default);
        _ = await Assert.That(result.Attributes).IsEqualTo(original.Attributes);
        _ = await Assert.That(result.Modifier).IsEqualTo(original.Modifier);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(original.Default).IsEqualTo(Snippet.Empty);
    }
}