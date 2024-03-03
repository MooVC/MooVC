namespace MooVC.Linq.EnumerableExtensionsTests;

using System.Collections.Concurrent;
using FluentAssertions.Specialized;

public sealed class WhenForAllAsyncIsCalled
{
    [Theory]
    [InlineData(1, 3)]
    [InlineData(2, 6)]
    [InlineData(3, 9)]
    public async Task GivenAnEnumerationThatRaisesExceptionsThenAnAggregateExceptionIsThrownContainingAllExceptionsAsync(int mod, int range)
    {
        // Arrange
        IEnumerable<int> enumeration = Enumerable.Range(0, range);

        async Task Operation(int value)
        {
            if (value % mod == 0)
            {
                throw new InvalidOperationException();
            }

            await Task.CompletedTask;
        }

        // Act
        Func<Task> act = async () => await enumeration.ForAll(Operation);

        // Assert
        ExceptionAssertions<AggregateException> exception = await act.Should().ThrowAsync<AggregateException>();
        _ = exception.Which.InnerExceptions.Count.Should().Be(range / mod);
    }

    [Fact]
    public async Task GivenAnEnumerationWhenAnActionIsProvidedThenTheActionIsInvokedForEachEnumerationMemberTask()
    {
        // Arrange
        List<int> enumeration = [1, 2, 3];
        var invocations = new ConcurrentBag<int>();

        async Task Operation(int value)
        {
            invocations.Add(value);

            await Task.CompletedTask;
        }

        // Act
        await enumeration.ForAll(Operation);

        // Assert
        _ = enumeration.TrueForAll(value => invocations.Contains(value)).Should().BeTrue();
        _ = invocations.Should().HaveCount(enumeration.Count);
    }

    [Fact]
    public async Task GivenAnEnumerationWhenNoActionIsProvidedThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        int[] enumeration = [1, 2, 3];
        Func<int, Task>? operation = default;

        // Act
        Func<Task> act = async () => await enumeration.ForAll(operation!);

        // Assert
        ExceptionAssertions<ArgumentNullException> exception = await act.Should().ThrowAsync<ArgumentNullException>();
        _ = exception.Which.ParamName.Should().Be(nameof(operation));
    }

    [Fact]
    public async Task GivenANullEnumerationWhenAnActionIsProvidedThenTheActionIsGracefullyIgnored()
    {
        // Arrange
        IEnumerable<int>? enumeration = default;
        bool wasInvoked = false;

        async Task Operation(int value)
        {
            wasInvoked = true;

            await Task.CompletedTask;
        }

        // Act
        await enumeration.ForAll(Operation);

        // Assert
        _ = wasInvoked.Should().BeFalse();
    }

    [Fact]
    public async Task GivenANullEnumerationWhenNoActionIsProvidedThenNoArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int>? enumeration = default;

        // Act
        Func<Task> act = async () => await enumeration.ForAll(default!);

        // Assert
        _ = await act.Should().NotThrowAsync<ArgumentNullException>();
    }
}