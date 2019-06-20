namespace MooVC.Collections.Generic.EnumerableExtensionsTests
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public sealed class WhenForAllIsCalled
    {
        [Fact]
        public void GivenANullEnumerationThenTheActionIsGracefullyIgnored()
        {
            int[] enumeration = null;
            bool wasInvoked = false;

            void Action(int value)
            {
                wasInvoked = true;
            }

            enumeration.ForAll(Action);

            Assert.False(wasInvoked);
        }

        [Fact]
        public void GivenAnEnumerationThenTheActionIsInvokedForEachEnumerationMember()
        {
            int[] enumeration = new[] { 1, 2, 3 };
            var invocations = new ConcurrentBag<int>();

            void Action(int value)
            {
                invocations.Add(value);
            }

            enumeration.ForAll(Action);

            Assert.All(enumeration, value => Assert.Contains(value, invocations));
            Assert.Equal(enumeration.Length, invocations.Count);
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 6)]
        [InlineData(3, 9)]
        public void GivenAnEnumerationThatRaisesExceptionsThenAnAggregateExceptionIsThrownContainingAllExceptions(int mod, int range)
        {
            IEnumerable<int> enumeration = Enumerable.Range(0, range);

            void Action(int value)
            {
                if (value % mod == 0)
                {
                    throw new InvalidOperationException();
                }
            }

            AggregateException exception = Assert.Throws<AggregateException>(() => enumeration.ForAll(Action));

            Assert.Equal(range / mod, exception.InnerExceptions.Count);
        }
    }
}