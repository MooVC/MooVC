namespace MooVC.Diagnostics.EmitDiagnosticsExtensionsTests
{
    public sealed class DiagnosticEmitter
        : IEmitDiagnostics
    {
        private readonly bool isEmitting;

        public DiagnosticEmitter(bool isEmitting)
        {
            this.isEmitting = isEmitting;
        }

        public event DiagnosticsEmittedEventHandler? DiagnosticsEmitted;

        public void Execute()
        {
            if (isEmitting)
            {
                DiagnosticsEmitted?.Invoke(this, new DiagnosticsEmittedEventArgs());
            }
        }
    }
}