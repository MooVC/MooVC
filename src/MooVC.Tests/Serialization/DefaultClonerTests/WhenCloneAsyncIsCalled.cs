namespace MooVC.Serialization.DefaultClonerTests;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;

public sealed class WhenCloneAsyncIsCalled
{
    [Fact]
    public async Task GivenAnInstanceThenTheSerializerIsInvokedAsync()
    {
        WhenCloneAsyncIsCalled instance = this;
        var serializer = new Mock<ISerializer>();
        var cloner = new DefaultCloner(serializer.Object);
        IEnumerable<byte> binary = new byte[] { 1, 2, 3 };

        _ = serializer
            .Setup(serializer => serializer.SerializeAsync(
                It.IsAny<WhenCloneAsyncIsCalled>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(binary);

        _ = serializer
            .Setup(serializer => serializer.DeserializeAsync<WhenCloneAsyncIsCalled>(
                It.IsAny<IEnumerable<byte>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(this);

        WhenCloneAsyncIsCalled clone = await cloner.CloneAsync(instance);

        serializer.Verify(
            serializer => serializer.SerializeAsync(
                It.IsAny<WhenCloneAsyncIsCalled>(),
                It.IsAny<CancellationToken>()),
            times: Times.Once);

        serializer.Verify(
           serializer => serializer.SerializeAsync(
               It.Is<WhenCloneAsyncIsCalled>(parameter => parameter == instance),
               It.IsAny<CancellationToken>()),
           times: Times.Once);

        serializer.Verify(
            serializer => serializer.DeserializeAsync<WhenCloneAsyncIsCalled>(
                It.IsAny<IEnumerable<byte>>(),
                It.IsAny<CancellationToken>()),
            times: Times.Once);

        serializer.Verify(
            serializer => serializer.DeserializeAsync<WhenCloneAsyncIsCalled>(
                It.Is<IEnumerable<byte>>(parameter => parameter == binary),
                It.IsAny<CancellationToken>()),
            times: Times.Once);

        Assert.Equal(instance, clone);
    }
}