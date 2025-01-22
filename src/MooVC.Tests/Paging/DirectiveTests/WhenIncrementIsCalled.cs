#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

public sealed class WhenIncrementIsCalled
{
    [Theory]
    [InlineData(0, 2, 25)]
    [InlineData(1, 2, 1)]
    [InlineData(4, 5, 10)]
    [InlineData(ushort.MaxValue - 1, ushort.MaxValue, 5)]
    public void GivenADirectiveWhenPostIncrementedThenDirectiveIsIncrementedByOne(ushort current, ushort expected, ushort size)
    {
        // Arrange
        var directive = new Directive(page: current, size: size);

        // Act
        directive++;

        // Assert
        _ = directive.Page.Should().Be(expected);
        _ = directive.Size.Should().Be(size);
    }

    [Fact]
    public void GivenADirectiveAtMaxWhenPostIncrementedThenDirectiveIsNotIncremented()
    {
        // Arrange
        var expected = new Directive(page: ushort.MaxValue, size: 10);
        var actual = new Directive(page: ushort.MaxValue, size: 10);

        // Act
        actual++;

        // Assert
        _ = actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, 2, 25)]
    [InlineData(1, 2, 1)]
    [InlineData(4, 5, 10)]
    [InlineData(ushort.MaxValue - 1, ushort.MaxValue, 5)]
    public void GivenADirectiveWhenPreIncrementedThenDirectiveIsIncrementedByOne(ushort current, ushort expected, ushort size)
    {
        // Arrange
        var directive = new Directive(page: current, size: size);

        // Act
        ++directive;

        // Assert
        _ = directive.Page.Should().Be(expected);
        _ = directive.Size.Should().Be(size);
    }

    [Fact]
    public void GivenADirectiveAtMaxWhenPreIncrementedThenDirectiveIsNotIncremented()
    {
        // Arrange
        var expected = new Directive(page: ushort.MaxValue, size: 10);
        var actual = new Directive(page: ushort.MaxValue, size: 10);

        // Act
        ++actual;

        // Assert
        _ = actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, 3, 2, 25)]
    [InlineData(1, 3, 2, 1)]
    [InlineData(4, 9, 5, 10)]
    public void GivenADirectiveWhenIncrementedThenDirectiveIsIncrementedByTheAmount(ushort current, ushort expected, ushort increment, ushort size)
    {
        // Arrange
        var original = new Directive(page: current, size: size);

        // Act
        Directive actual = original + increment;

        // Assert
        _ = actual.Page.Should().Be(expected);
        _ = original.Size.Should().Be(size);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(ushort.MaxValue)]
    public void GivenADirectiveAtMaxWhenIncrementedThenDirectiveIsNotIncremented(ushort increment)
    {
        // Arrange
        var expected = new Directive(page: ushort.MaxValue, size: 10);

        // Act
        Directive actual = expected + increment;

        // Assert
        _ = actual.Should().Be(expected);
    }
}
#endif