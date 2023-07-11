namespace MooVC.Collections.Generic.EnumerableExtensionsTests;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Specialized;
using Xunit;

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
        Func<Task> act = async () => await enumeration.ForAllAsync(Operation);

        // Assert
        ExceptionAssertions<AggregateException> exception = await act.Should().ThrowAsync<AggregateException>();
        _ = exception.Which.InnerExceptions.Count.Should().Be(range / mod);
    }

    [Fact]
    public async Task GivenAnEnumerationWhenAnActionIsProvidedThenTheActionIsInvokedForEachEnumerationMemberTask()
    {
        // Arrange
        int[] enumeration = new[] { 1, 2, 3 };
        var invocations = new ConcurrentBag<int>();

        async Task Operation(int value)
        {
            invocations.Add(value);

            await Task.CompletedTask;
        }

        // Act
        await enumeration.ForAllAsync(Operation);

        // Assert
        _ = enumeration.All(value => invocations.Contains(value)).Should().BeTrue();
        _ = invocations.Should().HaveCount(enumeration.Length);
    }

    [Fact]
    public async Task GivenAnEnumerationWhenNoActionIsProvidedThenAnArgumentNullExceptionIsThrownAsync()
    {
        // Arrange
        int[] enumeration = new[] { 1, 2, 3 };
        Func<int, Task>? operation = default;

        // Act
        Func<Task> act = async () => await enumeration.ForAllAsync(operation!);

        // Assert
        ExceptionAssertions<ArgumentNullException> exception = await act.Should().ThrowAsync<ArgumentNullException>();
        _ = exception.Which.ParamName.Should().Be(nameof(operation));
    }

    [Fact]
    public async Task GivenANullEnumerationWhenAnActionIsProvidedThenTheActionIsGracefullyIgnoredAsync()
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
        await enumeration.ForAllAsync(Operation);

        // Assert
        _ = wasInvoked.Should().BeFalse();
    }

    [Fact]
    public async Task GivenANullEnumerationWhenNoActionIsProvidedThenNoArgumentNullExceptionIsThrownAsync()
    {
        // Arrange
        IEnumerable<int>? enumeration = default;

        // Act
        Func<Task> act = async () => await enumeration.ForAllAsync(default!);

        // Assert
        _ = await act.Should().NotThrowAsync<ArgumentNullException>();
    }
}