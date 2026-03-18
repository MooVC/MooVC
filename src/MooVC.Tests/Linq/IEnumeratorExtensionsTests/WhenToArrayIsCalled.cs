namespace MooVC.Linq.IEnumeratorExtensionsTests;

using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

public sealed class WhenToArrayIsCalled
{
    [Test]
    public async Task GivenANonGenericEnumeratorWhenNotEmptyThenAnArrayIsReturned()
    {
        // Arrange
        int[] values = [1, 2, 3];
        object[] expected = values.Cast<object>().ToArray();
        var list = new List<int>(values);
        IEnumerator enumerator = list.GetEnumerator();

        // Act
        object[] actual = enumerator.ToArray();

        // Assert
        await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenAGenericEnumeratorWhenNotEmptyThenAnArrayIsReturned()
    {
        // Arrange
        int[] expected = [4, 5, 6];
        var list = new List<int>(expected);
        IEnumerator<int> enumerator = list.GetEnumerator();

        // Act
        int[] actual = enumerator.ToArray();

        // Assert
        await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenANullEnumeratorThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerator? enumerator = default;

        // Act
        Action act = () => enumerator!.ToArray();

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>();
        await Assert.That(exception.ParamName).IsEqualTo(nameof(enumerator));
    }

    [Test]
    public async Task GivenANullGenericEnumeratorThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerator<int>? enumerator = default;

        // Act
        Action act = () => enumerator!.ToArray();

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>();
        await Assert.That(exception.ParamName).IsEqualTo(nameof(enumerator));
    }

    [Test]
    [SuppressMessage("Minor Bug", "S4158:Empty collections should not be accessed or iterated", Justification = "It is the objective of the test.")]
    public async Task GivenAnEmptyEnumeratorThenAnEmptyArrayIsReturned()
    {
        // Arrange
        var list = new List<int>();
        IEnumerator enumerator = list.GetEnumerator();

        // Act
        object[] actual = enumerator.ToArray();

        // Assert
        await Assert.That(actual).IsEmpty();
    }

    [Test]
    [SuppressMessage("Minor Bug", "S4158:Empty collections should not be accessed or iterated", Justification = "It is the objective of the test.")]
    public async Task GivenAnEmptyGenericEnumeratorThenAnEmptyArrayIsReturned()
    {
        // Arrange
        var list = new List<int>();
        IEnumerator<int> enumerator = list.GetEnumerator();

        // Act
        int[] actual = enumerator.ToArray();

        // Assert
        await Assert.That(actual).IsEmpty();
    }
}