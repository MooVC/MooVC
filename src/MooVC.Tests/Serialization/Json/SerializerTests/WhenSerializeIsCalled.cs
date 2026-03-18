#if NET6_0_OR_GREATER
namespace MooVC.Serialization.Json.SerializerTests;

using Serializer = MooVC.Serialization.Json.Serializer;

public sealed class WhenSerializeIsCalled
{
    [Test]
    public async Task GivenAnInstanceThenAValidSequenceIsReturned()
    {
        // Arrange
        var serializer = new Serializer();
        var instance = new TestClass { Property = "Test" };
        CancellationToken cancellationToken = CancellationToken.None;

        // Act
        IEnumerable<byte> result = await serializer.Serialize(instance, cancellationToken);

        // Assert
        _ = await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task GivenACancellationThenOperationCanceledExceptionIsThrown()
    {
        // Arrange
        var serializer = new Serializer();
        var instance = new TestClass { Property = "Test" };
        using var cancellationTokenSource = new CancellationTokenSource();
        await cancellationTokenSource.CancelAsync();

        // Act
        Func<Task> act = async () => await serializer.Serialize(instance, cancellationTokenSource.Token);

        // Assert
        _ = await Assert.That(act).Throws<OperationCanceledException>();
    }

    [Test]
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
        _ = await Assert.That(stream.Length).IsGreaterThan(0);
    }

    [Test]
    public async Task GivenACancellationThenOperationCanceledExceptionIsThrownAsync()
    {
        // Arrange
        var serializer = new Serializer();
        var instance = new TestClass { Property = "Test" };
        using var stream = new MemoryStream();
        using var cancellationTokenSource = new CancellationTokenSource();
        await cancellationTokenSource.CancelAsync();

        // Act
        Func<Task> act = async () => await serializer.Serialize(instance, stream, cancellationTokenSource.Token);

        // Assert
        _ = await Assert.That(act).Throws<OperationCanceledException>();
    }
}
#endif