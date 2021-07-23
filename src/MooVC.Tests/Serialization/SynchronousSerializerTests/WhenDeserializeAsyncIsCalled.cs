namespace MooVC.Serialization.SynchronousSerializerTests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenDeserializeAsyncIsCalled
    {
        [Fact]
        public async Task GivenDataThenDataDeserializationIsRequestedAsync()
        {
            IEnumerable<byte> data = new byte[] { 1, 2, 3 };
            string instance = "Something something dark side...";
            bool wasInvoked = false;

            object Deserializer(object input)
            {
                Assert.Equal(data, input);

                wasInvoked = true;

                return instance;
            }

            var serializer = new TestableSynchronousSerializer(onDeserialize: Deserializer);
            string deserialized = await serializer.DeserializeAsync<string>(data);

            Assert.True(wasInvoked);
            Assert.Equal(instance, deserialized);
        }

        [Fact]
        public async Task GivenAStreamThenStreamDeserializationIsRequestedAsync()
        {
            using var stream = new MemoryStream();
            string instance = "Something something dark side...";
            bool wasInvoked = false;

            object Deserializer(object input)
            {
                Assert.Equal(stream, input);

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