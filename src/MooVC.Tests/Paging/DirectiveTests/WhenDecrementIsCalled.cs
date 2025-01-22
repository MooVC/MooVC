#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

public sealed class WhenDecrementIsCalled
{
    [Theory]
    [InlineData(ushort.MaxValue, ushort.MaxValue - 1, 25)]
    [InlineData(2, 1, 1)]
    [InlineData(5, 4, 10)]
    [InlineData(ushort.MinValue + 1, ushort.MinValue, 5)]
    public void GivenADirectiveWhenPostDecrementedThenDirectiveIsDecrementedByOne(ushort current, ushort expected, ushort size)
    {
        // Arrange
        var directive = new Directive(page: current, size: size);

        // Act
        directive--;

        // Assert
        _ = directive.Page.Should().Be(expected);
        _ = directive.Size.Should().Be(size);
    }

    [Fact]
    public void GivenADirectiveAtMinWhenPostDecrementedThenDirectiveIsNotDecremented()
    {
        // Arrange
        var expected = new Directive(page: ushort.MinValue, size: 10);
        var actual = new Directive(page: ushort.MinValue, size: 10);

        // Act
        actual--;

        // Assert
        _ = actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(ushort.MaxValue, ushort.MaxValue - 1, 25)]
    [InlineData(2, 1, 1)]
    [InlineData(5, 4, 10)]
    [InlineData(ushort.MinValue + 1, ushort.MinValue, 5)]
    public void GivenADirectiveWhenPreDecrementedThenDirectiveIsDecrementedByOne(ushort current, ushort expected, ushort size)
    {
        // Arrange
        var directive = new Directive(page: current, size: size);

        // Act
        --directive;

        // Assert
        _ = directive.Page.Should().Be(expected);
        _ = directive.Size.Should().Be(size);
    }

    [Fact]
    public void GivenADirectiveAtMinWhenPreDecrementedThenDirectiveIsNotDecremented()
    {
        // Arrange
        var expected = new Directive(page: ushort.MinValue, size: 10);
        var actual = new Directive(page: ushort.MinValue, size: 10);

        // Act
        --actual;

        // Assert
        _ = actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(2, 1, 2, 25)]
    [InlineData(3, 1, 2, 1)]
    [InlineData(9, 4, 5, 10)]
    public void GivenADirectiveWhenDecrementedThenDirectiveIsDecrementedByTheAmount(ushort current, ushort expected, ushort increment, ushort size)
    {
        // Arrange
        var original = new Directive(page: current, size: size);

        // Act
        Directive actual = original - increment;

        // Assert
        _ = actual.Page.Should().Be(expected);
        _ = original.Size.Should().Be(size);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(ushort.MaxValue)]
    public void GivenADirectiveAtMinWhenDecrementedThenDirectiveIsNotDecremented(ushort decrement)
    {
        // Arrange
        var expected = new Directive(page: ushort.MinValue, size: 10);

        // Act
        Directive actual = expected - decrement;

        // Assert
        _ = actual.Should().Be(expected);
    }
}
#endif