namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

public sealed class WhenWithDirectionIsCalled
{
    [Test]
    public async Task GivenDirectionThenReturnsNewInstanceWithUpdatedDirection()
    {
        // Arrange
        Conversion original = ConversionTestsData.Create();
        Conversion.Intent replacement = Conversion.Intent.From;

        // Act
        Conversion result = original.WithDirection(replacement);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Body).IsEqualTo(original.Body);
        await Assert.That(result.Direction).IsEqualTo(replacement);
        await Assert.That(result.Mode).IsEqualTo(original.Mode);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
        await Assert.That(result.Target).IsEqualTo(original.Target);
    }
}