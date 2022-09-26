namespace MooVC.Diagnostics.DiagnosticsRelayExtensions;

using System.Threading.Tasks;
using Xunit;

public sealed class WhenTryEmitAsyncIsCalled
    : IEmitDiagnostics
{
    private readonly IDiagnosticsRelay diagnostics;

    public WhenTryEmitAsyncIsCalled()
    {
        diagnostics = new DiagnosticsRelay(this);
    }

    public event DiagnosticsEmittedAsyncEventHandler DiagnosticsEmitted
    {
        add => diagnostics.DiagnosticsEmitted += value;
        remove => diagnostics.DiagnosticsEmitted -= value;
    }

    [Fact]
    public async Task GivenARelayThenTheEventIsEmitted()
    {
        const string Expected = "Test";

        bool wasEmitted = false;

        diagnostics.DiagnosticsEmitted += (sender, e) =>
        {
            Assert.Equal(Expected, e.Message);

            wasEmitted = true;

            return Task.CompletedTask;
        };

        await diagnostics
            .TryEmitAsync(message: Expected)
            .ConfigureAwait(false);

        Assert.True(wasEmitted);
    }

    [Fact]
    public async Task GivenNoRelayThenNothingHappens()
    {
        IDiagnosticsRelay? diagnostics = default;

        await diagnostics
            .TryEmitAsync()
            .ConfigureAwait(false);
    }
}