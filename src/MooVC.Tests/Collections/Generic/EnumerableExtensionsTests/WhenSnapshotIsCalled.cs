namespace MooVC.Collections.Generic.EnumerableExtensionsTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public sealed class WhenSnapshotIsCalled
    {
        public static readonly IEnumerable<object[]> GivenAnEnumerableAndAnOrderThenAnArrayMatchingTheOrderIsReturnedData = new[]
        {
            new object[] { new int[] { 3, 1, 2 }, new int[] { 1, 2, 3 } },
            new object[] { new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 } },
            new object[] { new int[] { 1 }, new int[] { 1 } },
            new object[] { new int[0], new int[0] },
        };

        public static readonly IEnumerable<object[]> GivenAnEnumerableThenAMatchingArrayIsReturnedData = new[]
        {
            new object[] { new int[] { 1, 2 } },
            new object[] { new int[] { 1 } },
            new object[] { new int[0] },
        };

        [Theory]
        [MemberData(nameof(GivenAnEnumerableAndAnOrderThenAnArrayMatchingTheOrderIsReturnedData))]
        public void GivenAnEnumerableAndAnOrderThenAnArrayMatchingTheOrderIsReturned(IEnumerable<int> original, IEnumerable<int> expected)
        {
            int[] result = original.Snapshot(element => element);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GivenAnEnumerableThenAMatchingArrayIsReturnedData))]
        public void GivenAnEnumerableThenAMatchingArrayIsReturned(IEnumerable<int> enumerable)
        {
            int[] expected = enumerable.ToArray();

            int[] result = enumerable.Snapshot();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GivenANullEnumerableAndAnOrderThenAnEmptyArrayIsReturned()
        {
            IEnumerable<string> enumerable = null;

            string[] result = enumerable.Snapshot(element => element);

            Assert.Equal(new string[0], result);
        }

        [Fact]
        public void GivenANullEnumerableThenAnEmptyArrayIsReturned()
        {
            IEnumerable<string> enumerable = null;

            string[] result = enumerable.Snapshot();

            Assert.Equal(new string[0], result);
        }
    }
}