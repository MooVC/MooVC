#if NET6_0_OR_GREATER
namespace MooVC.Paging.PageTests;

public sealed class WhenPageIsConstructed
{
    [Theory]
    [InlineData(1, 10)]
    [InlineData(5, 0)]
    [InlineData(0, 100)]
    public void GivenNoValuesThenAllPropertiesAreSetToDefaults(ushort page, ushort limit)
    {
        // Arrange
        Directive directive = new(Limit: limit, Page: page);

        // Act
        var result = new Page<int>(directive, []);

        // Assert
        result.ShouldBeEmpty();
        result.Count.ShouldBe(0);
        result.Directive.ShouldBe(directive);
        result.HasTotal.ShouldBeFalse();
        result.Total.ShouldBeNull();
    }

    [Theory]
    [InlineData(1, 10, new[] { 1, 2, 3, 4 })]
    [InlineData(5, 0, new int[0])]
    [InlineData(0, 100, new[] { 1 })]
    public void GivenValuesAndNoTotalThenAllPropertiesAreSet(ushort page, ushort limit, int[] values)
    {
        // Arrange
        Directive directive = new(Limit: limit, Page: page);

        // Act
        var result = new Page<int>(directive, values);

        // Assert
        result.ShouldBe(values);
        result.Count.ShouldBe(values.Length);
        result.Directive.ShouldBe(directive);
        result.HasTotal.ShouldBeFalse();
        result.Total.ShouldBeNull();
    }

    [Theory]
    [InlineData(1, 10, 50, new[] { 1, 2, 3, 4 })]
    [InlineData(5, 0, 20, new int[0])]
    [InlineData(0, 100, 0, new[] { 1 })]
    public void GivenValuesAndAnIntTotalThenAllPropertiesAreSet(ushort page, ushort limit, ulong total, int[] values)
    {
        // Arrange
        Directive directive = new(Limit: limit, Page: page);

        // Act
        var result = new Page<int>(directive, values, total: total);

        // Assert
        result.ShouldBe(values);
        result.Count.ShouldBe(values.Length);
        result.Directive.ShouldBe(directive);
        result.HasTotal.ShouldBeTrue();
        result.Total.ShouldBe(total);
    }

    [Fact]
    public void GivenNullValuesThenEmptyValuesAreSet()
    {
        // Arrange
        Directive directive = new(Limit: 120, Page: 1);
        int[]? values = null;
        ulong total = 5;

        // Act
        var result = new Page<int>(directive, values!, total: total);

        // Assert
        result.ShouldBeEmpty();
        result.Count.ShouldBe(0);
        result.Directive.ShouldBe(directive);
        result.HasTotal.ShouldBeTrue();
        result.Total.ShouldBe(total);
    }
}
#endif