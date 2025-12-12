#if NET6_0_OR_GREATER
namespace MooVC.Paging.PageTests;

public sealed class WhenPageIsEnumerated
{
    [Fact]
    public void GivenValuesThenTheEnumeratedValuesAreReturnedInOrder()
    {
        // Arrange
        int[] values = [1, 2, 3, 4, 5];
        Directive directive = default;
        var result = new Page<int>(directive, values);

        // Act and Assert
        int index = 0;

        foreach (int value in result)
        {
            value.ShouldBe(values[index++]);
        }
    }
}
#endif