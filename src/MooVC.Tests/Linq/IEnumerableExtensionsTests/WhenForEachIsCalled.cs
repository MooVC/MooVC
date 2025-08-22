namespace MooVC.Linq.IEnumerableExtensionsTests;

using Shouldly;

public sealed class WhenForEachIsCalled
{
    [Fact]
    public void GivenAnEnumerationWhenAnActionIsProvidedThenTheActionIsInvokedInOrderForEachEnumerationMember()
    {
        // Arrange
        int[] enumeration = [1, 2, 3];
        var invocations = new List<int>();

        void Action(int value)
        {
            invocations.Add(value);
        }

        // Act
        enumeration.ForEach(Action);

        // Assert
        invocations.ShouldBe(enumeration);
    }

    [Fact]
    public void GivenAnEnumerationWhenNoActionIsProvidedThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        int[] enumeration = [1, 2, 3];
        Action<int>? action = default;

        // Act
        Action act = () => enumeration.ForEach(action!);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(act);
        exception.ParamName.ShouldBe(nameof(action));
    }

    [Fact]
    public void GivenANullEnumerationWhenAnActionIsProvidedThenTheActionIsGracefullyIgnored()
    {
        // Arrange
        IEnumerable<int>? enumeration = default;
        bool wasInvoked = false;

        void Action(int value)
        {
            wasInvoked = true;
        }

        // Act
        enumeration.ForEach(Action);

        // Assert
        wasInvoked.ShouldBeFalse();
    }

    [Fact]
    public void GivenANullEnumerationWhenNoActionIsProvidedThenNoArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int>? enumeration = default;

        // Act
        Action act = () => enumeration.ForEach(default!);

        // Assert
        Should.NotThrow(act);
    }
}