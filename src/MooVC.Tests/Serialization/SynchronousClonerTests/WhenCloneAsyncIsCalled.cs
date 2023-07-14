namespace MooVC.Serialization.SynchronousClonerTests;

using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

public sealed class WhenCloneAsyncIsCalled
{
    [Fact]
    public async Task GivenAnInstanceThenInstanceCloningIsRequestedAsync()
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
        string clone = await cloner.CloneAsync(instance, CancellationToken.None);

        // Assert
        _ = wasInvoked.Should().BeTrue();
        _ = clone.Should().Be(instance);
    }
}