namespace MooVC.Linq.IEnumeratorExtensionsTests;

using System.Collections;
using System.Diagnostics.CodeAnalysis;

public sealed class WhenToArrayIsCalled
{
    [Fact]
    public void GivenANonGenericEnumeratorWhenNotEmptyThenAnArrayIsReturned()
    {
        // Arrange
        int[] expected = [1, 2, 3];
        var list = new List<int>(expected);
        IEnumerator enumerator = list.GetEnumerator();

        // Act
        object[] actual = enumerator.ToArray();

        // Assert
        _ = actual.Should().BeEquivalentTo(expected);
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
        _ = actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void GivenANullEnumeratorThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerator? enumerator = default;

        // Act
        Action act = () => enumerator!.ToArray();

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(enumerator));
    }

    [Fact]
    public void GivenANullGenericEnumeratorThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerator<int>? enumerator = default;

        // Act
        Action act = () => enumerator!.ToArray();

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(enumerator));
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
        _ = actual.Should().BeEmpty();
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
        _ = actual.Should().BeEmpty();
    }
}