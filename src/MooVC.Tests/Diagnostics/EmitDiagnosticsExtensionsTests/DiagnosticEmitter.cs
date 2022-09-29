namespace MooVC.Diagnostics.EmitDiagnosticsExtensionsTests;

using System.Threading.Tasks;

public sealed class DiagnosticEmitter
    : IEmitDiagnostics
{
    private readonly bool isEmitting;

    public DiagnosticEmitter(bool isEmitting)
    {
        this.isEmitting = isEmitting;
    }

    public event DiagnosticsEmittedAsyncEventHandler? DiagnosticsEmitted;

    public async Task ExecuteAsync()
    {
        if (isEmitting)
        {
            await DiagnosticsEmitted.PassiveInvokeAsync(this, new DiagnosticsEmittedAsyncEventArgs(message: "Test"));
        }
    }
}