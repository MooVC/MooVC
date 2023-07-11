namespace MooVC.Collections.Generic.EnumerableExtensionsTests;

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

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
        _ = wasInvoked.Should().BeFalse();
    }

    [Fact]
    public void GivenANullEnumerationWhenNoActionIsProvidedThenNoArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int>? enumeration = default;

        // Act
        Action act = () => enumeration.For(default!);

        // Assert
        _ = act.Should().NotThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenAnEnumerationThenTheCorrectIndexIsPassedToTheActionForEachEnumerationMember()
    {
        // Arrange
        int[] enumeration = new[] { 1, 2, 3 };
        var indexes = new List<int>();

        void Action(int index, int value)
        {
            indexes.Add(index);
        }

        // Act
        enumeration.For(Action);

        // Assert
        _ = indexes.Should().Equal(0, 1, 2);
    }

    [Fact]
    public void GivenAnEnumerationWhenAnActionIsProvidedThenTheActionIsInvokedInOrderForEachEnumerationMember()
    {
        // Arrange
        int[] enumeration = new[] { 1, 2, 3 };
        var invocations = new List<int>();
        int expected = 0;

        void Action(int index, int value)
        {
            _ = index.Should().Be(expected++);
            invocations.Add(value);
        }

        // Act
        enumeration.For(Action);

        // Assert
        _ = invocations.Should().Equal(enumeration);
    }

    [Fact]
    public void GivenAnEnumerationWhenNoActionIsProvidedThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        int[] enumeration = new[] { 1, 2, 3 };
        Action<int, int>? action = default;

        // Act
        Action act = () => enumeration.For(action!);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
            .Which.ParamName.Should().Be(nameof(action));
    }
}