namespace MooVC.Collections.Generic.EnumerableExtensionsTests
{
    using System.Collections.Generic;
    using Xunit;

    public sealed class WhenForIsCalled
    {
        [Fact]
        public void GivenANullEnumerationThenTheActionIsGracefullyIgnored()
        {
            int[] enumeration = null;
            bool wasInvoked = false;

            void Action(int index, int value)
            {
                wasInvoked = true;
            }

            enumeration.For(Action);

            Assert.False(wasInvoked);
        }

        [Fact]
        public void GivenAnEnumerationThenTheActionIsInvokedInOrderForEachEnumerationMember()
        {
            int[] enumeration = new[] { 1, 2, 3 };
            var invocations = new List<int>();
            int expected = 0;

            void Action(int index, int value)
            {
                Assert.Equal(expected++, index);

                invocations.Add(value);
            }

            enumeration.For(Action);

            Assert.Equal(enumeration, invocations);
        }
    }
}