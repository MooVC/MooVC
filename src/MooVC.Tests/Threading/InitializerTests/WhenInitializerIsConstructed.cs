namespace MooVC.Threading.InitializerTests;

public sealed class WhenInitializerIsConstructed
{
    [Fact]
    public void GivenAnInitiazerThenAnInstanceIsReturned()
    {
        // Arrange
        static Task<object> Initializer(CancellationToken cancellationToken)
        {
            return Task.FromResult(new object());
        }

        // Act
        Func<Initializer<object>> act = () => new Initializer<object>(Initializer);

        // Assert
        _ = Should.NotThrow(act);
    }

    [Fact]
    public void GivenAnNullInitiazerThenAnArgumentExceptionIsThrown()
    {
        // Arrange
        Func<CancellationToken, Task<object>>? initializer = default;

        // Act
        Func<Initializer<object>> act = () => new Initializer<object>(initializer!);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(act);
        exception.ParamName.ShouldBe(nameof(initializer));
    }

    // Additional test cases
    [Fact]
    public void GivenAnEmptyInitiazerThenAnInstanceIsReturned()
    {
        // Arrange
        static Task<object> Initializer(CancellationToken cancellationToken)
        {
            return Task.FromResult<object>(default!);
        }

        // Act
        Func<Initializer<object>> act = () => new Initializer<object>(Initializer);

        // Assert
        _ = Should.NotThrow(act);
    }

    [Fact]
    public void GivenAnInitiazerWithExceptionThenAnInstanceIsReturned()
    {
        // Arrange
        static Task<object> Initializer(CancellationToken cancellationToken)
        {
            throw new InvalidOperationException();
        }

        // Act
        Func<Initializer<object>> act = () => new Initializer<object>(Initializer);

        // Assert
        _ = Should.NotThrow(act);
    }
}