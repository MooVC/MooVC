namespace MooVC.Threading.CoordinatorTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenApplyAsyncIsCalled
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task GivenAnEmptyContextThenAnArgumentNullExceptionIsThrownAsync(string? context)
        {
            _ = await Assert.ThrowsAsync<ArgumentNullException>(
                () => Coordinator.ApplyAsync(context!, () => Task.CompletedTask));
        }

        [Fact]
        public async Task GivenAnEmptyOperationThenAnArgumentNullExceptionIsThrownAsync()
        {
            Func<Task>? operation = default;

            _ = await Assert.ThrowsAsync<ArgumentNullException>(
                () => Coordinator.ApplyAsync("Valid", operation!));
        }

        [Fact]
        public async Task GivenAnExceptionThenTheExceptionIsThrownAsync()
        {
            var expected = new InvalidOperationException();

            Task Operation()
            {
                throw expected;
            }

            InvalidOperationException actual = await Assert.ThrowsAsync<InvalidOperationException>(
                () => Coordinator.ApplyAsync("Valid", Operation));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task GivenMultipleThreadsNoConcurrencyExceptionsAreThrownAsync()
        {
            const int ExpectedCount = 5;

            int counter = 0;
            string context = "Test";

            Task Operation()
            {
                counter++;

                return Task.CompletedTask;
            }

            Task[] tasks = CreateTasks(() => Coordinator.ApplyAsync(context, Operation), ExpectedCount);

            await Task.WhenAll(tasks);

            Assert.Equal(ExpectedCount, counter);
        }

        private static Task[] CreateTasks(Func<Task> operation, int total)
        {
            var tasks = new List<Task>();

            for (int index = 0; index < total; index++)
            {
                tasks.Add(operation());
            }

            return tasks.ToArray();
        }
    }
}