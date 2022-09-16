namespace MooVC.Diagnostics.DiagnosticsEmitterTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

public sealed class WhenDiagnosticsEmitterIsConstructed
{
    [Fact]
    public void GivenASourceThenAnInstanceIsReturned()
    {
        var source = new DiagnosticsProxy();
        var instance = new DiagnosticsEmitter<IDiagnosticsProxy>(source);

        Assert.NotNull(instance);
    }

    [Fact]
    public void GivenANullSourceThenAnArgumentNullExceptionIsThrown()
    {
        IEmitDiagnostics? source = default;
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => new DiagnosticsEmitter<IEmitDiagnostics>(source!));

        Assert.Equal(nameof(source), exception.ParamName);
    }
}