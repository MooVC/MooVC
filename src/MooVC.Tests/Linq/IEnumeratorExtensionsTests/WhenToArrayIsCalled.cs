namespace MooVC.Linq.IEnumeratorExtensionsTests;

using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

public sealed class WhenToArrayIsCalled
{
    [Fact]
    public void GivenANonGenericEnumeratorWhenNotEmptyThenAnArrayIsReturned()
    {
        // Arrange
        int[] values = [1, 2, 3];
        object[] expected = values.Cast<object>().ToArray();
        var list = new List<int>(values);
        IEnumerator enumerator = list.GetEnumerator();

        // Act
        object[] actual = enumerator.ToArray();

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GivenAGenericEnumeratorWhenNotEmptyThenAnArrayIsReturned()
    {
        // Arrange
        int[] expected = [4, 5, 6];
        var list = new List<int>(expected);
        IEnumerator<int> enumerator = list.GetEnumerator();

        // Act
        int[] actual = enumerator.ToArray();

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GivenANullEnumeratorThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerator? enumerator = default;

        // Act
        Action act = () => enumerator!.ToArray();

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(act);
        exception.ParamName.ShouldBe(nameof(enumerator));
    }

    [Fact]
    public void GivenANullGenericEnumeratorThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerator<int>? enumerator = default;

        // Act
        Action act = () => enumerator!.ToArray();

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(act);
        exception.ParamName.ShouldBe(nameof(enumerator));
    }

    [Fact]
    [SuppressMessage("Minor Bug", "S4158:Empty collections should not be accessed or iterated", Justification = "It is the objective of the test.")]
    public void GivenAnEmptyEnumeratorThenAnEmptyArrayIsReturned()
    {
        // Arrange
        var list = new List<int>();
        IEnumerator enumerator = list.GetEnumerator();

        // Act
        object[] actual = enumerator.ToArray();

        // Assert
        actual.ShouldBeEmpty();
    }

    [Fact]
    [SuppressMessage("Minor Bug", "S4158:Empty collections should not be accessed or iterated", Justification = "It is the objective of the test.")]
    public void GivenAnEmptyGenericEnumeratorThenAnEmptyArrayIsReturned()
    {
        // Arrange
        var list = new List<int>();
        IEnumerator<int> enumerator = list.GetEnumerator();

        // Act
        int[] actual = enumerator.ToArray();

        // Assert
        actual.ShouldBeEmpty();
    }
}