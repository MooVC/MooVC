#if NET6_0_OR_GREATER
namespace MooVC.Paging.PageTests;

public sealed class WhenPageIsIndexed
{
    [Test]
    [Arguments(2, 1, new[] { 1, 2, 3 })]
    [Arguments(1, 2, new[] { 3, 2, 1 })]
    [Arguments(5, 0, new[] { 5, 4, 3 })]
    public async Task GivenAnIndexThenTheElementAtThatIndexIsReturned(int expected, int index, int[] values)
    {
        // Arrange
        Directive directive = default;
        var result = new Page<int>(directive, values);

        // Act
        int actual = result[index];

        // Assert
        await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    [Arguments(-1, new[] { 1, 2, 3 })]
    [Arguments(3, new[] { 1, 2, 3 })]
    public async Task GivenAnInvalidIndexThenIndexOutOfRangeExceptionIsThrown(int index, int[] values)
    {
        // Arrange
        Directive directive = default;
        var result = new Page<int>(directive, values);

        // Act
        Action act = () => _ = result[index];

        // Assert
        await Assert.That(act).Throws<IndexOutOfRangeException>();
    }
}
#endif