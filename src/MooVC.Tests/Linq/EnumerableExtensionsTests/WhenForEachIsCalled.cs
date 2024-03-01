namespace MooVC.Linq.EnumerableExtensionsTests;

using FluentAssertions.Specialized;

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
        _ = invocations.Should().Equal(enumeration);
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
        ExceptionAssertions<ArgumentNullException> exception = act.Should().Throw<ArgumentNullException>();
        _ = exception.Which.ParamName.Should().Be(nameof(action));
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
        _ = wasInvoked.Should().BeFalse();
    }

    [Fact]
    public void GivenANullEnumerationWhenNoActionIsProvidedThenNoArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int>? enumeration = default;

        // Act
        Action act = () => enumeration.ForEach(default!);

        // Assert
        _ = act.Should().NotThrow<ArgumentNullException>();
    }
}