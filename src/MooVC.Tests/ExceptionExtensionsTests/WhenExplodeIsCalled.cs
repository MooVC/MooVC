namespace MooVC.ExceptionExtensionsTests;

public sealed class WhenExplodeIsCalled
{
    [Test]
    public async Task GivenANullExceptionThenTheActionIsGracefullyIgnored()
    {
        // Arrange
        Exception? exception = default;
        bool wasInvoked = false;

        void Action(Exception value)
        {
            wasInvoked = true;
        }

        // Act
        exception.Explode(Action);

        // Assert
        _ = await Assert.That(wasInvoked).IsFalse();
    }

    [Test]
    public async Task GivenAnExceptionWithNoInnerExceptionThenTheActionIsInvokedForTheParent()
    {
        // Arrange
        const int ExpectedInvocationCount = 1;
        Exception exception = new InvalidOperationException("The message is not relevant.");
        int invocationCount = 0;

        void Action(Exception value)
        {
            invocationCount++;
        }

        // Act
        exception.Explode(Action);

        // Assert
        _ = await Assert.That(invocationCount).IsEqualTo(ExpectedInvocationCount);
    }

    [Test]
    public async Task GivenAnExceptionWithAnInnerExceptionThenTheActionIsInvokedForEachExceptionInHierarchicalOrder()
    {
        // Arrange
        const int ExpectedInvocationCount = 4;
        var tier3 = new InvalidOperationException();
        var tier2First = new ArgumentException("This is a tier 2 exception with an inner exception.", tier3);
        var tier2Second = new InvalidOperationException("The message is not relevant.");
        var tier1 = new AggregateException(tier2First, tier2Second);

        int invocationCount = 0;

        void Action(Exception value)
        {
            invocationCount++;
        }

        // Act
        tier1.Explode(Action);

        // Assert
        _ = await Assert.That(invocationCount).IsEqualTo(ExpectedInvocationCount);
    }

    [Test]
    public async Task GivenAnExceptionWithAnInnerExceptionThenTheActionIsInvokedInCorrectOrder()
    {
        // Arrange
        var tier3 = new InvalidOperationException();
        var tier2First = new ArgumentException("This is a tier 2 exception with an inner exception.", tier3);
        var tier2Second = new InvalidOperationException("The message is not relevant.");
        var tier1 = new AggregateException(tier2First, tier2Second);

        var expectedOrder = new List<Exception> { tier1, tier2First, tier3, tier2Second };
        var actualOrder = new List<Exception>();

        void Action(Exception value)
        {
            actualOrder.Add(value);
        }

        // Act
        tier1.Explode(Action);

        // Assert
        _ = await Assert.That(actualOrder).IsEquivalentTo(expectedOrder);
    }
}