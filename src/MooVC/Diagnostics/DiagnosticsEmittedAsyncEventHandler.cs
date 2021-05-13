namespace MooVC.Diagnostics
{
    using System.Threading.Tasks;

    public delegate Task DiagnosticsEmittedAsyncEventHandler(IEmitDiagnostics sender, DiagnosticsEmittedEventArgs e);
}