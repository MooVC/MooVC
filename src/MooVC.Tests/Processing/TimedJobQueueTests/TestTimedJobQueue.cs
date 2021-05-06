namespace MooVC.Processing.TimedJobQueueTests
{
    using System.Collections.Generic;
    using MooVC.Collections.Generic;

    public sealed class TestTimedJobQueue
        : TimedJobQueue<int>
    {
        private readonly IEnumerable<int> processed;

        public TestTimedJobQueue(TimedProcessor timer, params int[] processed)
            : base(timer)
        {
            this.processed = processed.Snapshot();
        }

        protected override IEnumerable<int> Process(IEnumerable<int> jobs)
        {
            return processed;
        }
    }
}