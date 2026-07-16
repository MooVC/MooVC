namespace MooVC.Syntax.CSharp.ConversionTests.IntentsTests;

public sealed class WhenPropertiesAreAccessed
{
    [Test]
    public async Task GivenToThenFlagsReflectValue()
    {
        // Arrange
        Conversion.Intents subject = Conversion.Intents.To;

        // Act
        bool isTo = subject.IsTo;
        bool isFrom = subject.IsFrom;

        // Assert
        _ = await Assert.That(isTo).IsTrue();
        _ = await Assert.That(isFrom).IsFalse();
    }
}