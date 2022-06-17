namespace MooVC.Collections.Generic.CollectionExtensionsTests;

using System;
using System.Collections.Generic;
using Xunit;

public sealed class WhenReplaceIsCalled
{
    [Fact]
    public void GivenANullListThenNoArgumentNullExcetionIsThrown()
    {
        ICollection<int> target = new List<int>();
        IEnumerable<int>? items = default;

        target.Replace(items);
    }

    [Fact]
    public void GivenANullTargetThenAnArgumentNullExcetionIsThrown()
    {
        ICollection<int>? target = default;
        int[] items = new[] { 1, 2, 3 };

        _ = Assert.Throws<ArgumentNullException>(() => target!.Replace(items));
    }

    [Fact]
    public void GivenItemsWhenTheTargetIsEmptyThenTheItemsAreAddedToTheTarget()
    {
        ICollection<int> actual = new List<int>();
        int[] expected = new[] { 1, 2, 3 };

        actual.Replace(expected);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenItemsWhenTheTargetIsNotEmptyThenTheItemsAreAddedToTheTargetAndTheExistingEntriesAreRemoved()
    {
        ICollection<int> actual = new List<int> { 1, 2, 3 };
        int[] expected = new[] { 4, 5, 6 };

        actual.Replace(expected);

        Assert.Equal(expected, actual);
    }
}