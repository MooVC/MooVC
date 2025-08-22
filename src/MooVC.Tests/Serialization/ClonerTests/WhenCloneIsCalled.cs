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
        await serializer.Received(1).Serialize(instance, Arg.Any<CancellationToken>());
        await serializer.Received(1).Deserialize<WhenCloneIsCalled>(binary, Arg.Any<CancellationToken>());

        clone.ShouldBe(instance);
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
        ArgumentNullException exception = await Should.ThrowAsync<ArgumentNullException>(act);
        exception.ParamName.ShouldBe(nameof(original));
    }
}