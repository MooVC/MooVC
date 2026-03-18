#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

public sealed class WhenIncrementIsCalled
{
    [Test]
    [Arguments(0, 1, 25)]
    [Arguments(1, 2, 1)]
    [Arguments(4, 5, 10)]
    [Arguments(ushort.MaxValue - 1, ushort.MaxValue, 5)]
    public void GivenADirectiveWhenPostIncrementedThenDirectiveIsIncrementedByOne(ushort current, ushort expected, ushort limit)
    {
        // Arrange
        Directive directive = new(Limit: limit, Page: current);

        // Act
        directive++;

        // Assert
        directive.Limit.ShouldBe(limit);
        directive.Page.ShouldBe(expected);
    }

    [Test]
    public void GivenADirectiveAtMaxWhenPostIncrementedThenDirectiveIsNotIncremented()
    {
        // Arrange
        Directive expected = new(Limit: 10, Page: ushort.MaxValue);
        Directive actual = new(Limit: 10, Page: ushort.MaxValue);

        // Act
        actual++;

        // Assert
        actual.ShouldBe(expected);
    }

    [Test]
    [Arguments(0, 1, 25)]
    [Arguments(1, 2, 1)]
    [Arguments(4, 5, 10)]
    [Arguments(ushort.MaxValue - 1, ushort.MaxValue, 5)]
    public void GivenADirectiveWhenPreIncrementedThenDirectiveIsIncrementedByOne(ushort current, ushort expected, ushort limit)
    {
        // Arrange
        Directive directive = new(Limit: limit, Page: current);

        // Act
        ++directive;

        // Assert
        directive.Limit.ShouldBe(limit);
        directive.Page.ShouldBe(expected);
    }

    [Test]
    public void GivenADirectiveAtMaxWhenPreIncrementedThenDirectiveIsNotIncremented()
    {
        // Arrange
        Directive expected = new(Limit: 10, Page: ushort.MaxValue);
        Directive actual = new(Limit: 10, Page: ushort.MaxValue);

        // Act
        ++actual;

        // Assert
        actual.ShouldBe(expected);
    }

    [Test]
    [Arguments(0, 2, 2, 25)]
    [Arguments(1, 3, 2, 1)]
    [Arguments(4, 9, 5, 10)]
    public void GivenADirectiveWhenIncrementedThenDirectiveIsIncrementedByTheAmount(ushort current, ushort expected, ushort increment, ushort limit)
    {
        // Arrange
        Directive original = new(Limit: limit, Page: current);

        // Act
        Directive actual = original + increment;

        // Assert
        original.Limit.ShouldBe(limit);
        actual.Page.ShouldBe(expected);
    }

    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(10)]
    [Arguments(ushort.MaxValue)]
    public void GivenADirectiveAtMaxWhenIncrementedThenDirectiveIsNotIncremented(ushort increment)
    {
        // Arrange
        Directive expected = new(Limit: 10, Page: ushort.MaxValue);

        // Act
        Directive actual = expected + increment;

        // Assert
        actual.ShouldBe(expected);
    }
}
#endif