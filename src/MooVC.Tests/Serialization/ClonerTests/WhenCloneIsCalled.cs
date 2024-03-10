namespace MooVC.Serialization.ClonerTests;

public sealed class WhenCloneIsCalled
{
    [Fact]
    public async Task GivenAnInstanceThenTheSerializerIsInvoked()
    {
        // Arrange
        WhenCloneIsCalled instance = this;
        ISerializer serializer = Substitute.For<ISerializer>();
        var cloner = new Cloner(serializer);
        IEnumerable<byte> binary = [1, 2, 3];

        _ = serializer
            .Serialize(instance, Arg.Any<CancellationToken>())
            .Returns(binary);

        _ = serializer
            .Deserialize<WhenCloneIsCalled>(binary, Arg.Any<CancellationToken>())
            .Returns(this);

        // Act
        WhenCloneIsCalled clone = await cloner.Clone(instance, CancellationToken.None);

        // Assert
        _ = await serializer.Received(1).Serialize(instance, Arg.Any<CancellationToken>());
        _ = await serializer.Received(1).Deserialize<WhenCloneIsCalled>(binary, Arg.Any<CancellationToken>());

        _ = clone.Should().Be(instance);
    }

    [Fact]
    public async Task GivenNullInstanceThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        WhenCloneIsCalled original = default!;
        ISerializer serializer = Substitute.For<ISerializer>();
        var cloner = new Cloner(serializer);

        // Act
        Func<Task> act = async () => await cloner.Clone(original, CancellationToken.None);

        // Assert
        _ = await act.Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName(nameof(original));
    }
}