namespace MooVC.Syntax.CSharp.ConversionTests;

public sealed class WhenWithDirectionIsCalled
{
    [Test]
    public async Task GivenDirectionThenReturnsNewInstanceWithUpdatedDirection()
    {
        // Arrange
        Conversion original = ConversionTestsData.Create();
        Conversion.Intents replacement = Conversion.Intents.From;

        // Act
        Conversion result = original.WithDirection(replacement);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Body).IsEqualTo(original.Body);
        _ = await Assert.That(result.Direction).IsEqualTo(replacement);
        _ = await Assert.That(result.Mode).IsEqualTo(original.Mode);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
        _ = await Assert.That(result.Target).IsEqualTo(original.Target);
    }
}