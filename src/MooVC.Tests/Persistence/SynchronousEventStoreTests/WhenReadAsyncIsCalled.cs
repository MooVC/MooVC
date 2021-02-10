namespace MooVC.Persistence.SynchronousEventStoreTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenReadAsyncIsCalled
    {
        [Fact]
        public async Task GivenAnIndexThenTheExpectedItemIsReturnedAsync()
        {
            const int ExpectedIndex = 1;
            object expectedItem = new object();

            var store = new TestableSynchronousEventStore(readByIndex: index =>
            {
                Assert.Equal(ExpectedIndex, index);

                return expectedItem;
            });

            object? actualItem = await store.ReadAsync(ExpectedIndex);

            Assert.Equal(expectedItem, actualItem);
        }

        [Fact]
        public async Task GivenALastIndexAndANumberToReadThenTheExpectedItemsAreReturnedAsync()
        {
            const int ExpectedLast = 5;
            const int ExpectedNumber = 30;

            object[] expected = new[] { new object(), new object() };

            var store = new TestableSynchronousEventStore(readFromIndex: (last, number) =>
            {
                Assert.Equal(ExpectedLast, last);
                Assert.Equal(ExpectedNumber, number);

                return expected;
            });

            IEnumerable<object> actual = await store.ReadAsync(ExpectedLast, numberToRead: ExpectedNumber);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task GivenAnIndexWhenAnExceptionOccursThenTheExceptionIsThrownAsync()
        {
            var store = new TestableSynchronousEventStore();

            _ = await Assert.ThrowsAsync<NotImplementedException>(
                () => store.ReadAsync(3));
        }

        [Fact]
        public async Task GivenLastIndexAndANumberWhenAnExceptionOccursThenTheExceptionIsThrownAsync()
        {
            var store = new TestableSynchronousEventStore();

            _ = await Assert.ThrowsAsync<NotImplementedException>(
                () => store.ReadAsync(3, numberToRead: 2));
        }
    }
}