namespace MooVC.ArrayExtensionsTests;

public sealed class WhenToCopyOrEmptyIsCalled
{
    public static readonly TheoryData<int[]> GivenAnArrayThenAMatchingArrayIsReturnedData = new()
    {
        { [1, 2] },
        { [1] },
        { [] },
    };

    public static readonly TheoryData<int[], int[]> GivenAnArrayAndAPredicateThenAMatchingArrayIsReturnedData = new()
    {
        { [3, 1, 2], [3, 1] },
        { [1, 2, 3], [1, 3] },
        { [1], [1] },
        { [], [] },
    };

    public static readonly TheoryData<string[]?> GivenAnEmptyArrayThenAnEmptyArrayIsReturnedData = new()
    {
        { [] },
        { default },
    };

    [Theory]
    [MemberData(nameof(GivenAnArrayThenAMatchingArrayIsReturnedData))]
    public void GivenAnArrayThenAMatchingArrayIsReturned(int[] source)
    {
        // Act
        int[] result = source.ToCopyOrEmpty();

        // Assert
        result.ShouldBe(source);
    }

    [Theory]
    [MemberData(nameof(GivenAnArrayAndAPredicateThenAMatchingArrayIsReturnedData))]
    public void GivenAnArrayAndAPredicateThenAMatchingArrayIsReturned(int[] original, int[] expected)
    {
        // Act
        int[] result = original.ToCopyOrEmpty(predicate: value => value != 2);

        // Assert
        result.ShouldBe(expected);
    }

    [Theory]
    [MemberData(nameof(GivenAnEmptyArrayThenAnEmptyArrayIsReturnedData))]
    public void GivenAnEmptyArrayThenAnEmptyArrayIsReturned(string[]? source)
    {
        // Act
        string[] result = source.ToCopyOrEmpty();

        // Assert
        result.ShouldBeEmpty();
    }

    [Theory]
    [MemberData(nameof(GivenAnEmptyArrayThenAnEmptyArrayIsReturnedData))]
    public void GivenAnEmptyArrayAndAPredicateThenAnEmptyArrayIsReturned(string[]? source)
    {
        // Act
        string[] result = source.ToCopyOrEmpty(predicate: value => value != "Aarrgh!");

        // Assert
        result.ShouldBeEmpty();
    }
}