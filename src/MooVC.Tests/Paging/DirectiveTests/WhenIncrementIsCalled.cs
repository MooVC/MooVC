#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

public sealed class WhenIncrementIsCalled
{
    [Test]
    [Arguments(0, 1, 25)]
    [Arguments(1, 2, 1)]
    [Arguments(4, 5, 10)]
    [Arguments(ushort.MaxValue - 1, ushort.MaxValue, 5)]
    public async Task GivenADirectiveWhenPostIncrementedThenDirectiveIsIncrementedByOne(ushort current, ushort expected, ushort limit)
    {
        // Arrange
        Directive directive = new(Limit: limit, Page: current);

        // Act
        directive++;

        // Assert
        await Assert.That(directive.Limit).IsEqualTo(limit);
        await Assert.That(directive.Page).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenADirectiveAtMaxWhenPostIncrementedThenDirectiveIsNotIncremented()
    {
        // Arrange
        Directive expected = new(Limit: 10, Page: ushort.MaxValue);
        Directive actual = new(Limit: 10, Page: ushort.MaxValue);

        // Act
        actual++;

        // Assert
        await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    [Arguments(0, 1, 25)]
    [Arguments(1, 2, 1)]
    [Arguments(4, 5, 10)]
    [Arguments(ushort.MaxValue - 1, ushort.MaxValue, 5)]
    public async Task GivenADirectiveWhenPreIncrementedThenDirectiveIsIncrementedByOne(ushort current, ushort expected, ushort limit)
    {
        // Arrange
        Directive directive = new(Limit: limit, Page: current);

        // Act
        ++directive;

        // Assert
        await Assert.That(directive.Limit).IsEqualTo(limit);
        await Assert.That(directive.Page).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenADirectiveAtMaxWhenPreIncrementedThenDirectiveIsNotIncremented()
    {
        // Arrange
        Directive expected = new(Limit: 10, Page: ushort.MaxValue);
        Directive actual = new(Limit: 10, Page: ushort.MaxValue);

        // Act
        ++actual;

        // Assert
        await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    [Arguments(0, 2, 2, 25)]
    [Arguments(1, 3, 2, 1)]
    [Arguments(4, 9, 5, 10)]
    public async Task GivenADirectiveWhenIncrementedThenDirectiveIsIncrementedByTheAmount(ushort current, ushort expected, ushort increment, ushort limit)
    {
        // Arrange
        Directive original = new(Limit: limit, Page: current);

        // Act
        Directive actual = original + increment;

        // Assert
        await Assert.That(original.Limit).IsEqualTo(limit);
        await Assert.That(actual.Page).IsEqualTo(expected);
    }

    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(10)]
    [Arguments(ushort.MaxValue)]
    public async Task GivenADirectiveAtMaxWhenIncrementedThenDirectiveIsNotIncremented(ushort increment)
    {
        // Arrange
        Directive expected = new(Limit: 10, Page: ushort.MaxValue);

        // Act
        Directive actual = expected + increment;

        // Assert
        await Assert.That(actual).IsEqualTo(expected);
    }
}
#endif