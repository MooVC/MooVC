namespace MooVC.Hosting.ThreadSafeHostedServiceTests;

using System.Threading;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public sealed class WhenStartAsyncIsCalled
{
    private readonly ThreadSafeHostedService host;
    private readonly Mock<IHostedService> service;

    public WhenStartAsyncIsCalled()
    {
        service = new Mock<IHostedService>();
        host = new ThreadSafeHostedService(Mock.Of<ILogger<ThreadSafeHostedService>>(), new[] { service.Object });
    }

    [Fact]
    public async void GivenAStoppedHostThenTheServiceStartsAsync()
    {
        // Act
        await host.StartAsync(CancellationToken.None);

        // Assert
        service.Verify(host => host.StartAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async void GivenAStartedHostThenTheServiceIsNotStartedASecondTimeAsync()
    {
        // Arrange
        await host.StartAsync(CancellationToken.None);

        // Act
        await host.StartAsync(CancellationToken.None);

        // Assert
        service.Verify(host => host.StartAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async void GivenARestartThenTheServiceIsStartedTheSecondTimeAsync()
    {
        // Arrange
        await host.StartAsync(CancellationToken.None);
        await host.StopAsync(CancellationToken.None);

        // Act
        await host.StartAsync(CancellationToken.None);

        // Assert
        service.Verify(host => host.StartAsync(It.IsAny<CancellationToken>()), Times.Exactly(2));
        service.Verify(host => host.StopAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public void GivenAStoppedHostStartAsyncIsNotCalled()
    {
        // Assert
        service.Verify(host => host.StartAsync(It.IsAny<CancellationToken>()), Times.Never);
    }
}