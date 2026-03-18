#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

public sealed class WhenDecrementIsCalled
{
    [Test]
    [Arguments(ushort.MaxValue, ushort.MaxValue - 1, 25)]
    [Arguments(2, 1, 1)]
    [Arguments(5, 4, 10)]
    [Arguments(ushort.MinValue + 1, Directive.FirstPage, 5)]
    public async Task GivenADirectiveWhenPostDecrementedThenDirectiveIsDecrementedByOne(ushort current, ushort expected, ushort limit)
    {
        // Arrange
        Directive directive = new(Limit: limit, Page: current);

        // Act
        directive--;

        // Assert
        _ = await Assert.That(directive.Limit).IsEqualTo(limit);
        _ = await Assert.That(directive.Page).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenADirectiveAtMinWhenPostDecrementedThenDirectiveIsNotDecremented()
    {
        // Arrange
        Directive expected = new(Limit: 10, Page: ushort.MinValue);
        Directive actual = new(Limit: 10, Page: ushort.MinValue);

        // Act
        actual--;

        // Assert
        _ = await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    [Arguments(ushort.MaxValue, ushort.MaxValue - 1, 25)]
    [Arguments(2, 1, 1)]
    [Arguments(5, 4, 10)]
    [Arguments(ushort.MinValue + 1, Directive.FirstPage, 5)]
    public async Task GivenADirectiveWhenPreDecrementedThenDirectiveIsDecrementedByOne(ushort current, ushort expected, ushort limit)
    {
        // Arrange
        Directive directive = new(Limit: limit, Page: current);

        // Act
        --directive;

        // Assert
        _ = await Assert.That(directive.Limit).IsEqualTo(limit);
        _ = await Assert.That(directive.Page).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenADirectiveAtMinWhenPreDecrementedThenDirectiveIsNotDecremented()
    {
        // Arrange
        Directive expected = new(Limit: 10, Page: ushort.MinValue);
        Directive actual = new(Limit: 10, Page: ushort.MinValue);

        // Act
        --actual;

        // Assert
        _ = await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    [Arguments(2, 0, 2, 25)]
    [Arguments(3, 1, 2, 1)]
    [Arguments(9, 4, 5, 10)]
    public async Task GivenADirectiveWhenDecrementedThenDirectiveIsDecrementedByTheAmount(ushort current, ushort expected, ushort decrement, ushort limit)
    {
        // Arrange
        Directive original = new(Limit: limit, Page: current);

        // Act
        Directive actual = original - decrement;

        // Assert
        _ = await Assert.That(actual.Page).IsEqualTo(expected);
        _ = await Assert.That(original.Limit).IsEqualTo(limit);
    }

    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(10)]
    [Arguments(ushort.MaxValue)]
    public async Task GivenADirectiveAtMinWhenDecrementedThenDirectiveIsNotDecremented(ushort decrement)
    {
        // Arrange
        Directive expected = new(Limit: 10, Page: ushort.MinValue);

        // Act
        Directive actual = expected - decrement;

        // Assert
        _ = await Assert.That(actual).IsEqualTo(expected);
    }
}
#endif