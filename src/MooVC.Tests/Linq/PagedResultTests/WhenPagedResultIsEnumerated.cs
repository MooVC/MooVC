namespace MooVC.Linq.PagedResultTests;

using FluentAssertions;
using Xunit;

public sealed class WhenPagedResultIsEnumerated
{
    [Fact]
    public void GivenValuesThenTheEnumeratedValuesAreReturnedInOrder()
    {
        // Arrange
        int[] values = new int[] { 1, 2, 3, 4, 5 };
        Paging request = Paging.Default;
        var result = new PagedResult<int>(request, values);

        // Act and Assert
        for (int index = 0; index < values.Length; index++)
        {
            _ = result[index].Should().Be(values[index]);
        }
    }

    [Fact]
    public void GivenValuesAndInvalidIndexThenArgumentOutOfRangeExceptionIsThrown()
    {
        // Arrange
        int[] values = new int[] { 1, 2, 3, 4, 5 };
        Paging request = Paging.Default;
        var result = new PagedResult<int>(request, values);

        // Act
        Action act = () => { int value = result[values.Length]; };

        // Assert
        _ = act.Should().Throw<ArgumentOutOfRangeException>();
    }
}