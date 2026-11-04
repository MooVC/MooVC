namespace MooVC.Compression.Configuration.OptionsTests;

using System.Globalization;
using System.IO.Compression;
using Microsoft.Extensions.Configuration;

public sealed class WhenGetIsCalled
{
    [Test]
    public async Task GivenAlgorithmSettingsThenValuesAreBoundIndependently()
    {
        // Arrange
        const int brotliBufferSize = 1;
        const int deflateBufferSize = 2;
        const int gzipBufferSize = 3;
        var values = new Dictionary<string, string?>
        {
            ["Compression:Brotli:BufferSize"] = brotliBufferSize.ToString(CultureInfo.InvariantCulture),
            ["Compression:Brotli:Level"] = nameof(CompressionLevel.Fastest),
            ["Compression:Deflate:BufferSize"] = deflateBufferSize.ToString(CultureInfo.InvariantCulture),
            ["Compression:Deflate:Level"] = nameof(CompressionLevel.NoCompression),
            ["Compression:GZip:BufferSize"] = gzipBufferSize.ToString(CultureInfo.InvariantCulture),
            ["Compression:GZip:Level"] = nameof(CompressionLevel.SmallestSize),
            ["Compression:Type"] = "GZip",
        };
        IConfigurationSection configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(values)
            .Build()
            .GetSection("Compression");

        // Act
        Options options = configuration.Get<Options>()!;

        // Assert
        _ = await Assert.That(options.Type).IsEqualTo(GZipCompressor.GZip);
        _ = await Assert.That(options.Brotli.BufferSize).IsEqualTo(brotliBufferSize);
        _ = await Assert.That(options.Brotli.Level).IsEqualTo(CompressionLevel.Fastest);
        _ = await Assert.That(options.Deflate.BufferSize).IsEqualTo(deflateBufferSize);
        _ = await Assert.That(options.Deflate.Level).IsEqualTo(CompressionLevel.NoCompression);
        _ = await Assert.That(options.GZip.BufferSize).IsEqualTo(gzipBufferSize);
        _ = await Assert.That(options.GZip.Level).IsEqualTo(CompressionLevel.SmallestSize);
    }
}