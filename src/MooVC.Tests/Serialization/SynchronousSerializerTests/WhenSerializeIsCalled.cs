namespace MooVC.Serialization.SynchronousSerializerTests;

using System.IO;
using MooVC.Compression;

public sealed class WhenSerializeIsCalled
{
    [Fact]
    public async Task GivenACompressorThenCompressAsyncIsInvoked()
    {
        // Arrange
        string instance = "Something something dark side...";
        ICompressor compressor = Substitute.For<ICompressor>();

        compressor
            .Compress(Arg.Any<Stream>(), Arg.Any<CancellationToken>())
            .Returns(info => info.Arg<Stream>());

        var serializer = new TestableSynchronousSerializer(
            compressor: compressor,
            onSerialize: (_, _) => { });

        // Act
        await serializer.Serialize(instance, CancellationToken.None);

        // Assert
        await compressor.Received().Compress(Arg.Any<Stream>(), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task GivenAnInstanceThenDataSerializationIsRequested()
    {
        // Arrange
        using var stream = new MemoryStream();
        string instance = "Something something dark side...";
        bool wasInvoked = false;

        void Serializer(object input1, object input2)
        {
            input1.ShouldBe(instance);
            input2.ShouldBeAssignableTo<Stream>();

            wasInvoked = true;
        }

        var serializer = new TestableSynchronousSerializer(onSerialize: Serializer);

        // Act
        await serializer.Serialize(instance, CancellationToken.None);

        // Assert
        wasInvoked.ShouldBeTrue();
    }

    [Fact]
    public async Task GivenAStreamThenStreamSerializationIsRequested()
    {
        // Arrange
        using var stream = new MemoryStream();
        string instance = "Something something dark side...";
        bool wasInvoked = false;

        void Serializer(object input1, object input2)
        {
            input1.ShouldBe(instance);
            input2.ShouldBeAssignableTo<Stream>();

            wasInvoked = true;
        }

        var serializer = new TestableSynchronousSerializer(onSerialize: Serializer);

        // Act
        await serializer.Serialize(instance, stream, CancellationToken.None);

        // Assert
        wasInvoked.ShouldBeTrue();
    }

    [Fact]
    public async Task GivenNullInstanceThenDataSerializationIsRequested()
    {
        // Arrange
        using var stream = new MemoryStream();
        string? instance = default;
        bool wasInvoked = false;

        void Serializer(object input1, object input2)
        {
            input1.ShouldBe(instance);
            input2.ShouldBeAssignableTo<Stream>();

            wasInvoked = true;
        }

        var serializer = new TestableSynchronousSerializer(onSerialize: Serializer);

        // Act
        await serializer.Serialize(instance!, CancellationToken.None);

        // Assert
        wasInvoked.ShouldBeTrue();
    }

    [Fact]
    public async Task GivenNullStreamThenThrowsArgumentNullException()
    {
        // Arrange
        string instance = "Something something dark side...";
        var serializer = new TestableSynchronousSerializer(onSerialize: (_, _) => { });
        Stream? target = default;

        // Act
        Func<Task> act = async () => await serializer.Serialize(instance, target!, CancellationToken.None);

        // Assert
        ArgumentNullException exception = await Should.ThrowAsync<ArgumentNullException>(act);
        exception.ParamName.ShouldBe(nameof(target));
    }
}