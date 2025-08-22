namespace MooVC.ExceptionExtensionsTests;

public sealed class WhenExplodeIsCalled
{
    [Fact]
    public void GivenANullExceptionThenTheActionIsGracefullyIgnored()
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
        wasInvoked.ShouldBeFalse();
    }

    [Fact]
    public void GivenAnExceptionWithNoInnerExceptionThenTheActionIsInvokedForTheParent()
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
        invocationCount.ShouldBe(ExpectedInvocationCount);
    }

    [Fact]
    public void GivenAnExceptionWithAnInnerExceptionThenTheActionIsInvokedForEachExceptionInHierarchicalOrder()
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
        invocationCount.ShouldBe(ExpectedInvocationCount);
    }

    [Fact]
    public void GivenAnExceptionWithAnInnerExceptionThenTheActionIsInvokedInCorrectOrder()
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
        actualOrder.ShouldBe(expectedOrder);
    }
}