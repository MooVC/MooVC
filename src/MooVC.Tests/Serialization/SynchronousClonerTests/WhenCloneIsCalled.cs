namespace MooVC.Serialization.SynchronousClonerTests;

public sealed class WhenCloneIsCalled
{
    [Test]
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
        _ = await Assert.That(wasInvoked).IsTrue();
        _ = await Assert.That(clone).IsEqualTo(instance);
    }
}