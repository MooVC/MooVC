namespace MooVC.Serialization.SynchronousSerializerTests;

using System.IO;
using MooVC.Compression;

public sealed class WhenDeserializeAsyncIsCalled
{
    [Fact]
    public async Task GivenACompressorThenCompressAsyncIsInvoked()
    {
        // Arrange
        ICompressor compressor = Substitute.For<ICompressor>();

        _ = compressor
            .Decompress(Arg.Any<Stream>(), Arg.Any<CancellationToken>())
            .Returns(info => info.Arg<Stream>());

        var serializer = new TestableSynchronousSerializer(
            compressor: compressor,
            onDeserialize: instance => "Something irrelevant");

        using var source = new MemoryStream();

        // Act
        _ = await serializer.Deserialize<string>(source, CancellationToken.None);

        // Assert
        _ = await compressor.Received(1).Decompress(Arg.Any<Stream>(), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task GivenDataThenDataDeserializationIsRequested()
    {
        // Arrange
        byte[] expected = [1, 2, 3];
        string instance = "Something something dark side...";
        bool wasInvoked = false;

        object Deserializer(object input)
        {
            wasInvoked = true;
            return instance;
        }

        var serializer = new TestableSynchronousSerializer(onDeserialize: Deserializer);

        // Act
        string deserialized = await serializer.Deserialize<string>(expected, CancellationToken.None);

        // Assert
        _ = wasInvoked.Should().BeTrue();
        _ = deserialized.Should().Be(instance);
    }

    [Fact]
    public async Task GivenAStreamThenStreamDeserializationIsRequested()
    {
        // Arrange
        byte[] expected = [1, 2, 3];
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
        string deserialized = await serializer.Deserialize<string>(stream, CancellationToken.None);

        // Assert
        _ = wasInvoked.Should().BeTrue();
        _ = deserialized.Should().Be(instance);
    }
}