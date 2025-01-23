#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

public sealed class WhenDecrementIsCalled
{
    [Theory]
    [InlineData(ushort.MaxValue, ushort.MaxValue - 1, 25)]
    [InlineData(2, 1, 1)]
    [InlineData(5, 4, 10)]
    [InlineData(ushort.MinValue + 1, Directive.FirstPage, 5)]
    public void GivenADirectiveWhenPostDecrementedThenDirectiveIsDecrementedByOne(ushort current, ushort expected, ushort limit)
    {
        // Arrange
        Directive directive = new(Limit: limit, Page: current);

        // Act
        directive--;

        // Assert
        _ = directive.Limit.Should().Be(limit);
        _ = directive.Page.Should().Be(expected);
    }

    [Fact]
    public void GivenADirectiveAtMinWhenPostDecrementedThenDirectiveIsNotDecremented()
    {
        // Arrange
        Directive expected = new(Limit: 10, Page: ushort.MinValue);
        Directive actual = new(Limit: 10, Page: ushort.MinValue);

        // Act
        actual--;

        // Assert
        _ = actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(ushort.MaxValue, ushort.MaxValue - 1, 25)]
    [InlineData(2, 1, 1)]
    [InlineData(5, 4, 10)]
    [InlineData(ushort.MinValue + 1, Directive.FirstPage, 5)]
    public void GivenADirectiveWhenPreDecrementedThenDirectiveIsDecrementedByOne(ushort current, ushort expected, ushort limit)
    {
        // Arrange
        Directive directive = new(Limit: limit, Page: current);

        // Act
        --directive;

        // Assert
        _ = directive.Limit.Should().Be(limit);
        _ = directive.Page.Should().Be(expected);
    }

    [Fact]
    public void GivenADirectiveAtMinWhenPreDecrementedThenDirectiveIsNotDecremented()
    {
        // Arrange
        Directive expected = new(Limit: 10, Page: ushort.MinValue);
        Directive actual = new(Limit: 10, Page: ushort.MinValue);

        // Act
        --actual;

        // Assert
        _ = actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(2, 0, 2, 25)]
    [InlineData(3, 1, 2, 1)]
    [InlineData(9, 4, 5, 10)]
    public void GivenADirectiveWhenDecrementedThenDirectiveIsDecrementedByTheAmount(ushort current, ushort expected, ushort decrement, ushort limit)
    {
        // Arrange
        Directive original = new(Limit: limit, Page: current);

        // Act
        Directive actual = original - decrement;

        // Assert
        _ = actual.Page.Should().Be(expected);
        _ = original.Limit.Should().Be(limit);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(ushort.MaxValue)]
    public void GivenADirectiveAtMinWhenDecrementedThenDirectiveIsNotDecremented(ushort decrement)
    {
        // Arrange
        Directive expected = new(Limit: 10, Page: ushort.MinValue);

        // Act
        Directive actual = expected - decrement;

        // Assert
        _ = actual.Should().Be(expected);
    }
}
#endif