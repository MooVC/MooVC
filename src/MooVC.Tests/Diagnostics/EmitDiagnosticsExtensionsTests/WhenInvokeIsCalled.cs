namespace MooVC.Diagnostics.EmitDiagnosticsExtensionsTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public sealed class WhenInvokeIsCalled
    {
        [Fact]
        public void GivenANullSourceWhenNoActionIsProvidedThenNoArgumentNullExceptionIsThrown()
        {
            IEnumerable<DiagnosticEmitter>? source = default;
            Action<DiagnosticEmitter>? action = default;

            _ = source.Invoke(action!);
        }

        [Fact]
        public void GivenASourceAndAnActionWhenDiagnosticsAreEmittedThenDiagnosticsAreReturnedForEachEmitter()
        {
            const int ExpectedCount = 2;

            IEnumerable<DiagnosticEmitter> source = new[]
            {
                new DiagnosticEmitter(true),
                new DiagnosticEmitter(false),
                new DiagnosticEmitter(true),
            };

            IEnumerable<DiagnosticsEmittedEventArgs> diagnostics = source.Invoke(emitter => emitter.Execute());

            Assert.Equal(ExpectedCount, diagnostics.Count());
        }

        [Fact]
        public void GivenASourceAndAnActionWhenNoDiagnosticsAreEmittedThenNoDiagnosticsAreReturned()
        {
            IEnumerable<DiagnosticEmitter> source = new[]
            {
                new DiagnosticEmitter(false),
                new DiagnosticEmitter(false),
                new DiagnosticEmitter(false),
            };

            IEnumerable<DiagnosticsEmittedEventArgs> diagnostics = source.Invoke(emitter => emitter.Execute());

            Assert.Empty(diagnostics);
        }

        [Fact]
        public void GivenASourceWhenNoActionIsProvidedThenNoArgumentNullExceptionIsThrown()
        {
            IEnumerable<DiagnosticEmitter> source = new DiagnosticEmitter[0];
            Action<DiagnosticEmitter>? action = default;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => source.Invoke(action!));

            Assert.Equal(nameof(action), exception.ParamName);
        }
    }
}