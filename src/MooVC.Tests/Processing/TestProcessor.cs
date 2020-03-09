namespace MooVC.Processing
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public sealed class TestProcessor
        : Processor
    {
        private readonly Action @continue;
        private readonly Func<bool> start;
        private readonly Func<bool> stop;

        public TestProcessor(Action @continue = default, Func<bool> start = default, Func<bool> stop = default)
        {
            this.@continue = @continue;
            this.start = start;
            this.stop = stop;
        }

        protected override void PerformContinue()
        {
            @continue?.Invoke();
        }

        protected override bool PerformStart()
        {
            return start is { }
                ? start()
                : false;
        }

        protected override bool PerformStop()
        {
            return stop is { }
                ? stop()
                : false;
        }
    }
}
