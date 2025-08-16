namespace MooVC.Linq.IEnumerableExtensionsTests;

public sealed class WhenForIsCalled
{
    [Fact]
    public void GivenANullEnumerationWhenAnActionIsProvidedThenTheActionIsGracefullyIgnored()
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
        wasInvoked.ShouldBeFalse();
    }

    [Fact]
    public void GivenANullEnumerationWhenNoActionIsProvidedThenNoArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int>? enumeration = default;

        // Act
        Action act = () => enumeration.For(default!);

        // Assert
        Should.NotThrow(act);
    }

    [Fact]
    public void GivenAnEnumerationThenTheCorrectIndexIsPassedToTheActionForEachEnumerationMember()
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
        indexes.ShouldBe([0, 1, 2]);
    }

    [Fact]
    public void GivenAnEnumerationWhenAnActionIsProvidedThenTheActionIsInvokedInOrderForEachEnumerationMember()
    {
        // Arrange
        int[] enumeration = [1, 2, 3];
        var invocations = new List<int>();
        int expected = 0;

        void Action(int index, int value)
        {
            index.ShouldBe(expected++);
            invocations.Add(value);
        }

        // Act
        enumeration.For(Action);

        // Assert
        invocations.ShouldBe(enumeration);
    }

    [Fact]
    public void GivenAnEnumerationWhenNoActionIsProvidedThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        int[] enumeration = [1, 2, 3];
        Action<int, int>? action = default;

        // Act
        Action act = () => enumeration.For(action!);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(act);
        exception.ParamName.ShouldBe(nameof(action));
    }
}