namespace MooVC.Diagnostics
{
    public interface IEmitDiagnostics
    {
        event DiagnosticsEmittedAsyncEventHandler DiagnosticsEmitted;
    }
}