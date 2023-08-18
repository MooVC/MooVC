namespace MooVC.Serialization.SynchronousSerializerTests;

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using MooVC.Compression;
using NSubstitute;
using Xunit;

public sealed class WhenDeserializeAsyncIsCalled
{
    [Fact]
    public async Task GivenACompressorThenCompressAsyncIsInvokedAsync()
    {
        // Arrange
        ICompressor compressor = Substitute.For<ICompressor>();

        _ = compressor
            .DecompressAsync(Arg.Any<Stream>(), Arg.Any<CancellationToken>())
            .Returns(info => info.Arg<Stream>());

        var serializer = new TestableSynchronousSerializer(
            compressor: compressor,
            onDeserialize: instance => "Something irrelevant");

        using var source = new MemoryStream();

        // Act
        _ = await serializer.DeserializeAsync<string>(source, CancellationToken.None);

        // Assert
        _ = await compressor.Received(1).DecompressAsync(Arg.Any<Stream>(), Arg.Any<CancellationToken>());
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