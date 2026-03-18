namespace MooVC.ArrayExtensionsTests;

public sealed class WhenToCopyOrEmptyIsCalled
{
    public static IEnumerable<Func<int[]>> GivenAnArrayThenAMatchingArrayIsReturnedData()
    {
        yield return () => [1, 2];
        yield return () => [1];
        yield return () => [];
    }

    public static IEnumerable<Func<(int[] Original, int[] Expected)>> GivenAnArrayAndAPredicateThenAMatchingArrayIsReturnedData()
    {
        yield return () => ([3, 1, 2], [3, 1]);
        yield return () => ([1, 2, 3], [1, 3]);
        yield return () => ([1], [1]);
        yield return () => ([], []);
    }

    public static IEnumerable<Func<string[]?>> GivenAnEmptyArrayThenAnEmptyArrayIsReturnedData()
    {
        yield return () => [];
        yield return () => default;
    }

    [Test]
    [MethodDataSource(nameof(GivenAnArrayThenAMatchingArrayIsReturnedData))]
    public void GivenAnArrayThenAMatchingArrayIsReturned(int[] source)
    {
        // Act
        int[] result = source.ToCopyOrEmpty();

        // Assert
        result.ShouldBe(source);
    }

    [Test]
    [MethodDataSource(nameof(GivenAnArrayAndAPredicateThenAMatchingArrayIsReturnedData))]
    public void GivenAnArrayAndAPredicateThenAMatchingArrayIsReturned(int[] original, int[] expected)
    {
        // Act
        int[] result = original.ToCopyOrEmpty(predicate: value => value != 2);

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    [MethodDataSource(nameof(GivenAnEmptyArrayThenAnEmptyArrayIsReturnedData))]
    public void GivenAnEmptyArrayThenAnEmptyArrayIsReturned(string[]? source)
    {
        // Act
        string[] result = source.ToCopyOrEmpty();

        // Assert
        result.ShouldBeEmpty();
    }

    [Test]
    [MethodDataSource(nameof(GivenAnEmptyArrayThenAnEmptyArrayIsReturnedData))]
    public void GivenAnEmptyArrayAndAPredicateThenAnEmptyArrayIsReturned(string[]? source)
    {
        // Act
        string[] result = source.ToCopyOrEmpty(predicate: value => value != "Aarrgh!");

        // Assert
        result.ShouldBeEmpty();
    }
}