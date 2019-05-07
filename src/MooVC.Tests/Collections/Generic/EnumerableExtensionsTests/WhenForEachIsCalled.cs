namespace MooVC.Collections.Generic.EnumerableExtensionsTests
{
    using System.Collections.Generic;
    using Xunit;

    public sealed class WhenForEachIsCalled
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

            enumeration.ForEach(Action);

            Assert.False(wasInvoked);
        }

        [Fact]
        public void GivenAnEnumerationThenTheActionIsInvokedInOrderForEachEnumerationMember()
        {
            int[] enumeration = new[] { 1, 2, 3 };
            var invocations = new List<int>();

            void Action(int value)
            {
                invocations.Add(value);
            }

            enumeration.ForEach(Action);

            Assert.Equal(enumeration, invocations);
        }
    }
}