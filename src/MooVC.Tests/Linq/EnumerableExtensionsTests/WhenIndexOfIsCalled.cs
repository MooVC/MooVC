namespace MooVC.Linq.EnumerableExtensionsTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xunit;

    public sealed class WhenIndexOfIsCalled
    {
        [Theory]
        [InlineData(new object[] { new[] { 1, 2, 3 }, 2, 1 })]
        [InlineData(new object[] { new[] { -1, -2, -3 }, -3, 2 })]
        [InlineData(new object[] { new[] { 1, 2, 3 }, 1, 0 })]
        public void GivenAListWithOneMatchingEntryThenTheIndexOfTheMatchingEntryIsReturned(int[] enumeration, int target, int expectedIndex)
        {
            int actualIndex = enumeration.IndexOf(item => item == target);

            Assert.Equal(expectedIndex, actualIndex);
        }

        [Fact]
        public void GivenAListWithNoMatchingEntryTheNegativeOneIsReturned()
        {
            const int ExpectedIndex = -1;
            int[] enumeration = new[] { 1, 2, 3 };

            int actualIndex = enumeration.IndexOf(item => item == 4);

            Assert.Equal(ExpectedIndex, actualIndex);
        }

        [Theory]
        [InlineData(new object[] { new[] { 1, 2, 2 }, 2, 1 })]
        [InlineData(new object[] { new[] { -1, -2, -1 }, -1, 0 })]
        [InlineData(new object[] { new[] { 1, 1, 1 }, 1, 0 })]
        public void GivenAListWithTwoMatchingEntriesThenTheIndexOfTheFirstMatchingEntryIsReturned(int[] enumeration, int target, int expectedIndex)
        {
            int actualIndex = enumeration.IndexOf(item => item == target);

            Assert.Equal(expectedIndex, actualIndex);
        }
    }
}