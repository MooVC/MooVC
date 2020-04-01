namespace MooVC.Threading.CoordinatorTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenApplyIsCalled
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void GivenAnEmptyContextThenAnArgumentNullExceptionIsThrown(string context)
        {
            _ = Assert.Throws<ArgumentNullException>(() => Coordinator.Apply(context, () => { }));
        }

        [Fact]
        public void GivenAnEmptyOperationThenAnArgumentNullExceptionIsThrown()
        {
            _ = Assert.Throws<ArgumentNullException>(() => Coordinator.Apply("Valid", null));
        }

        [Fact]
        public void GivenMultipleThreadsNoConcurrencyExceptionsAreThrown()
        {
            const int ExpectedCount = 5;

            int counter = 0;
            string context = "Test";

            void Operation()
            {
                counter++;
            }

            Task[] tasks = CreateTasks(() => Coordinator.Apply(context, Operation), ExpectedCount);

            Task.WaitAll(tasks);

            Assert.Equal(ExpectedCount, counter);
        }

        [Fact]
        public void GivenMultipleThreadsWithATimeoutSetThenATimeoutExceptionIsThrownForAllBarOne()
        {
            const int ExpectedCount = 5;

            string context = "Test";

            static void Operation()
            {
                Thread.Sleep(250);
            }

            Task[] tasks = CreateTasks(
                () => Coordinator.Apply(
                    context,
                    Operation,
                    timeout: TimeSpan.FromMilliseconds(50)),
                ExpectedCount + 1);

            AggregateException exception = Assert.Throws<AggregateException>(() => Task.WaitAll(tasks));

            Assert.Equal(ExpectedCount, exception.InnerExceptions.Count);
        }

        private Task[] CreateTasks(Action operation, int total)
        {
            var tasks = new List<Task>();

            for (int index = 0; index < total; index++)
            {
                tasks.Add(Task.Run(operation));
            }

            return tasks.ToArray();
        }
    }
}