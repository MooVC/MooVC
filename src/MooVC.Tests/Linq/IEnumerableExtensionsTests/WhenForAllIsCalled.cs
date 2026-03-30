namespace MooVC.Linq.IEnumerableExtensionsTests;

using System.Collections.Concurrent;

public sealed class WhenForAllIsCalled
{
    [Test]
    [Arguments(1, 3)]
    [Arguments(2, 6)]
    [Arguments(3, 9)]
    public async Task GivenAnEnumerationThatRaisesExceptionsThenAnAggregateExceptionIsThrownContainingAllExceptions(int mod, int range)
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
        AggregateException exception = await Assert.That(act).Throws<AggregateException>().And.IsNotNull();
        _ = await Assert.That(exception.InnerExceptions.Count).IsEqualTo(range / mod);
    }

    [Test]
    [Arguments(1, 3)]
    [Arguments(2, 6)]
    [Arguments(3, 9)]
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
        AggregateException exception = await Assert.That(act).Throws<AggregateException>().And.IsNotNull();
        _ = await Assert.That(exception.InnerExceptions.Count).IsEqualTo(range / mod);
    }

    [Test]
    public async Task GivenAnEnumerationWhenAnActionIsProvidedThenTheActionIsInvokedForEachEnumerationMember()
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
        _ = await Assert.That(enumeration.TrueForAll(value => invocations.Contains(value))).IsTrue();
        _ = await Assert.That(invocations.Count).IsEqualTo(enumeration.Count);
    }

    [Test]
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
        _ = await Assert.That(enumeration.TrueForAll(value => invocations.Contains(value))).IsTrue();
        _ = await Assert.That(invocations.Count).IsEqualTo(enumeration.Count);
    }

    [Test]
    public async Task GivenAnEnumerationWhenNoActionIsProvidedThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        int[] enumeration = [1, 2, 3];
        Action<int>? action = default;

        // Act
        Action act = () => enumeration.ForAll(action!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(action));
    }

    [Test]
    public async Task GivenAnEnumerationWhenNoAsyncActionIsProvidedThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        int[] enumeration = [1, 2, 3];
        Func<int, Task>? operation = default;

        // Act
        Func<Task> act = async () => await enumeration.ForAll(operation!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(operation));
    }

    [Test]
    public async Task GivenANullEnumerationWhenAnActionIsProvidedThenTheActionIsGracefullyIgnored()
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
        _ = await Assert.That(wasInvoked).IsFalse();
    }

    [Test]
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
        _ = await Assert.That(wasInvoked).IsFalse();
    }

    [Test]
    public async Task GivenANullEnumerationWhenNoActionIsProvidedThenNoArgumentNullExceptionIsThrown()
    {
        // Arrange
        Action<int>? action = default;
        IEnumerable<int>? enumeration = default;

        // Act
        Action act = () => enumeration.ForAll(action!);

        // Assert
        _ = await Assert.That(act).ThrowsNothing();
    }

    [Test]
    public async Task GivenANullEnumerationWhenNoAsyncActionIsProvidedThenNoArgumentNullExceptionIsThrown()
    {
        // Arrange
        IEnumerable<int>? enumeration = default;

        // Act
        Func<Task> act = async () => await enumeration.ForAll(default!);

        // Assert
        _ = await Assert.That(act).ThrowsNothing();
    }
}