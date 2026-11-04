namespace MooVC.Compression.Configuration.TypeTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    [Arguments("Brotli")]
    [Arguments("Deflate")]
    [Arguments("GZip")]
    [Arguments("Custom")]
    public async Task GivenValueThenConversionPreservesIdentifier(string value)
    {
        // Act
        Type type = value;
        string result = type;

        // Assert
        _ = await Assert.That(result).IsEqualTo(value);
        _ = await Assert.That(type.ToString()).IsEqualTo(value);
        _ = await Assert.That(type == value).IsTrue();
        _ = await Assert.That(type != value).IsFalse();
    }
}