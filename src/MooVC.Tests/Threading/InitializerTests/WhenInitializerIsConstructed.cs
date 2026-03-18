namespace MooVC.Threading.InitializerTests;

public sealed class WhenInitializerIsConstructed
{
    [Test]
    public async Task GivenAnInitiazerThenAnInstanceIsReturned()
    {
        // Arrange
        static Task<object> Initializer(CancellationToken cancellationToken)
        {
            return Task.FromResult(new object());
        }

        // Act
        Func<Initializer<object>> act = () => new Initializer<object>(Initializer);

        // Assert
        _ = await Assert.That(act).ThrowsNothing();
    }

    [Test]
    public async Task GivenAnNullInitiazerThenAnArgumentExceptionIsThrown()
    {
        // Arrange
        Func<CancellationToken, Task<object>>? initializer = default;

        // Act
        Func<Initializer<object>> act = () => new Initializer<object>(initializer!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>();
        await Assert.That(exception.ParamName).IsEqualTo(nameof(initializer));
    }

    // Additional test cases
    [Test]
    public async Task GivenAnEmptyInitiazerThenAnInstanceIsReturned()
    {
        // Arrange
        static Task<object> Initializer(CancellationToken cancellationToken)
        {
            return Task.FromResult<object>(default!);
        }

        // Act
        Func<Initializer<object>> act = () => new Initializer<object>(Initializer);

        // Assert
        _ = await Assert.That(act).ThrowsNothing();
    }

    [Test]
    public async Task GivenAnInitiazerWithExceptionThenAnInstanceIsReturned()
    {
        // Arrange
        static Task<object> Initializer(CancellationToken cancellationToken)
        {
            throw new InvalidOperationException();
        }

        // Act
        Func<Initializer<object>> act = () => new Initializer<object>(Initializer);

        // Assert
        _ = await Assert.That(act).ThrowsNothing();
    }
}