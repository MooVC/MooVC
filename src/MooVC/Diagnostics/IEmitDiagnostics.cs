namespace MooVC.Diagnostics
{
    public interface IEmitDiagnostics
    {
        event DiagnosticsEmittedEventHandler DiagnosticsEmitted;
    }
}