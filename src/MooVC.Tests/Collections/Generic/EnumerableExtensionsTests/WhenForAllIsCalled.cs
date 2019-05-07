namespace MooVC.Collections.Generic.EnumerableExtensionsTests
{
    using System.Collections.Concurrent;
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
    }
}