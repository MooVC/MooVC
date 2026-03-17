#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

public sealed class WhenDecrementIsCalled
{
    [Test]
    [Arguments(ushort.MaxValue, ushort.MaxValue - 1, 25)]
    [Arguments(2, 1, 1)]
    [Arguments(5, 4, 10)]
    [Arguments(ushort.MinValue + 1, Directive.FirstPage, 5)]
    public void GivenADirectiveWhenPostDecrementedThenDirectiveIsDecrementedByOne(ushort current, ushort expected, ushort limit)
    {
        // Arrange
        Directive directive = new(Limit: limit, Page: current);

        // Act
        directive--;

        // Assert
        directive.Limit.ShouldBe(limit);
        directive.Page.ShouldBe(expected);
    }

    [Test]
    public void GivenADirectiveAtMinWhenPostDecrementedThenDirectiveIsNotDecremented()
    {
        // Arrange
        Directive expected = new(Limit: 10, Page: ushort.MinValue);
        Directive actual = new(Limit: 10, Page: ushort.MinValue);

        // Act
        actual--;

        // Assert
        actual.ShouldBe(expected);
    }

    [Test]
    [Arguments(ushort.MaxValue, ushort.MaxValue - 1, 25)]
    [Arguments(2, 1, 1)]
    [Arguments(5, 4, 10)]
    [Arguments(ushort.MinValue + 1, Directive.FirstPage, 5)]
    public void GivenADirectiveWhenPreDecrementedThenDirectiveIsDecrementedByOne(ushort current, ushort expected, ushort limit)
    {
        // Arrange
        Directive directive = new(Limit: limit, Page: current);

        // Act
        --directive;

        // Assert
        directive.Limit.ShouldBe(limit);
        directive.Page.ShouldBe(expected);
    }

    [Test]
    public void GivenADirectiveAtMinWhenPreDecrementedThenDirectiveIsNotDecremented()
    {
        // Arrange
        Directive expected = new(Limit: 10, Page: ushort.MinValue);
        Directive actual = new(Limit: 10, Page: ushort.MinValue);

        // Act
        --actual;

        // Assert
        actual.ShouldBe(expected);
    }

    [Test]
    [Arguments(2, 0, 2, 25)]
    [Arguments(3, 1, 2, 1)]
    [Arguments(9, 4, 5, 10)]
    public void GivenADirectiveWhenDecrementedThenDirectiveIsDecrementedByTheAmount(ushort current, ushort expected, ushort decrement, ushort limit)
    {
        // Arrange
        Directive original = new(Limit: limit, Page: current);

        // Act
        Directive actual = original - decrement;

        // Assert
        actual.Page.ShouldBe(expected);
        original.Limit.ShouldBe(limit);
    }

    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(10)]
    [Arguments(ushort.MaxValue)]
    public void GivenADirectiveAtMinWhenDecrementedThenDirectiveIsNotDecremented(ushort decrement)
    {
        // Arrange
        Directive expected = new(Limit: 10, Page: ushort.MinValue);

        // Act
        Directive actual = expected - decrement;

        // Assert
        actual.ShouldBe(expected);
    }
}
#endif