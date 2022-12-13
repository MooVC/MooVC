namespace MooVC.Diagnostics;

using System.Threading.Tasks;

/// <summary>
/// Represents the method that will handle the <see cref="IEmitDiagnostics.DiagnosticsEmitted"/> event.
/// </summary>
/// <param name="sender">The object that raised the event.</param>
/// <param name="e">An object containing information about the diagnostics.</param>
/// <returns>A task representing the asynchronous operation.</returns>
public delegate Task DiagnosticsEmittedAsyncEventHandler(IEmitDiagnostics sender, DiagnosticsEmittedAsyncEventArgs e);