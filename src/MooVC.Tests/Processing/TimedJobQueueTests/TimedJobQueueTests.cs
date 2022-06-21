namespace MooVC.Processing.TimedJobQueueTests;

using System;
using Moq;

public abstract class TimedJobQueueTests
{
    protected TimedJobQueueTests()
    {
        Timer = new Mock<TimedProcessor>(TimeSpan.Zero, TimeSpan.Zero);
        Queue = new TestTimedJobQueue(Timer.Object);
    }

    protected TestTimedJobQueue Queue { get; }

    protected Mock<TimedProcessor> Timer { get; }
}