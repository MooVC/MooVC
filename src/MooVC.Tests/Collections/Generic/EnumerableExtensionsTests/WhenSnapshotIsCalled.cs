namespace MooVC.Collections.Generic.EnumerableExtensionsTests
{
    using System;
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
        public void GivenAnEnumerableWhenAnOrderIsProvidedThenAnArrayMatchingTheOrderIsReturned(
            IEnumerable<int> original,
            IEnumerable<int> expected)
        {
            int[] result = original.Snapshot(element => element);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GivenAnEnumerableWhenANullOrderIsProvidedThenNoArgumentExceptionIsThrown()
        {
            IEnumerable<int> enumerable = new int[] { 1 };
            Func<int, int>? order = default;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => enumerable.Snapshot(order!));

            Assert.Equal(nameof(order), exception.ParamName);
        }

        [Theory]
        [MemberData(nameof(GivenAnEnumerableThenAMatchingArrayIsReturnedData))]
        public void GivenAnEnumerableWhenNoOrderIsProvidedThenAMatchingArrayIsReturned(IEnumerable<int> enumerable)
        {
            int[] expected = enumerable.ToArray();

            int[] result = enumerable.Snapshot();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GivenANullEnumerableWhenAnOrderIsProvidedThenAnEmptyArrayIsReturned()
        {
            IEnumerable<string>? enumerable = default;

            string[] result = enumerable.Snapshot(element => element);

            Assert.Equal(new string[0], result);
        }

        [Fact]
        public void GivenANullEnumerableWhenANullOrderIsProvidedThenNoArgumentExceptionIsThrown()
        {
            IEnumerable<string>? enumerable = default;
            Func<string, string>? order = default;

            _ = enumerable.Snapshot(order!);
        }

        [Fact]
        public void GivenANullEnumerableWhenNoOrderIsProvidedThenAnEmptyArrayIsReturned()
        {
            IEnumerable<string>? enumerable = default;

            string[] result = enumerable.Snapshot();

            Assert.Equal(new string[0], result);
        }
    }
}