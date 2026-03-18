namespace MooVC.Hosting.ThreadSafeHostedServiceTests;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public sealed class WhenThreadSafeHostedServiceIsConstructed
{
    [Test]
    public async Task GivenALoggerAndServicesThenAnInstanceIsCreated()
    {
        // Arrange
        ILogger<ThreadSafeHostedService> logger = Substitute.For<ILogger<ThreadSafeHostedService>>();
        IHostedService service = Substitute.For<IHostedService>();

        // Act
        Func<IHostedService> act = () => new ThreadSafeHostedService(logger, [service]);

        // Assert
        _ = await Assert.That(act).ThrowsNothing();
    }

    [Test]
    public async Task GivenALoggerAndNoServicesThenAnInstanceIsCreated()
    {
        // Arrange
        ILogger<ThreadSafeHostedService> logger = Substitute.For<ILogger<ThreadSafeHostedService>>();
        IHostedService[] services = [];

        // Act
        Func<IHostedService> act = () => new ThreadSafeHostedService(logger, services);

        // Assert
        _ = await Assert.That(act).ThrowsNothing();
    }

    [Test]
    public async Task GivenALoggerAndNullServicesThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        ILogger<ThreadSafeHostedService> logger = Substitute.For<ILogger<ThreadSafeHostedService>>();
        IHostedService[]? services = default;

        // Act
        Func<IHostedService> act = () => new ThreadSafeHostedService(logger, services!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(services));
    }

    [Test]
    public async Task GivenANullLoggerAndServicesThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        ILogger<ThreadSafeHostedService>? logger = default;
        IHostedService service = Substitute.For<IHostedService>();

        // Act
        Func<IHostedService> act = () => new ThreadSafeHostedService(logger!, [service]);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(logger));
    }
}