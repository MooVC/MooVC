namespace MooVC.Collections.Generic.DictionaryExtensionsTests
{
    using System.Collections.Generic;
    using Xunit;

    public sealed class WhenSnapshotIsCalled
    {
        [Fact]
        public void GivenANullDictionaryThenAnEmptyDictionaryIsReturned()
        {
            IDictionary<string, object>? original = default;
            IDictionary<string, object>? snapshot = original.Snapshot();

            Assert.NotNull(snapshot);
            Assert.Empty(snapshot);
        }

        [Fact]
        public void GivenADictionaryThenACloneIsReturned()
        {
            IDictionary<string, int>? original = new Dictionary<string, int>
            {
                { "First", 1 },
                { "Second", 2 },
            };

            IDictionary<string, int>? snapshot = original.Snapshot();

            Assert.NotSame(original, snapshot);
            Assert.Equal(original, snapshot);
        }
    }
}