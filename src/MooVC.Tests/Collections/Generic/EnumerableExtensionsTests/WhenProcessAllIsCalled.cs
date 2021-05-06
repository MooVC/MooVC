namespace MooVC.Collections.Generic.EnumerableExtensionsTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public sealed class WhenProcessAllIsCalled
    {
        [Fact]
        public void GivenANullSourceWhenAnEnumerableResultTransformIsProvidedThenAnEmptySetOfResultsIsReturned()
        {
            IEnumerable<int>? source = default;
            IEnumerable<int> results = source.ProcessAll(value => new[] { value }.AsEnumerable());

            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public void GivenANullSourceWhenATransformIsProvidedThenAnEmptySetOfResultsIsReturned()
        {
            IEnumerable<int>? source = default;
            IEnumerable<int> results = source.ProcessAll(value => value);

            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public void GivenANullSourceWhenNoEnumerableResultTransformIsProvidedThenNoArgumentNullExceptionIsThrown()
        {
            IEnumerable<int>? source = default;
            Func<int, IEnumerable<int>>? transform = default;

            IEnumerable<int> results = source.ProcessAll(transform!);

            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public void GivenANullSourceWhenNoTransformIsProvidedThenNoArgumentNullExceptionIsThrown()
        {
            IEnumerable<int>? source = default;
            Func<int, int>? transform = default;

            IEnumerable<int> results = source.ProcessAll(transform!);

            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public void GivenASourceWhenAnEnumerableResultTransformIsProvidedThenResultsForThatSourceAreReturned()
        {
            IEnumerable<int> source = new[] { 1, 2, 3 };
            IEnumerable<int> expected = new[] { 1, 4, 9 };
            IEnumerable<int> results = source.ProcessAll(value => new[] { value * value }.AsEnumerable());

            Assert.NotNull(results);
            Assert.Contains(results, element => expected.Contains(element));
            Assert.Equal(expected.Count(), results.Count());
        }

        [Fact]
        public void GivenASourceWhenATransformIsProvidedThenResultsForThatSourceAreReturned()
        {
            IEnumerable<int> source = new[] { 1, 2, 3 };
            IEnumerable<int> expected = new[] { 1, 4, 9 };
            IEnumerable<int> results = source.ProcessAll(value => value * value);

            Assert.NotNull(results);
            Assert.Contains(results, element => expected.Contains(element));
            Assert.Equal(expected.Count(), results.Count());
        }

        [Fact]
        public void GivenASourceWhenNoEnumerableResultTransformIsProvidedThenAnArgumentExceptionIsThrown()
        {
            IEnumerable<int> source = new[] { 1, 2, 3 };
            Func<int, IEnumerable<int>>? transform = default;
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => source.ProcessAll(transform!));

            Assert.Equal(nameof(transform), exception.ParamName);
        }

        [Fact]
        public void GivenASourceWhenNoTransformIsProvidedThenAnArgumentExceptionIsThrown()
        {
            IEnumerable<int> source = new[] { 1, 2, 3 };
            Func<int, int>? transform = default;
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => source.ProcessAll(transform!));

            Assert.Equal(nameof(transform), exception.ParamName);
        }
    }
}