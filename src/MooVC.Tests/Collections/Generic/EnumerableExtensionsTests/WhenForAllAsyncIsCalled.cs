namespace MooVC.Collections.Generic.EnumerableExtensionsTests
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenForAllAsyncIsCalled
    {
        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 6)]
        [InlineData(3, 9)]
        public async Task GivenAnEnumerationThatRaisesExceptionsThenAnAggregateExceptionIsThrownContainingAllExceptionsAsync(
            int mod,
            int range)
        {
            IEnumerable<int> enumeration = Enumerable.Range(0, range);

            async Task Operation(int value)
            {
                if (value % mod == 0)
                {
                    throw new InvalidOperationException();
                }

                await Task.CompletedTask;
            }

            AggregateException exception = await Assert.ThrowsAsync<AggregateException>(
                () => enumeration.ForAllAsync(Operation));

            Assert.Equal(range / mod, exception.InnerExceptions.Count);
        }

        [Fact]
        public async Task GivenAnEnumerationWhenAnActionIsProvidedThenTheActionIsInvokedForEachEnumerationMemberTask()
        {
            int[] enumeration = new[] { 1, 2, 3 };
            var invocations = new ConcurrentBag<int>();

            async Task Operation(int value)
            {
                invocations.Add(value);

                await Task.CompletedTask;
            }

            await enumeration.ForAllAsync(Operation);

            Assert.All(enumeration, value => Assert.Contains(value, invocations));
            Assert.Equal(enumeration.Length, invocations.Count);
        }

        [Fact]
        public async Task GivenAnEnumerationWhenNoActionIsProvidedThenAnArgumentNullExceptionIsThrownAsync()
        {
            int[] enumeration = new[] { 1, 2, 3 };
            Func<int, Task>? operation = default;

            ArgumentNullException exception = await Assert.ThrowsAsync<ArgumentNullException>(
                () => enumeration.ForAllAsync(operation!));

            Assert.Equal(nameof(operation), exception.ParamName);
        }

        [Fact]
        public async Task GivenANullEnumerationWhenAnActionIsProvidedThenTheActionIsGracefullyIgnoredAsync()
        {
            IEnumerable<int>? enumeration = default;
            bool wasInvoked = false;

            async Task Operation(int value)
            {
                wasInvoked = true;

                await Task.CompletedTask;
            }

            await enumeration.ForAllAsync(Operation);

            Assert.False(wasInvoked);
        }

        [Fact]
        public async Task GivenANullEnumerationWhenNoActionIsProvidedThenNoArgumentNullExceptionIsThrownAsync()
        {
            IEnumerable<int>? enumeration = default;

            await enumeration.ForAllAsync(default!);
        }
    }
}