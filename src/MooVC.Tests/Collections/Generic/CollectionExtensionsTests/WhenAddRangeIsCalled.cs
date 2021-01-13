namespace MooVC.Collections.Generic.CollectionExtensionsTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public sealed class WhenAddRangeIsCalled
    {
        [Fact]
        public void GivenANullListThenNoArgumentNullExcetionIsThrown()
        {
            ICollection<int> target = new List<int>();
            IEnumerable<int>? items = default;

            target.AddRange(items);
        }

        [Fact]
        public void GivenANullTargetThenAnArgumentNullExcetionIsThrown()
        {
            ICollection<int>? target = default;
            int[] items = new[] { 1, 2, 3 };

            _ = Assert.Throws<ArgumentNullException>(() => target!.AddRange(items));
        }

        [Fact]
        public void GivenItemsWhenTheTargetIsEmptyThenTheItemsAreAddedToTheTarget()
        {
            ICollection<int> actual = new List<int>();
            int[] expected = new[] { 1, 2, 3 };

            actual.AddRange(expected);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenItemsWhenTheTargetIsNotEmptyThenTheItemsAreAddedToTheTargetWithoutRemovingTheExistingEntries()
        {
            ICollection<int> actual = new List<int> { 1, 2, 3 };
            int[] items = new[] { 4, 5, 6 };
            IEnumerable<int> expected = Enumerable.Range(1, 6);

            actual.AddRange(items);

            Assert.Equal(expected, actual);
        }
    }
}