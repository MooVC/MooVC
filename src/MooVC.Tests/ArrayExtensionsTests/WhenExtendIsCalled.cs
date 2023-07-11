namespace MooVC.ArrayExtensionsTests;

using FluentAssertions;
using Xunit;

public sealed class WhenExtendIsCalled
{
    [Fact]
    public void GivenNoInstancesAndNoSourceThenAnEmptyEnumerationIsReturned()
    {
        // Arrange
        int[]? source = default;
        int[]? expected = default;

        // Act
        int[] actual = source.Extend(expected);

        // Assert
        _ = actual.Should().BeEmpty();
    }

    [Fact]
    public void GivenInstancesAndASourceThenTheInstancesAreCombinedWithTheSource()
    {
        // Arrange
        const int ExpectedCount = 6;
        int[]? source = new[] { 1, 2, 3 };
        int[]? expected = new[] { 4, 5, 6 };

        // Act
        int[] actual = source.Extend(expected);

        // Assert
        _ = actual.Should().HaveCount(ExpectedCount);
        _ = actual.Should().Contain(source);
        _ = actual.Should().Contain(expected);
    }

    [Fact]
    public void GivenInstancesAndANullSourceThenTheInstancesAreCombinedWithTheSource()
    {
        // Arrange
        int[]? source = default;
        int[]? expected = new[] { 4, 5, 6 };

        // Act
        int[] actual = source.Extend(expected);

        // Assert
        _ = actual.Should().Equal(expected);
    }

    [Fact]
    public void GivenSourceWithDuplicatesAndInstancesThenTheInstancesAreCombinedWithTheSource()
    {
        // Arrange
        int[]? source = new[] { 1, 2, 3, 1 };
        int[]? expected = new[] { 4, 5, 6, 4 };
        int[]? combined = new[] { 1, 2, 3, 1, 4, 5, 6, 4 };

        // Act
        int[] actual = source.Extend(expected);

        // Assert
        _ = actual.Should().Equal(combined);
    }
}