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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Body).IsEqualTo(original.Body);
        await Assert.That(result.Direction).IsEqualTo(original.Direction);
        await Assert.That(result.Mode).IsEqualTo(replacement);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
        await Assert.That(result.Target).IsEqualTo(original.Target);
    }
}