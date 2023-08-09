namespace MooVC.Hosting.ThreadSafeHostedServiceTests;

using System.Threading;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

public sealed class WhenStartAsyncIsCalled
{
    private readonly ThreadSafeHostedService host;
    private readonly IHostedService service;

    public WhenStartAsyncIsCalled()
    {
        service = Substitute.For<IHostedService>();
        host = new ThreadSafeHostedService(Substitute.For<ILogger<ThreadSafeHostedService>>(), new[] { service });
    }

    [Fact]
    public async void GivenAStoppedHostThenTheServiceStartsAsync()
    {
        // Act
        await host.StartAsync(CancellationToken.None);

        // Assert
        await service.Received(1).StartAsync(Arg.Any<CancellationToken>());
    }

    [Fact]
    public async void GivenAStartedHostThenTheServiceIsNotStartedASecondTimeAsync()
    {
        // Arrange
        await host.StartAsync(CancellationToken.None);

        // Act
        await host.StartAsync(CancellationToken.None);

        // Assert
        await service.Received(1).StartAsync(Arg.Any<CancellationToken>());
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
        await service.Received(2).StartAsync(Arg.Any<CancellationToken>());
        await service.Received(1).StopAsync(Arg.Any<CancellationToken>());
    }

    [Fact]
    public void GivenAStoppedHostStartAsyncIsNotCalled()
    {
        // Assert
        _ = service.DidNotReceive().StartAsync(Arg.Any<CancellationToken>());
    }
}