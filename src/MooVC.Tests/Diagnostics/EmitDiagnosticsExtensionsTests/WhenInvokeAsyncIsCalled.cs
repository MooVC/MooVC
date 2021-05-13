namespace MooVC.Diagnostics.EmitDiagnosticsExtensionsTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenInvokeAsyncIsCalled
    {
        [Fact]
        public async Task GivenANullSourceWhenNoActionIsProvidedThenNoArgumentNullExceptionIsThrownAsync()
        {
            IEnumerable<DiagnosticEmitter>? source = default;
            Func<DiagnosticEmitter, Task>? action = default;

            _ = await source.InvokeAsync(action!);
        }

        [Fact]
        public async Task GivenASourceAndAnActionWhenDiagnosticsAreEmittedThenDiagnosticsAreReturnedForEachEmitterAsync()
        {
            const int ExpectedCount = 2;

            IEnumerable<DiagnosticEmitter> source = new[]
            {
                new DiagnosticEmitter(true),
                new DiagnosticEmitter(false),
                new DiagnosticEmitter(true),
            };

            IEnumerable<DiagnosticsEmittedEventArgs> diagnostics = await source
                .InvokeAsync(emitter => emitter.ExecuteAsync());

            Assert.Equal(ExpectedCount, diagnostics.Count());
        }

        [Fact]
        public async Task GivenASourceAndAnActionWhenNoDiagnosticsAreEmittedThenNoDiagnosticsAreReturnedAsync()
        {
            IEnumerable<DiagnosticEmitter> source = new[]
            {
                new DiagnosticEmitter(false),
                new DiagnosticEmitter(false),
                new DiagnosticEmitter(false),
            };

            IEnumerable<DiagnosticsEmittedEventArgs> diagnostics = await source
                .InvokeAsync(emitter => emitter.ExecuteAsync());

            Assert.Empty(diagnostics);
        }

        [Fact]
        public async Task GivenASourceWhenNoActionIsProvidedThenNoArgumentNullExceptionIsThrownAsync()
        {
            IEnumerable<DiagnosticEmitter> source = Array.Empty<DiagnosticEmitter>();
            Func<DiagnosticEmitter, Task>? action = default;

            ArgumentNullException exception = await Assert.ThrowsAsync<ArgumentNullException>(
                () => source.InvokeAsync(action!));

            Assert.Equal(nameof(action), exception.ParamName);
        }
    }
}