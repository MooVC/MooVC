#if NET6_0_OR_GREATER
namespace MooVC.Paging.PageTests;

public sealed class WhenPageIsConstructed
{
    [Test]
    [Arguments(1, 10)]
    [Arguments(5, 0)]
    [Arguments(0, 100)]
    public async Task GivenNoValuesThenAllPropertiesAreSetToDefaults(ushort page, ushort limit)
    {
        // Arrange
        Directive directive = new(Limit: limit, Page: page);

        // Act
        var result = new Page<int>(directive, []);

        // Assert
        _ = await Assert.That(result).IsEmpty();
        _ = await Assert.That(result.Count).IsEqualTo(0);
        _ = await Assert.That(result.Directive).IsEqualTo(directive);
        _ = await Assert.That(result.HasTotal).IsFalse();
        _ = await Assert.That(result.Total).IsNull();
    }

    [Test]
    [Arguments(1, 10, new[] { 1, 2, 3, 4 })]
    [Arguments(5, 0, new int[0])]
    [Arguments(0, 100, new[] { 1 })]
    public async Task GivenValuesAndNoTotalThenAllPropertiesAreSet(ushort page, ushort limit, int[] values)
    {
        // Arrange
        Directive directive = new(Limit: limit, Page: page);

        // Act
        var result = new Page<int>(directive, values);

        // Assert
        _ = await Assert.That(result).IsEquivalentTo(values);
        _ = await Assert.That(result.Count).IsEqualTo(values.Length);
        _ = await Assert.That(result.Directive).IsEqualTo(directive);
        _ = await Assert.That(result.HasTotal).IsFalse();
        _ = await Assert.That(result.Total).IsNull();
    }

    [Test]
    [Arguments(1, 10, 50, new[] { 1, 2, 3, 4 })]
    [Arguments(5, 0, 20, new int[0])]
    [Arguments(0, 100, 0, new[] { 1 })]
    public async Task GivenValuesAndAnIntTotalThenAllPropertiesAreSet(ushort page, ushort limit, ulong total, int[] values)
    {
        // Arrange
        Directive directive = new(Limit: limit, Page: page);

        // Act
        var result = new Page<int>(directive, values, total: total);

        // Assert
        _ = await Assert.That(result).IsEquivalentTo(values);
        _ = await Assert.That(result.Count).IsEqualTo(values.Length);
        _ = await Assert.That(result.Directive).IsEqualTo(directive);
        _ = await Assert.That(result.HasTotal).IsTrue();
        _ = await Assert.That(result.Total).IsEqualTo(total);
    }

    [Test]
    public async Task GivenNullValuesThenEmptyValuesAreSet()
    {
        // Arrange
        Directive directive = new(Limit: 120, Page: 1);
        int[]? values = default;
        ulong total = 5;

        // Act
        var result = new Page<int>(directive, values!, total: total);

        // Assert
        _ = await Assert.That(result).IsEmpty();
        _ = await Assert.That(result.Count).IsEqualTo(0);
        _ = await Assert.That(result.Directive).IsEqualTo(directive);
        _ = await Assert.That(result.HasTotal).IsTrue();
        _ = await Assert.That(result.Total).IsEqualTo(total);
    }
}
#endif