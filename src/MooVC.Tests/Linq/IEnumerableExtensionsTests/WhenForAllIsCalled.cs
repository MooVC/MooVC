namespace MooVC.Linq.IEnumerableExtensionsTests;

using System.Collections.Concurrent;
using AwesomeAssertions.Specialized;

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
        List<int> enumeration = [1, 2, 3];
        var invocations = new ConcurrentBag<int>();

        void Action(int value)
        {
            invocations.Add(value);
        }

        // Act
        enumeration.ForAll(Action);

        // Assert
        _ = enumeration.TrueForAll(value => invocations.Contains(value)).Should().BeTrue();
        _ = invocations.Should().HaveCount(enumeration.Count);
    }

    [Fact]
    public void GivenAnEnumerationWhenNoActionIsProvidedThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        int[] enumeration = [1, 2, 3];
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
        Action<int>? action = default;
        IEnumerable<int>? enumeration = default;

        // Act
        Action act = () => enumeration.ForAll(action!);

        // Assert
        _ = act.Should().NotThrow<ArgumentNullException>();
    }

    [Theory]
    [InlineData(1, 3)]
    [InlineData(2, 6)]
    [InlineData(3, 9)]
    public async Task GivenAnEnumerationThatRaisesExceptionsWhenAsyncThenAnAggregateExceptionIsThrownContainingAllExceptionsAsync(int mod, int range)
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
    public async Task GivenAnEnumerationWhenAnAsyncActionIsProvidedThenTheActionIsInvokedForEachEnumerationMemberTask()
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
    public async Task GivenAnEnumerationWhenNoAsyncActionIsProvidedThenAnArgumentNullExceptionIsThrown()
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
    public async Task GivenANullEnumerationWhenAnAsyncActionIsProvidedThenTheActionIsGracefullyIgnored()
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
    public async Task GivenANullEnumerationWhenNoAsyncActionIsProvidedThenNoArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int>? enumeration = default;

        // Act
        Func<Task> act = async () => await enumeration.ForAll(default!);

        // Assert
        _ = await act.Should().NotThrowAsync<ArgumentNullException>();
    }
}