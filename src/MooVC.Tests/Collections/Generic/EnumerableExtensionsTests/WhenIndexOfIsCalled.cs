namespace MooVC.Collections.Generic.EnumerableExtensionsTests
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public sealed class WhenIndexOfIsCalled
    {
        [Fact]
        public void GivenAListWhenAPredicateThatYeildsNoMatchingEntryThenNegativeOneIsReturned()
        {
            const int ExpectedIndex = -1;
            int[] enumeration = new[] { 1, 2, 3 };

            int actualIndex = enumeration.IndexOf(item => item == 4);

            Assert.Equal(ExpectedIndex, actualIndex);
        }

        [Theory]
        [InlineData(new object[] { new[] { 1, 2, 3 }, 2, 1 })]
        [InlineData(new object[] { new[] { -1, -2, -3 }, -3, 2 })]
        [InlineData(new object[] { new[] { 1, 2, 3 }, 1, 0 })]
        public void GivenAListWhenAPredicateThatYieldsOneMatchingEntryThenTheIndexOfTheMatchingEntryIsReturned(
            int[] enumeration,
            int target,
            int expectedIndex)
        {
            int actualIndex = enumeration.IndexOf(item => item == target);

            Assert.Equal(expectedIndex, actualIndex);
        }

        [Theory]
        [InlineData(new object[] { new[] { 1, 2, 2 }, 2, 1 })]
        [InlineData(new object[] { new[] { -1, -2, -1 }, -1, 0 })]
        [InlineData(new object[] { new[] { 1, 1, 1 }, 1, 0 })]
        public void GivenAListWhenAPredicateThatYieldsTwoMatchingEntriesThenTheIndexOfTheFirstMatchingEntryIsReturned(
            int[] enumeration,
            int target,
            int expectedIndex)
        {
            int actualIndex = enumeration.IndexOf(item => item == target);

            Assert.Equal(expectedIndex, actualIndex);
        }

        [Fact]
        public void GivenAListWhenNoPredicateIsProvidedThenAnArgumentNullExceptionIsThrown()
        {
            int[] enumeration = new[] { 1, 2, 3 };
            Func<int, bool>? predicate = default;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => enumeration.IndexOf(predicate!));

            Assert.Equal(nameof(predicate), exception.ParamName);
        }

        [Fact]
        public void GivenANullListWhenAPredicateIsProvidedThenNegativeOneIsReturned()
        {
            const int ExpectedIndex = -1;
            IEnumerable<int>? enumeration = default;

            int actualIndex = enumeration.IndexOf(item => item == 4);

            Assert.Equal(ExpectedIndex, actualIndex);
        }

        [Fact]
        public void GivenANullListWhenNoPredicateIsProvidedThenNegativeOneIsReturned()
        {
            const int ExpectedIndex = -1;
            IEnumerable<int>? enumeration = default;

            int actualIndex = enumeration.IndexOf(default!);

            Assert.Equal(ExpectedIndex, actualIndex);
        }
    }
}