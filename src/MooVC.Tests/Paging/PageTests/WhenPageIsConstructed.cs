﻿#if NET6_0_OR_GREATER
namespace MooVC.Paging.PageTests;

public sealed class WhenPageIsConstructed
{
    [Theory]
    [InlineData(1, 10)]
    [InlineData(5, 0)]
    [InlineData(0, 100)]
    public void GivenNoValuesThenAllPropertiesAreSetToDefaults(ushort page, ushort size)
    {
        // Arrange
        var directive = new Directive(page: page, size: size);

        // Act
        var result = new Page<int>(directive, []);

        // Assert
        _ = result.Should().BeEmpty();
        _ = result.Count.Should().Be(0);
        _ = result.Directive.Should().Be(directive);
        _ = result.HasTotal.Should().BeFalse();
        _ = result.Total.Should().BeNull();
    }

    [Theory]
    [InlineData(1, 10, new[] { 1, 2, 3, 4 })]
    [InlineData(5, 0, new int[0])]
    [InlineData(0, 100, new[] { 1 })]
    public void GivenValuesAndNoTotalThenAllPropertiesAreSet(ushort page, ushort size, int[] values)
    {
        // Arrange
        var directive = new Directive(page: page, size: size);

        // Act
        var result = new Page<int>(directive, values);

        // Assert
        _ = result.Should().BeEquivalentTo(values);
        _ = result.Count.Should().Be(values.Length);
        _ = result.Directive.Should().Be(directive);
        _ = result.HasTotal.Should().BeFalse();
        _ = result.Total.Should().BeNull();
    }

    [Theory]
    [InlineData(1, 10, 50, new[] { 1, 2, 3, 4 })]
    [InlineData(5, 0, 20, new int[0])]
    [InlineData(0, 100, 0, new[] { 1 })]
    public void GivenValuesAndAnIntTotalThenAllPropertiesAreSet(ushort page, ushort size, ulong total, int[] values)
    {
        // Arrange
        var directive = new Directive(page: page, size: size);

        // Act
        var result = new Page<int>(directive, values, total: total);

        // Assert
        _ = result.Should().BeEquivalentTo(values);
        _ = result.Count.Should().Be(values.Length);
        _ = result.Directive.Should().Be(directive);
        _ = result.HasTotal.Should().BeTrue();
        _ = result.Total.Should().Be(total);
    }

    [Fact]
    public void GivenNullValuesThenEmptyValuesAreSet()
    {
        // Arrange
        var directive = new Directive(page: 1, size: 120);
        int[]? values = null;
        ulong total = 5;

        // Act
        var result = new Page<int>(directive, values!, total: total);

        // Assert
        _ = result.Should().BeEmpty();
        _ = result.Count.Should().Be(0);
        _ = result.Directive.Should().Be(directive);
        _ = result.HasTotal.Should().BeTrue();
        _ = result.Total.Should().Be(total);
    }
}
#endif