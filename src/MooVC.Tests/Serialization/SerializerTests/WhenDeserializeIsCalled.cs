namespace MooVC.Serialization.SerializerTests;

using System.IO;
using System.Text;
using MooVC.Compression;

public sealed class WhenDeserializeIsCalled
{
    private static readonly byte[] SourceData = Encoding.UTF8.GetBytes("Something something dark side...");
    private const string Expected = "Something something dark side...";

    [Test]
    public async Task GivenACompressorThenDecompressAsyncIsInvoked()
    {
        // Arrange
        ICompressor compressor = Substitute.For<ICompressor>();

        _ = compressor
            .Decompress(Arg.Any<Stream>(), Arg.Any<CancellationToken>())
            .Returns(async info =>
            {
                Stream source = info.Arg<Stream>();
                using var copied = new MemoryStream();
                await source.CopyToAsync(copied, CancellationToken.None);
                copied.Position = 0;
                return copied;
            });

        var serializer = new TestableSerializer(
            compressor: compressor,
            onDeserialize: _ => Expected);

        using var source = new MemoryStream(SourceData);

        // Act
        _ = await serializer.Deserialize<string>(source, CancellationToken.None);

        // Assert
        _ = await compressor.Received(1).Decompress(Arg.Any<Stream>(), Arg.Any<CancellationToken>());
    }

    [Test]
    public async Task GivenNoCompressorThenSourceDataIsProvidedToDeserializer()
    {
        // Arrange
        using var source = new MemoryStream(SourceData);
        var serializer = new TestableSerializer(
            onDeserialize: input =>
            {
                using var copied = new MemoryStream();
                input.CopyTo(copied);
                return Encoding.UTF8.GetString(copied.ToArray());
            });

        // Act
        string deserialized = await serializer.Deserialize<string>(source, CancellationToken.None);

        // Assert
        _ = await Assert.That(deserialized).IsEqualTo(Expected);
    }

    [Test]
    public async Task GivenDataThenDataDeserializationIsRequested()
    {
        // Arrange
        bool wasInvoked = false;

        var serializer = new TestableSerializer(
            onDeserialize: _ =>
            {
                wasInvoked = true;
                return Expected;
            });

        // Act
        string deserialized = await serializer.Deserialize<string>(SourceData, CancellationToken.None);

        // Assert
        _ = await Assert.That(wasInvoked).IsTrue();
        _ = await Assert.That(deserialized).IsEqualTo(Expected);
    }

    [Test]
    public async Task GivenNullDataThenThrowsArgumentNullException()
    {
        // Arrange
        var serializer = new TestableSerializer(onDeserialize: _ => Expected);
        IEnumerable<byte>? data = default;

        // Act
        Func<Task> act = async () => await serializer.Deserialize<string>(data!, CancellationToken.None);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(data));
    }

    [Test]
    public async Task GivenNullSourceThenThrowsArgumentNullException()
    {
        // Arrange
        var serializer = new TestableSerializer(onDeserialize: _ => Expected);
        Stream? source = default;

        // Act
        Func<Task> act = async () => await serializer.Deserialize<string>(source!, CancellationToken.None);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(source));
    }
}
