namespace MooVC.Serialization.SynchronousSerializerTests;

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using MooVC.Compression;
using Moq;
using Xunit;

public sealed class WhenDeserializeAsyncIsCalled
{
    [Fact]
    public async Task GivenACompressorThenCompressAsyncIsInvokedAsync()
    {
        // Arrange
        var compressor = new Mock<ICompressor>();

        _ = compressor
            .Setup(compressor => compressor.DecompressAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync<Stream, CancellationToken, ICompressor, Stream>((stream, _) => stream);

        var serializer = new TestableSynchronousSerializer(
            compressor: compressor.Object,
            onDeserialize: instance => "Something irrelevant");

        using var source = new MemoryStream();

        // Act
        _ = await serializer.DeserializeAsync<string>(source, CancellationToken.None);

        // Assert
        compressor.Verify(c => c.DecompressAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task GivenDataThenDataDeserializationIsRequestedAsync()
    {
        // Arrange
        byte[] expected = { 1, 2, 3 };
        string instance = "Something something dark side...";
        bool wasInvoked = false;

        object Deserializer(object input)
        {
            wasInvoked = true;
            return instance;
        }

        var serializer = new TestableSynchronousSerializer(onDeserialize: Deserializer);

        // Act
        string deserialized = await serializer.DeserializeAsync<string>(expected, CancellationToken.None);

        // Assert
        _ = wasInvoked.Should().BeTrue();
        _ = deserialized.Should().Be(instance);
    }

    [Fact]
    public async Task GivenAStreamThenStreamDeserializationIsRequestedAsync()
    {
        // Arrange
        byte[] expected = { 1, 2, 3 };
        string instance = "Something something dark side...";
        bool wasInvoked = false;

        object Deserializer(object input)
        {
            wasInvoked = true;
            return instance;
        }

        var serializer = new TestableSynchronousSerializer(onDeserialize: Deserializer);
        using var stream = new MemoryStream(expected);

        // Act
        string deserialized = await serializer.DeserializeAsync<string>(stream, CancellationToken.None);

        // Assert
        _ = wasInvoked.Should().BeTrue();
        _ = deserialized.Should().Be(instance);
    }
}