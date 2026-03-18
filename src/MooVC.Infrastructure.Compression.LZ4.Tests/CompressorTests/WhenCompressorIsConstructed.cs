namespace MooVC.Infrastructure.Compression.LZ4.CompressorTests;

using K4os.Compression.LZ4;
using K4os.Compression.LZ4.Streams;

public sealed class WhenCompressorIsConstructed
{
    [Test]
    public async Task GivenNoSettingsThenTheDefaultSettingsAreUsed()
    {
        // Arrange
        var decoder = new LZ4DecoderSettings();
        var encoder = new LZ4EncoderSettings();

        // Act
        var compressor = new Compressor();

        // Assert
        await Assert.That(compressor.Decoder).IsEquivalentTo(decoder);
        await Assert.That(compressor.Encoder).IsEquivalentTo(encoder);
    }

    [Test]
    public async Task GivenSettingsThenTheSettingsAreApplied()
    {
        // Arrange
        var decoder = new LZ4DecoderSettings
        {
            ExtraMemory = 1024,
        };

        var encoder = new LZ4EncoderSettings
        {
            BlockSize = 131072,
            ChainBlocks = false,
            CompressionLevel = LZ4Level.L12_MAX,
            ContentLength = 2048,
            ExtraMemory = 4096,
        };

        // Act
        var compressor = new Compressor(decoder: decoder, encoder: encoder);

        // Assert
        await Assert.That(compressor.Decoder).IsEquivalentTo(decoder);
        await Assert.That(compressor.Encoder).IsEquivalentTo(encoder);
    }
}