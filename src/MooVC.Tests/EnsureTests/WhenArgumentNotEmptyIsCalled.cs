namespace MooVC.EnsureTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using static MooVC.Ensure;

    public sealed class WhenArgumentNotEmptyIsCalled
    {
        [Fact]
        public void GivenAnEmptyGuidThenAnArgumentExceptionIsThrown()
        {
            Guid expected = Guid.Empty;

            ArgumentException exception = Assert.Throws<ArgumentException>(
                () => ArgumentNotEmpty(expected, nameof(expected)));

            Assert.Equal(nameof(expected), exception.ParamName);
        }

        [Fact]
        public void GivenAnEmptyGuidWithAMessageThenAnArgumentExceptionIsThrown()
        {
            const string Message = "Something something dark side...";
            Guid expected = Guid.Empty;

            ArgumentException exception = Assert.Throws<ArgumentException>(
                () => ArgumentNotEmpty(expected, nameof(expected), Message));

            Assert.Equal(nameof(expected), exception.ParamName);
            Assert.StartsWith(Message, exception.Message);
        }

        [Fact]
        public void GivenAnEmptyTimeSpanThenAnArgumentExceptionIsThrown()
        {
            TimeSpan expected = TimeSpan.Zero;

            ArgumentException exception = Assert.Throws<ArgumentException>(
                () => ArgumentNotEmpty(expected, nameof(expected)));

            Assert.Equal(nameof(expected), exception.ParamName);
        }

        [Fact]
        public void GivenAnEmptyTimeSpanWithAMessageThenAnArgumentExceptionIsThrown()
        {
            const string Message = "Something something dark side...";
            TimeSpan expected = TimeSpan.Zero;

            ArgumentException exception = Assert.Throws<ArgumentException>(
                () => ArgumentNotEmpty(expected, nameof(expected), Message));

            Assert.Equal(nameof(expected), exception.ParamName);
            Assert.StartsWith(Message, exception.Message);
        }

        [Fact]
        public void GivenAnEnumerationWithAMessageAndANegativePredicateThenAnArgumentExceptionIsThrown()
        {
            const string Message = "Something something dark side...";
            IEnumerable<int> enumeration = Enumerable.Range(1, 5);

            ArgumentException exception = Assert.Throws<ArgumentException>(
                () => ArgumentNotEmpty(enumeration, nameof(enumeration), Message, predicate: _ => false));

            Assert.Equal(nameof(enumeration), exception.ParamName);
            Assert.StartsWith(Message, exception.Message);
        }

        [Fact]
        public void GivenAnEnumerationWithAMessageAndAPositivePredicateThenASnapshotIsReturned()
        {
            const string Message = "Something something dark side...";
            IEnumerable<int> enumeration = Enumerable.Range(1, 5);

            int[] snapshot = ArgumentNotEmpty(
                enumeration,
                nameof(enumeration),
                Message,
                predicate: _ => true);

            Assert.NotSame(enumeration, snapshot);
            Assert.Equal(enumeration, snapshot);
        }

        [Fact]
        public void GivenAEmptyEnumerationWithAMessageAndNoPredicateThenASnapshotIsReturned()
        {
            const string Message = "Something something dark side...";
            IEnumerable<int> enumeration = Enumerable.Range(1, 5);
            int[] snapshot = ArgumentNotEmpty(enumeration, nameof(enumeration), Message);

            Assert.NotSame(enumeration, snapshot);
            Assert.Equal(enumeration, snapshot);
        }

        [Fact]
        public void GivenAEmptyEnumerationWithNoMessageAndNoPredicateThenASnapshotIsReturned()
        {
            IEnumerable<int> enumeration = Enumerable.Range(1, 5);
            int[] snapshot = ArgumentNotEmpty(enumeration, nameof(enumeration));

            Assert.NotSame(enumeration, snapshot);
            Assert.Equal(enumeration, snapshot);
        }

        [Fact]
        public void GivenAEmptyEnumerationWithAMessageAndAPredicateThenAnArgumentExceptionIsThrown()
        {
            const string Message = "Something something dark side...";
            IEnumerable<int> enumeration = Enumerable.Empty<int>();

            ArgumentException exception = Assert.Throws<ArgumentException>(
                () => ArgumentNotEmpty(enumeration, nameof(enumeration), Message, predicate: _ => true));

            Assert.Equal(nameof(enumeration), exception.ParamName);
            Assert.StartsWith(Message, exception.Message);
        }

        [Fact]
        public void GivenAEmptyEnumerationWithAMessageAndNoPredicateThenAnArgumentExceptionIsThrown()
        {
            const string Message = "Something something dark side...";
            IEnumerable<int> enumeration = Enumerable.Empty<int>();

            ArgumentException exception = Assert.Throws<ArgumentException>(
                () => ArgumentNotEmpty(enumeration, nameof(enumeration), Message));

            Assert.Equal(nameof(enumeration), exception.ParamName);
            Assert.StartsWith(Message, exception.Message);
        }

        [Fact]
        public void GivenAEmptyEnumerationWithNoMessageAndNoPredicateThenAnArgumentExceptionIsThrown()
        {
            IEnumerable<int> enumeration = Enumerable.Empty<int>();

            ArgumentException exception = Assert.Throws<ArgumentException>(
                () => ArgumentNotEmpty(enumeration, nameof(enumeration)));

            Assert.Equal(nameof(enumeration), exception.ParamName);
        }

        [Fact]
        public void GivenANullEnumerationWithAMessageAndAPredicateThenAnArgumentNullExceptionIsThrown()
        {
            const string Message = "Something something dark side...";
            IEnumerable<int>? enumeration = default;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => ArgumentNotEmpty(enumeration, nameof(enumeration), Message, predicate: _ => true));

            Assert.Equal(nameof(enumeration), exception.ParamName);
            Assert.StartsWith(Message, exception.Message);
        }

        [Fact]
        public void GivenANullEnumerationWithAMessageAndNoPredicateThenAnArgumentNullExceptionIsThrown()
        {
            const string Message = "Something something dark side...";
            IEnumerable<int>? enumeration = default;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => ArgumentNotEmpty(enumeration, nameof(enumeration), Message));

            Assert.Equal(nameof(enumeration), exception.ParamName);
            Assert.StartsWith(Message, exception.Message);
        }

        [Fact]
        public void GivenANullEnumerationWithNoMessageAndNoPredicateThenAnArgumentNullExceptionIsThrown()
        {
            IEnumerable<int>? enumeration = default;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => ArgumentNotEmpty(enumeration, nameof(enumeration)));

            Assert.Equal(nameof(enumeration), exception.ParamName);
        }
    }
}