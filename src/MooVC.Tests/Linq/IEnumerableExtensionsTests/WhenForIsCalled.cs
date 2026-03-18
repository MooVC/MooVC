namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenForIsCalled
{
    [Test]
    public async Task GivenANullEnumerationWhenAnActionIsProvidedThenTheActionIsGracefullyIgnored()
    {
        // Arrange
        IEnumerable<int>? enumeration = default;
        bool wasInvoked = false;

        void Action(int index, int value)
        {
            wasInvoked = true;
        }

        // Act
        enumeration.For(Action);

        // Assert
        _ = await Assert.That(wasInvoked).IsFalse();
    }

    [Test]
    public async Task GivenANullEnumerationWhenNoActionIsProvidedThenNoArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int>? enumeration = default;

        // Act
        Action act = () => enumeration.For(default!);

        // Assert
        _ = await Assert.That(act).ThrowsNothing();
    }

    [Test]
    public async Task GivenAnEnumerationThenTheCorrectIndexIsPassedToTheActionForEachEnumerationMember()
    {
        // Arrange
        int[] enumeration = [1, 2, 3];
        var indexes = new List<int>();

        void Action(int index, int value)
        {
            indexes.Add(index);
        }

        // Act
        enumeration.For(Action);

        // Assert
        _ = await Assert.That(indexes).IsEqualTo([0, 1, 2]);
    }

    [Test]
    public async Task GivenAnEnumerationWhenAnActionIsProvidedThenTheActionIsInvokedInOrderForEachEnumerationMember()
    {
        // Arrange
        int[] enumeration = [1, 2, 3];
        var invocations = new List<int>();
        int expected = 0;

        void Action(int index, int value)
        {
            _ = await Assert.That(index).IsEqualTo(expected++);
            invocations.Add(value);
        }

        // Act
        enumeration.For(Action);

        // Assert
        _ = await Assert.That(invocations).IsEqualTo(enumeration);
    }

    [Test]
    public async Task GivenAnEnumerationWhenNoActionIsProvidedThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        int[] enumeration = [1, 2, 3];
        Action<int, int>? action = default;

        // Act
        Action act = () => enumeration.For(action!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(action));
    }
}