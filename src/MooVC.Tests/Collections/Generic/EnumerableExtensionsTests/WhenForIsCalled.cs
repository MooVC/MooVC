namespace MooVC.Collections.Generic.EnumerableExtensionsTests
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public sealed class WhenForIsCalled
    {
        [Fact]
        public void GivenANullEnumerationWhenAnActionIsProvidedThenTheActionIsGracefullyIgnored()
        {
            IEnumerable<int>? enumeration = default;
            bool wasInvoked = false;

            void Action(int index, int value)
            {
                wasInvoked = true;
            }

            enumeration.For(Action);

            Assert.False(wasInvoked);
        }

        [Fact]
        public void GivenANullEnumerationWhenNoActionIsProvidedThenNoArgumentNullExceptionIsThrown()
        {
            IEnumerable<int>? enumeration = default;

            enumeration.For(default!);
        }

        [Fact]
        public void GivenAnEnumerationWhenAnActionIsProvidedThenTheActionIsInvokedInOrderForEachEnumerationMember()
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

        [Fact]
        public void GivenAnEnumerationWhenNoActionIsProvidedThenAnArgumentNullExceptionIsThrown()
        {
            int[] enumeration = new[] { 1, 2, 3 };
            Action<int, int>? action = default;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => enumeration.For(action!));

            Assert.Equal(nameof(action), exception.ParamName);
        }
    }
}