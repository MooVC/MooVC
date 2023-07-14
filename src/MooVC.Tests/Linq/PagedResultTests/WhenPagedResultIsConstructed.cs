namespace MooVC.Linq.PagedResultTests;

using System;
using FluentAssertions;
using Xunit;

public sealed class WhenPagedResultIsConstructed
{
    [Theory]
    [InlineData(1, 10)]
    [InlineData(5, 0)]
    [InlineData(0, 100)]
    public void GivenNoValuesThenAllPropertiesAreSetToDefaults(ushort page, ushort size)
    {
        // Arrange
        var request = new Paging(page: page, size: size);

        // Act
        var result = new PagedResult<int>(request);

        // Assert
        _ = result.HasResults.Should().BeFalse();
        _ = result.IsEmpty.Should().BeTrue();
        _ = result.Request.Should().Be(request);
    }

    [Theory]
    [InlineData(1, 10, new[] { 1, 2, 3, 4 })]
    [InlineData(5, 0, new int[0])]
    [InlineData(0, 100, new[] { 1 })]
    public void GivenValuesAndNoTotalThenAllPropertiesAreSet(ushort page, ushort size, int[] values)
    {
        // Arrange
        var request = new Paging(page: page, size: size);

        // Act
        var result = new PagedResult<int>(request, values);

        // Assert
        _ = result.Request.Should().Be(request);
        _ = result.Total.Should().Be((ulong)values.LongLength);
        _ = result.Should().BeEquivalentTo(values);
    }

    [Theory]
    [InlineData(1, 10, 50, new[] { 1, 2, 3, 4 })]
    [InlineData(5, 0, 20, new int[0])]
    [InlineData(0, 100, 0, new[] { 1 })]
    public void GivenValuesAndAnIntTotalThenAllPropertiesAreSet(ushort page, ushort size, int total, int[] values)
    {
        // Arrange
        var request = new Paging(page: page, size: size);

        // Act
        var result = new PagedResult<int>(request, total, values);

        // Assert
        _ = result.Request.Should().Be(request);
        _ = result.Total.Should().Be((ulong)total);
        _ = result.Should().BeEquivalentTo(values);
    }

    [Theory]
    [InlineData(1, 10, 50, new[] { 1, 2, 3, 4 })]
    [InlineData(5, 0, 20, new int[0])]
    [InlineData(0, 100, 0, new[] { 1 })]
    public void GivenValuesAndAUlongTotalThenAllPropertiesAreSet(ushort page, ushort size, ulong total, int[] values)
    {
        // Arrange
        var request = new Paging(page: page, size: size);

        // Act
        var result = new PagedResult<int>(request, total, values);

        // Assert
        _ = result.Request.Should().Be(request);
        _ = result.Total.Should().Be(total);
        _ = result.Should().BeEquivalentTo(values);
    }

    [Theory]
    [InlineData(new int[0])]
    [InlineData(default(int[]))]
    public void GivenEmptyValuesThenEmptyValuesAreSet(int[] values)
    {
        // Arrange
        var request = new Paging(page: 1, size: 120);

        // Act
        var result = new PagedResult<int>(request, 5, values);

        // Assert
        _ = result.HasResults.Should().BeFalse();
        _ = result.IsEmpty.Should().BeTrue();
        _ = result.Should().BeEmpty();
    }

    [Fact]
    public void GivenANullRequestThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        Paging? request = default;

        // Act
        Func<PagedResult<int>> construct = () => new PagedResult<int>(request!, 5, new[] { 1 });

        // Assert
        _ = construct.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be(nameof(request));
    }

    [Fact]
    public void GivenNullValuesThenEmptyValuesAreSet()
    {
        // Arrange
        var request = new Paging(page: 1, size: 120);
        int[]? values = null;

        // Act
        var result = new PagedResult<int>(request, 5, values!);

        // Assert
        _ = result.HasResults.Should().BeFalse();
        _ = result.IsEmpty.Should().BeTrue();
        _ = result.Should().BeEmpty();
    }
}