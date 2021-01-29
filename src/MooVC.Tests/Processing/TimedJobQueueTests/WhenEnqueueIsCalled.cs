namespace MooVC.Processing.TimedJobQueueTests
{
    using Xunit;

    public sealed class WhenEnqueueIsCalled
        : TimedJobQueueTests
    {
        [Fact]
        public void GivenAJobThenTheJobIsEnqueued()
        {
            Assert.False(Queue.HasJobsPending);

            Queue.Enqueue(1);

            Assert.True(Queue.HasJobsPending);
        }
    }
}