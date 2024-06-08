#if NET6_0_OR_GREATER
namespace MooVC.Serialization.Json.SerializerTests;

using Serializer = MooVC.Serialization.Json.Serializer;

public sealed class WhenDeserializeIsCalled
{
    [Fact]
    public async Task GivenAValidSequenceThenAnInstanceIsReturned()
    {
        // Arrange
        var serializer = new Serializer();
        var instance = new TestClass { Property = "Test" };
        CancellationToken cancellationToken = CancellationToken.None;
        IEnumerable<byte> sequence = await serializer.Serialize(instance, cancellationToken);

        // Act
        TestClass result = await serializer.Deserialize<TestClass>(sequence, cancellationToken);

        // Assert
        _ = result.Should().NotBeNull();
        _ = result.Property.Should().Be(instance.Property);
    }

    [Fact]
    public async Task GivenACancellationThenOperationCanceledExceptionIsThrown()
    {
        // Arrange
        var serializer = new Serializer();
        byte[] sequence = [1, 2, 3, 4];
        using var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();

        // Act
        Func<Task> act = async () => await serializer.Deserialize<TestClass>(sequence, cancellationTokenSource.Token);

        // Assert
        _ = await act.Should().ThrowAsync<OperationCanceledException>();
    }

    [Fact]
    public async Task GivenAValidStreamThenAnInstanceIsReturnedAsync()
    {
        // Arrange
        var serializer = new Serializer();
        var instance = new TestClass { Property = "Test" };
        using var stream = new MemoryStream();
        CancellationToken cancellationToken = CancellationToken.None;
        await serializer.Serialize(instance, stream, cancellationToken);
        stream.Position = 0;

        // Act
        TestClass result = await serializer.Deserialize<TestClass>(stream, cancellationToken);

        // Assert
        _ = result.Should().NotBeNull();
        _ = result.Property.Should().Be(instance.Property);
    }

    [Fact]
    public async Task GivenACancellationThenOperationCanceledExceptionIsThrownAsync()
    {
        // Arrange
        var serializer = new Serializer();
        using var stream = new MemoryStream([1, 2, 3, 4]);
        using var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();

        // Act
        Func<Task> act = async () => await serializer.Deserialize<TestClass>(stream, cancellationTokenSource.Token);

        // Assert
        _ = await act.Should().ThrowAsync<OperationCanceledException>();
    }
}
#endif