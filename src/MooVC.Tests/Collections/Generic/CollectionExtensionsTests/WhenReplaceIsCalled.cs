namespace MooVC.Collections.Generic.CollectionExtensionsTests;

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

public sealed class WhenReplaceIsCalled
{
    [Fact]
    public void GivenANullListThenNoArgumentNullExceptionIsThrown()
    {
        // Arrange
        ICollection<int> target = new List<int>();
        IEnumerable<int>? items = default;

        // Act
        Action act = () => target.Replace(items);

        // Assert
        _ = act.Should().NotThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenANullTargetThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        ICollection<int>? target = default;
        int[] items = new[] { 1, 2, 3 };

        // Act
        Action act = () => target!.Replace(items);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void GivenItemsWhenTheTargetIsEmptyThenTheItemsAreAddedToTheTarget()
    {
        // Arrange
        ICollection<int> actual = new List<int>();
        int[] expected = new[] { 1, 2, 3 };

        // Act
        actual.Replace(expected);

        // Assert
        _ = actual.Should().Equal(expected);
    }

    [Fact]
    public void GivenItemsWhenTheTargetIsNotEmptyThenTheItemsAreAddedToTheTargetAndTheExistingEntriesAreRemoved()
    {
        // Arrange
        ICollection<int> actual = new List<int> { 1, 2, 3 };
        int[] expected = new[] { 4, 5, 6 };

        // Act
        actual.Replace(expected);

        // Assert
        _ = actual.Should().Equal(expected);
    }

    [Fact]
    public void GivenAnEmptyItemListWhenTargetIsEmptyThenTargetRemainsEmpty()
    {
        // Arrange
        ICollection<int> actual = new List<int>();
        int[] items = Array.Empty<int>();

        // Act
        actual.Replace(items);

        // Assert
        _ = actual.Should().BeEmpty();
    }

    [Fact]
    public void GivenAnEmptyItemListWhenTargetIsNotEmptyThenTargetBecomesEmpty()
    {
        // Arrange
        ICollection<int> actual = new List<int> { 1, 2, 3 };
        int[] items = Array.Empty<int>();

        // Act
        actual.Replace(items);

        // Assert
        _ = actual.Should().BeEmpty();
    }
}