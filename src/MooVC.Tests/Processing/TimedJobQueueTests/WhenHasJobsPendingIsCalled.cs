namespace MooVC.Processing.TimedJobQueueTests
{
    using Xunit;

    public sealed class WhenHasJobsPendingIsCalled
        : TimedJobQueueTests
    {
        [Fact]
        public void GivenAnEmptyQueueThenAPositiveResponseIsReturned()
        {
            Assert.False(Queue.HasJobsPending);
        }

        [Fact]
        public void GivenAQueueWithJobsThenAPositiveResponseIsReturned()
        {
            Queue.Enqueue(1);

            Assert.True(Queue.HasJobsPending);
        }
    }
}