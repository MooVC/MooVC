#if NET6_0_OR_GREATER
namespace MooVC.Serialization.Json.SerializerTests;

using Serializer = MooVC.Serialization.Json.Serializer;

public sealed class WhenSerializeIsCalled
{
    [Fact]
    public async Task GivenAnInstanceThenAValidSequenceIsReturned()
    {
        // Arrange
        var serializer = new Serializer();
        var instance = new TestClass { Property = "Test" };
        CancellationToken cancellationToken = CancellationToken.None;

        // Act
        IEnumerable<byte> result = await serializer.Serialize(instance, cancellationToken);

        // Assert
        _ = result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GivenACancellationThenOperationCanceledExceptionIsThrown()
    {
        // Arrange
        var serializer = new Serializer();
        var instance = new TestClass { Property = "Test" };
        using var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();

        // Act
        Func<Task> act = async () => await serializer.Serialize(instance, cancellationTokenSource.Token);

        // Assert
        _ = await act.Should().ThrowAsync<OperationCanceledException>();
    }

    [Fact]
    public async Task GivenAnInstanceAndStreamThenTheStreamIsPopulatedAsync()
    {
        // Arrange
        var serializer = new Serializer();
        var instance = new TestClass { Property = "Test" };
        using var stream = new MemoryStream();
        CancellationToken cancellationToken = CancellationToken.None;

        // Act
        await serializer.Serialize(instance, stream, cancellationToken);

        // Assert
        _ = stream.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task GivenACancellationThenOperationCanceledExceptionIsThrownAsync()
    {
        // Arrange
        var serializer = new Serializer();
        var instance = new TestClass { Property = "Test" };
        using var stream = new MemoryStream();
        using var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();

        // Act
        Func<Task> act = async () => await serializer.Serialize(instance, stream, cancellationTokenSource.Token);

        // Assert
        _ = await act.Should().ThrowAsync<OperationCanceledException>();
    }
}
#endif