namespace MooVC.Serialization.SynchronousSerializerTests;

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MooVC.Compression;
using Moq;
using Xunit;

public sealed class WhenSerializeAsyncIsCalled
{
    [Fact]
    public async Task GivenACompressorThenCompressAsyncIsInvokedAsync()
    {
        string instance = "Something something dark side...";
        var compressor = new Mock<ICompressor>();

        _ = compressor
            .Setup(compressor => compressor.CompressAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync<Stream, CancellationToken?, ICompressor, Stream>((stream, _) => stream);

        var serializer = new TestableSynchronousSerializer(
            compressor: compressor.Object,
            onSerialize: (_, _) => { });

        _ = await serializer.SerializeAsync(instance);

        compressor.Verify(
            compressor => compressor.CompressAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task GivenAnInstanceThenDataSerializationIsRequestedAsync()
    {
        using var stream = new MemoryStream();
        string instance = "Something something dark side...";
        bool wasInvoked = false;

        void Serializer(object input1, object input2)
        {
            Assert.Equal(instance, input1);
            _ = Assert.IsAssignableFrom<Stream>(input2);

            wasInvoked = true;
        }

        var serializer = new TestableSynchronousSerializer(onSerialize: Serializer);
        IEnumerable<byte> serialized = await serializer.SerializeAsync(instance);

        Assert.True(wasInvoked);
    }

    [Fact]
    public async Task GivenAStreamThenStreamSerializationIsRequestedAsync()
    {
        using var stream = new MemoryStream();
        string instance = "Something something dark side...";
        bool wasInvoked = false;

        void Serializer(object input1, object input2)
        {
            Assert.Equal(instance, input1);
            _ = Assert.IsAssignableFrom<Stream>(input2);

            wasInvoked = true;
        }

        var serializer = new TestableSynchronousSerializer(onSerialize: Serializer);
        await serializer.SerializeAsync(instance, stream);

        Assert.True(wasInvoked);
    }
}