namespace MooVC.Collections.Generic.EnumerableExtensionsTests;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Specialized;
using Xunit;

public sealed class WhenForAllIsCalled
{
    [Theory]
    [InlineData(1, 3)]
    [InlineData(2, 6)]
    [InlineData(3, 9)]
    public void GivenAnEnumerationThatRaisesExceptionsThenAnAggregateExceptionIsThrownContainingAllExceptions(int mod, int range)
    {
        // Arrange
        IEnumerable<int> enumeration = Enumerable.Range(0, range);

        void Action(int value)
        {
            if (value % mod == 0)
            {
                throw new InvalidOperationException();
            }
        }

        // Act
        Action act = () => enumeration.ForAll(Action);

        // Assert
        ExceptionAssertions<AggregateException> exception = act.Should().Throw<AggregateException>();
        _ = exception.Which.InnerExceptions.Count.Should().Be(range / mod);
    }

    [Fact]
    public void GivenAnEnumerationWhenAnActionIsProvidedThenTheActionIsInvokedForEachEnumerationMember()
    {
        // Arrange
        int[] enumeration = new[] { 1, 2, 3 };
        var invocations = new ConcurrentBag<int>();

        void Action(int value)
        {
            invocations.Add(value);
        }

        // Act
        enumeration.ForAll(Action);

        // Assert
        _ = enumeration.All(value => invocations.Contains(value)).Should().BeTrue();
        _ = invocations.Should().HaveCount(enumeration.Length);
    }

    [Fact]
    public void GivenAnEnumerationWhenNoActionIsProvidedThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        int[] enumeration = new[] { 1, 2, 3 };
        Action<int>? action = default;

        // Act
        Action act = () => enumeration.ForAll(action!);

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
        enumeration.ForAll(Action);

        // Assert
        _ = wasInvoked.Should().BeFalse();
    }

    [Fact]
    public void GivenANullEnumerationWhenNoActionIsProvidedThenNoArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int>? enumeration = default;

        // Act
        Action act = () => enumeration.ForAll(default!);

        // Assert
        _ = act.Should().NotThrow<ArgumentNullException>();
    }
}