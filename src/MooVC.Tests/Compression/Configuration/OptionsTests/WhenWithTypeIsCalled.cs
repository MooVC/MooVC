namespace MooVC.Compression.Configuration.OptionsTests;

public sealed class WhenWithTypeIsCalled
{
    [Test]
    public async Task GivenValueThenUpdatedCopyPreservesAlgorithmSettings()
    {
        // Arrange
        var options = new Options();

        // Act
        Options result = options.WithType(GZipCompressor.GZip);

        // Assert
        _ = await Assert.That(ReferenceEquals(result, options)).IsFalse();
        _ = await Assert.That(result.Type).IsEqualTo(GZipCompressor.GZip);
        _ = await Assert.That((string)options.Type).IsEqualTo("None");
        _ = await Assert.That(ReferenceEquals(result.Brotli, options.Brotli)).IsTrue();
        _ = await Assert.That(ReferenceEquals(result.Deflate, options.Deflate)).IsTrue();
        _ = await Assert.That(ReferenceEquals(result.GZip, options.GZip)).IsTrue();
    }
}