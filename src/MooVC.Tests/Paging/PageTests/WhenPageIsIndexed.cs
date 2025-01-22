#if NET6_0_OR_GREATER
namespace MooVC.Paging.PageTests;

public sealed class WhenPageIsIndexed
{
    [Theory]
    [InlineData(2, 1, new[] { 1, 2, 3 })]
    [InlineData(1, 2, new[] { 3, 2, 1 })]
    [InlineData(5, 0, new[] { 5, 4, 3 })]
    public void GivenAnIndexThenTheElementAtThatIndexIsReturned(int expected, int index, int[] values)
    {
        // Arrange
        Directive directive = default;
        var result = new Page<int>(directive, values);

        // Act
        int actual = result[index];

        // Assert
        _ = actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(-1, new[] { 1, 2, 3 })]
    [InlineData(3, new[] { 1, 2, 3 })]
    public void GivenAnInvalidIndexThenArgumentOutOfRangeExceptionIsThrown(int index, int[] values)
    {
        // Arrange
        Directive directive = default;
        var result = new Page<int>(directive, values);

        // Act
        Action act = () => _ = result[index];

        // Assert
        _ = act.Should().Throw<ArgumentOutOfRangeException>();
    }
}
#endif