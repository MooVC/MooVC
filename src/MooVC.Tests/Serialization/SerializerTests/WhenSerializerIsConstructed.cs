namespace MooVC.Serialization.SerializerTests;

public sealed class WhenSerializerIsConstructed
{
    [Test]
    [Arguments(0)]
    [Arguments(-1)]
    public async Task GivenANegativeOrZeroBufferSizeThenThrowsArgumentOutOfRangeException(int bufferSize)
    {
        // Act
        Func<Task> act = () =>
        {
            _ = new TestableSerializer(bufferSize: bufferSize);
            return Task.CompletedTask;
        };

        // Assert
        ArgumentOutOfRangeException exception = await Assert.That(act).Throws<ArgumentOutOfRangeException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(bufferSize));
    }
}
