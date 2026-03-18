namespace MooVC.Syntax.CSharp.ConversionTests.IntentTests;

public sealed class WhenPropertiesAreAccessed
{
    [Test]
    public async Task GivenToThenFlagsReflectValue()
    {
        // Arrange
        Conversion.Intent subject = Conversion.Intent.To;

        // Act
        bool isTo = subject.IsTo;
        bool isFrom = subject.IsFrom;

        // Assert
        _ = await Assert.That(isTo).IsTrue();
        _ = await Assert.That(isFrom).IsFalse();
    }
}