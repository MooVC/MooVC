namespace MooVC.ExceptionExtensionsTests
{
    using System;
    using Xunit;

    public sealed class WhenExplodeIsCalled
    {
        [Fact]
        public void GivenANullExceptionThenTheActionIsGracefullyIgnored()
        {
            Exception? exception = default;
            bool wasInvoked = false;

            void Action(Exception value)
            {
                wasInvoked = true;
            }

            exception.Explode(Action);

            Assert.False(wasInvoked);
        }

        [Fact]
        public void GivenAnExceptionWithNoInnerExceptionThenTheActionIsInvokedForTheParent()
        {
            const int ExpectedInvocationCount = 1;

            Exception exception = new ArgumentException();
            int invocationCount = 0;

            void Action(Exception value)
            {
                invocationCount++;

                Assert.Equal(exception, value);
            }

            exception.Explode(Action);

            Assert.Equal(ExpectedInvocationCount, invocationCount);
        }

        [Fact]
        public void GivenAnExceptionWithAnInnerExceptionThenTheActionIsInvokedForEachExceptionInHierarchicalOrder()
        {
            const int ExpectedInvocationCount = 4;

            var tier3 = new InvalidOperationException();
            var tier2First = new ArgumentException("This is a tier 2 exception with an inner exception.", tier3);
            var tier2Second = new ArgumentNullException();
            var tier1 = new AggregateException(tier2First, tier2Second);

            var expectedOrder = new Exception[] { tier1, tier2First, tier3, tier2Second };
            int invocationCount = 0;

            void Action(Exception value)
            {
                Assert.Equal(expectedOrder[invocationCount], value);
                invocationCount++;
            }

            tier1.Explode(Action);

            Assert.Equal(ExpectedInvocationCount, invocationCount);
        }
    }
}