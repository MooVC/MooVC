namespace MooVC.Serialization.SynchronousSerializerTests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MooVC.Compression;
    using MooVC.IO;
    using Moq;
    using Xunit;

    public sealed class WhenDeserializeAsyncIsCalled
    {
        [Fact]
        public async Task GivenACompressorThenCompressAsyncIsInvokedAsync()
        {
            var compressor = new Mock<ICompressor>();

            _ = compressor
                .Setup(compressor => compressor.DecompressAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken?>()))
                .ReturnsAsync<Stream, CancellationToken?, ICompressor, Stream>((stream, _) => stream);

            var serializer = new TestableSynchronousSerializer(
                compressor: compressor.Object,
                onDeserialize: instance => "Something irrelevant");

            using var source = new MemoryStream();
            _ = await serializer.DeserializeAsync<string>(source);

            compressor.Verify(
                compressor => compressor.DecompressAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken?>()),
                Times.Once);
        }

        [Fact]
        public async Task GivenDataThenDataDeserializationIsRequestedAsync()
        {
            IEnumerable<byte> expected = new byte[] { 1, 2, 3 };
            string instance = "Something something dark side...";
            bool wasInvoked = false;

            object Deserializer(object input)
            {
                Stream stream = Assert.IsAssignableFrom<Stream>(input);
                IEnumerable<byte> actual = stream.GetBytes();

                Assert.Equal(expected, actual);

                wasInvoked = true;

                return instance;
            }

            var serializer = new TestableSynchronousSerializer(onDeserialize: Deserializer);
            string deserialized = await serializer.DeserializeAsync<string>(expected);

            Assert.True(wasInvoked);
            Assert.Equal(instance, deserialized);
        }

        [Fact]
        public async Task GivenAStreamThenStreamDeserializationIsRequestedAsync()
        {
            IEnumerable<byte> expected = new byte[] { 1, 2, 3 };
            using var stream = new MemoryStream(expected.ToArray());
            string instance = "Something something dark side...";
            bool wasInvoked = false;

            object Deserializer(object input)
            {
                Stream stream = Assert.IsAssignableFrom<Stream>(input);
                IEnumerable<byte> actual = stream.GetBytes();

                Assert.Equal(expected, actual);

                wasInvoked = true;

                return instance;
            }

            var serializer = new TestableSynchronousSerializer(onDeserialize: Deserializer);
            string deserialized = await serializer.DeserializeAsync<string>(stream);

            Assert.True(wasInvoked);
            Assert.Equal(instance, deserialized);
        }
    }
}