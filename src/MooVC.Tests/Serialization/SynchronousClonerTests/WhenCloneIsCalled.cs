namespace MooVC.Serialization.SynchronousClonerTests;

public sealed class WhenCloneIsCalled
{
    [Fact]
    public async Task GivenAnInstanceThenInstanceCloningIsRequested()
    {
        // Arrange
        bool wasInvoked = false;
        string instance = "Something something dark side...";

        object Cloner(object input)
        {
            wasInvoked = true;
            return input;
        }

        var cloner = new TestableSynchronousCloner(Cloner);

        // Act
        string clone = await cloner.Clone(instance, CancellationToken.None);

        // Assert
        _ = wasInvoked.Should().BeTrue();
        _ = clone.Should().Be(instance);
    }
}