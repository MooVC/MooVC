namespace MooVC.Hosting.ThreadSafeHostedServiceTests;

using System.Threading;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public sealed class WhenStopAsyncIsCalled
{
    private readonly ThreadSafeHostedService host;
    private readonly Mock<IHostedService> service;

    public WhenStopAsyncIsCalled()
    {
        service = new Mock<IHostedService>();
        host = new ThreadSafeHostedService(Mock.Of<ILogger<ThreadSafeHostedService>>(), new[] { service.Object });
    }

    [Fact]
    public async void GivenAStartedHostThenTheServiceStopsAsync()
    {
        // Arrange
        await host.StartAsync(CancellationToken.None);

        // Act
        await host.StopAsync(CancellationToken.None);

        // Assert
        service.Verify(host => host.StartAsync(It.IsAny<CancellationToken>()), Times.Once);
        service.Verify(host => host.StopAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async void GivenAStoppedHostThenTheServiceIsNotStoppedAsync()
    {
        // Act
        await host.StopAsync(CancellationToken.None);

        // Assert
        service.Verify(host => host.StopAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async void GivenARestartThenTheServiceIsStopeedTheSecondTimeAsync()
    {
        // Arrange
        await host.StartAsync(CancellationToken.None);
        await host.StopAsync(CancellationToken.None);
        await host.StartAsync(CancellationToken.None);

        // Act
        await host.StopAsync(CancellationToken.None);

        // Assert
        service.Verify(host => host.StartAsync(It.IsAny<CancellationToken>()), Times.Exactly(2));
        service.Verify(host => host.StopAsync(It.IsAny<CancellationToken>()), Times.Exactly(2));
    }
}