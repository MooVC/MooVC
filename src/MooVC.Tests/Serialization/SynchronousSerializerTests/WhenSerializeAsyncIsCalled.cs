namespace MooVC.Serialization.SynchronousSerializerTests;

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using MooVC.Compression;
using Moq;
using Xunit;

public sealed class WhenSerializeAsyncIsCalled
{
    [Fact]
    public async Task GivenACompressorThenCompressAsyncIsInvokedAsync()
    {
        // Arrange
        string instance = "Something something dark side...";
        var compressor = new Mock<ICompressor>();

        _ = compressor
            .Setup(compressor => compressor.CompressAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync<Stream, CancellationToken?, ICompressor, Stream>((stream, _) => stream);

        var serializer = new TestableSynchronousSerializer(
            compressor: compressor.Object,
            onSerialize: (_, _) => { });

        // Act
        _ = await serializer.SerializeAsync(instance, CancellationToken.None);

        // Assert
        compressor.Verify(c => c.CompressAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task GivenAnInstanceThenDataSerializationIsRequestedAsync()
    {
        // Arrange
        using var stream = new MemoryStream();
        string instance = "Something something dark side...";
        bool wasInvoked = false;

        void Serializer(object input1, object input2)
        {
            _ = input1.Should().Be(instance);
            _ = input2.Should().BeAssignableTo<Stream>();

            wasInvoked = true;
        }

        var serializer = new TestableSynchronousSerializer(onSerialize: Serializer);

        // Act
        IEnumerable<byte> serialized = await serializer.SerializeAsync(instance, CancellationToken.None);

        // Assert
        _ = wasInvoked.Should().BeTrue();
    }

    [Fact]
    public async Task GivenAStreamThenStreamSerializationIsRequestedAsync()
    {
        // Arrange
        using var stream = new MemoryStream();
        string instance = "Something something dark side...";
        bool wasInvoked = false;

        void Serializer(object input1, object input2)
        {
            _ = input1.Should().Be(instance);
            _ = input2.Should().BeAssignableTo<Stream>();

            wasInvoked = true;
        }

        var serializer = new TestableSynchronousSerializer(onSerialize: Serializer);

        // Act
        await serializer.SerializeAsync(instance, stream, CancellationToken.None);

        // Assert
        _ = wasInvoked.Should().BeTrue();
    }

    [Fact]
    public async Task GivenNullInstanceThenDataSerializationIsRequestedAsync()
    {
        // Arrange
        using var stream = new MemoryStream();
        string? instance = default;
        bool wasInvoked = false;

        void Serializer(object input1, object input2)
        {
            _ = input1.Should().Be(instance);
            _ = input2.Should().BeAssignableTo<Stream>();

            wasInvoked = true;
        }

        var serializer = new TestableSynchronousSerializer(onSerialize: Serializer);

        // Act
        IEnumerable<byte> serialized = await serializer.SerializeAsync(instance!, CancellationToken.None);

        // Assert
        _ = wasInvoked.Should().BeTrue();
    }

    [Fact]
    public async Task GivenNullStreamThenThrowsArgumentNullExceptionAsync()
    {
        // Arrange
        string instance = "Something something dark side...";
        var serializer = new TestableSynchronousSerializer(onSerialize: (_, _) => { });
        Stream? target = default;

        // Act
        Func<Task> act = async () => await serializer.SerializeAsync(instance, target!, CancellationToken.None);

        // Assert
        _ = await act.Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName(nameof(target));
    }
}