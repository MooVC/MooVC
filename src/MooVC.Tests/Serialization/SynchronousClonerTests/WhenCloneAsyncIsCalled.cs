namespace MooVC.Serialization.SynchronousClonerTests;

using System.Threading.Tasks;
using Xunit;

public sealed class WhenCloneAsyncIsCalled
{
    [Fact]
    public async Task GivenAnInstanceThenInstanceCloningIsRequestedAsync()
    {
        bool wasInvoked = false;
        string instance = "Something something dark side...";

        object Cloner(object input)
        {
            wasInvoked = true;

            return input;
        }

        var cloner = new TestableSynchronousCloner(Cloner);
        string clone = await cloner.CloneAsync(instance, CancellationToken.None);

        Assert.True(wasInvoked);
        Assert.Equal(instance, clone);
    }
}