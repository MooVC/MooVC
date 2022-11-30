namespace MooVC.Diagnostics.DiagnosticsRelayTests;

using System;
using Xunit;

public sealed class WhenDiagnosticsRelayIsConstructed
{
    [Fact]
    public void GivenASourceThenAnInstanceIsReturned()
    {
        var source = new DiagnosticsProxy();
        var instance = new DiagnosticsRelay(source);

        Assert.NotNull(instance);
    }

    [Fact]
    public void GivenANullSourceThenAnArgumentNullExceptionIsThrown()
    {
        IEmitDiagnostics? source = default;
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => new DiagnosticsRelay(source!));

        Assert.Equal(nameof(source), exception.ParamName);
    }
}