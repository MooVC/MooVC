#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

using System.Collections.Generic;

public sealed class WhenIncrementIsCalled
{
    [Theory]
    [InlineData(0, 1, 25)]
    [InlineData(1, 2, 1)]
    [InlineData(4, 5, 10)]
    [InlineData(ushort.MaxValue - 1, ushort.MaxValue, 5)]
    public void GivenADirectiveWhenPostIncrementedThenDirectiveIsIncrementedByOne(ushort current, ushort expected, ushort limit)
    {
        // Arrange
        Directive directive = new(Limit: limit, Page: current);

        // Act
        directive++;

        // Assert
        _ = directive.Limit.Should().Be(limit);
        _ = directive.Page.Should().Be(expected);
    }

    [Fact]
    public void GivenADirectiveAtMaxWhenPostIncrementedThenDirectiveIsNotIncremented()
    {
        // Arrange
        Directive expected = new(Limit: 10, Page: ushort.MaxValue);
        Directive actual = new(Limit: 10, Page: ushort.MaxValue);

        // Act
        actual++;

        // Assert
        _ = actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, 1, 25)]
    [InlineData(1, 2, 1)]
    [InlineData(4, 5, 10)]
    [InlineData(ushort.MaxValue - 1, ushort.MaxValue, 5)]
    public void GivenADirectiveWhenPreIncrementedThenDirectiveIsIncrementedByOne(ushort current, ushort expected, ushort limit)
    {
        // Arrange
        Directive directive = new(Limit: limit, Page: current);

        // Act
        ++directive;

        // Assert
        _ = directive.Limit.Should().Be(limit);
        _ = directive.Page.Should().Be(expected);
    }

    [Fact]
    public void GivenADirectiveAtMaxWhenPreIncrementedThenDirectiveIsNotIncremented()
    {
        // Arrange
        Directive expected = new(Limit: 10, Page: ushort.MaxValue);
        Directive actual = new(Limit: 10, Page: ushort.MaxValue);

        // Act
        ++actual;

        // Assert
        _ = actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, 2, 2, 25)]
    [InlineData(1, 3, 2, 1)]
    [InlineData(4, 9, 5, 10)]
    public void GivenADirectiveWhenIncrementedThenDirectiveIsIncrementedByTheAmount(ushort current, ushort expected, ushort increment, ushort limit)
    {
        // Arrange
        Directive original = new(Limit: limit, Page: current);

        // Act
        Directive actual = original + increment;

        // Assert
        _ = original.Limit.Should().Be(limit);
        _ = actual.Page.Should().Be(expected);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(ushort.MaxValue)]
    public void GivenADirectiveAtMaxWhenIncrementedThenDirectiveIsNotIncremented(ushort increment)
    {
        // Arrange
        Directive expected = new(Limit: 10, Page: ushort.MaxValue);

        // Act
        Directive actual = expected + increment;

        // Assert
        _ = actual.Should().Be(expected);
    }
}
#endif