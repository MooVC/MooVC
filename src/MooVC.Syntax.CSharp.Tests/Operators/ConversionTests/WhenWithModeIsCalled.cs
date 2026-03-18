namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

public sealed class WhenWithModeIsCalled
{
    [Test]
    public async Task GivenModeThenReturnsNewInstanceWithUpdatedMode()
    {
        // Arrange
        Conversion original = ConversionTestsData.Create();
        Conversion.Type replacement = Conversion.Type.Explicit;

        // Act
        Conversion result = original.WithMode(replacement);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Body).IsEqualTo(original.Body);
        _ = await Assert.That(result.Direction).IsEqualTo(original.Direction);
        _ = await Assert.That(result.Mode).IsEqualTo(replacement);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
        _ = await Assert.That(result.Target).IsEqualTo(original.Target);
    }
}