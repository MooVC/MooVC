namespace MooVC.Hosting.ThreadSafeHostedServiceTests;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public sealed class WhenThreadSafeHostedServiceIsConstructed
{
    [Fact]
    public void GivenALoggerAndServicesThenAnInstanceIsCreated()
    {
        // Arrange
        ILogger<ThreadSafeHostedService> logger = Substitute.For<ILogger<ThreadSafeHostedService>>();
        IHostedService service = Substitute.For<IHostedService>();

        // Act
        Func<IHostedService> act = () => new ThreadSafeHostedService(logger, [service]);

        // Assert
        _ = act.Should().NotThrow();
    }

    [Fact]
    public void GivenALoggerAndNoServicesThenAnInstanceIsCreated()
    {
        // Arrange
        ILogger<ThreadSafeHostedService> logger = Substitute.For<ILogger<ThreadSafeHostedService>>();
        IHostedService[] services = [];

        // Act
        Func<IHostedService> act = () => new ThreadSafeHostedService(logger, services);

        // Assert
        _ = act.Should().NotThrow();
    }

    [Fact]
    public void GivenALoggerAndNullServicesThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        ILogger<ThreadSafeHostedService> logger = Substitute.For<ILogger<ThreadSafeHostedService>>();
        IHostedService[]? services = default;

        // Act
        Func<IHostedService> act = () => new ThreadSafeHostedService(logger, services!);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(services));
    }

    [Fact]
    public void GivenANullLoggerAndServicesThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        ILogger<ThreadSafeHostedService>? logger = default;
        IHostedService service = Substitute.For<IHostedService>();

        // Act
        Func<IHostedService> act = () => new ThreadSafeHostedService(logger!, [service]);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(logger));
    }
}