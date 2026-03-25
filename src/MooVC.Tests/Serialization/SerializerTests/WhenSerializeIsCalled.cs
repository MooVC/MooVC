namespace MooVC.Serialization.SerializerTests;

using System.IO;
using System.Text;
using MooVC.Compression;

public sealed class WhenSerializeIsCalled
{
    private static readonly byte[] SerializedPayload = Encoding.UTF8.GetBytes("Some payload.");
    private const string Instance = "Something something dark side...";

    [Test]
    public async Task GivenACompressorThenCompressAsyncIsInvoked()
    {
        // Arrange
        ICompressor compressor = Substitute.For<ICompressor>();

        _ = compressor
            .Compress(Arg.Any<Stream>(), Arg.Any<CancellationToken>())
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
            onSerialize: async (_, target) => await target.WriteAsync(SerializedPayload, CancellationToken.None));

        // Act
        IEnumerable<byte> serialized = await serializer.Serialize(Instance, CancellationToken.None);

        // Assert
        _ = await compressor.Received(1).Compress(Arg.Any<Stream>(), Arg.Any<CancellationToken>());
        _ = await Assert.That(serialized).IsEquivalentTo(SerializedPayload);
    }

    [Test]
    public async Task GivenNoCompressorThenSerializedDataIsCopiedToTheTargetStream()
    {
        // Arrange
        using var target = new MemoryStream();
        var serializer = new TestableSerializer(
            onSerialize: async (_, stream) => await stream.WriteAsync(SerializedPayload, CancellationToken.None));

        // Act
        await serializer.Serialize(Instance, target, CancellationToken.None);

        // Assert
        _ = await Assert.That(target.ToArray()).IsEquivalentTo(SerializedPayload);
    }

    [Test]
    public async Task GivenAStreamThenStreamSerializationIsRequested()
    {
        // Arrange
        bool wasInvoked = false;

        var serializer = new TestableSerializer(
            onSerialize: (_, _) =>
            {
                wasInvoked = true;
                return Task.CompletedTask;
            });
        using var stream = new MemoryStream();

        // Act
        await serializer.Serialize(Instance, stream, CancellationToken.None);

        // Assert
        _ = await Assert.That(wasInvoked).IsTrue();
    }

    [Test]
    public async Task GivenNullStreamThenThrowsArgumentNullException()
    {
        // Arrange
        var serializer = new TestableSerializer(onSerialize: (_, _) => Task.CompletedTask);
        Stream? target = default;

        // Act
        Func<Task> act = async () => await serializer.Serialize(Instance, target!, CancellationToken.None);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(target));
    }
}
