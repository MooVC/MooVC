namespace MooVC.Compression.StreamCompressorTests.OptionsTests;

using System.IO.Compression;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenNoSettingsThenDocumentedDefaultsAreUsed()
    {
        // Arrange
        const int defaultBufferSize = 81920;

        // Act
        var options = new StreamCompressor.Options();

        // Assert
        _ = await Assert.That(options.BufferSize).IsEqualTo(defaultBufferSize);
        _ = await Assert.That(options.Level).IsEqualTo(CompressionLevel.Optimal);
    }
}