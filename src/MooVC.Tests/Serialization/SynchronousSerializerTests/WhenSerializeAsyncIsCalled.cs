namespace MooVC.Serialization.SynchronousSerializerTests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenSerializeAsyncIsCalled
    {
        [Fact]
        public async Task GivenAnInstanceThenDataSerializationIsRequestedAsync()
        {
            IEnumerable<byte> data = new byte[] { 1, 2, 3 };
            string instance = "Something something dark side...";
            bool wasInvoked = false;

            object Serializer(object input)
            {
                Assert.Equal(instance, input);

                wasInvoked = true;

                return data;
            }

            var serializer = new TestableSynchronousSerializer(onSerialize: Serializer);
            IEnumerable<byte> serialized = await serializer.SerializeAsync(instance);

            Assert.True(wasInvoked);
            Assert.Equal(data, serialized);
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
                Assert.Equal(stream, input2);

                wasInvoked = true;
            }

            var serializer = new TestableSynchronousSerializer(onSerializeTo: Serializer);
            await serializer.SerializeAsync(instance, stream);

            Assert.True(wasInvoked);
        }
    }
}