namespace MooVC.Hosting.ThreadSafeHostedServiceTests;

using System.Threading;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

public sealed class WhenStopAsyncIsCalled
{
    private readonly ThreadSafeHostedService host;
    private readonly IHostedService service;

    public WhenStopAsyncIsCalled()
    {
        service = Substitute.For<IHostedService>();
        host = new ThreadSafeHostedService(Substitute.For<ILogger<ThreadSafeHostedService>>(), new[] { service });
    }

    [Fact]
    public async void GivenAStartedHostThenTheServiceStopsAsync()
    {
        // Arrange
        await host.StartAsync(CancellationToken.None);

        // Act
        await host.StopAsync(CancellationToken.None);

        // Assert
        await service.Received(1).StartAsync(Arg.Any<CancellationToken>());
        await service.Received(1).StopAsync(Arg.Any<CancellationToken>());
    }

    [Fact]
    public async void GivenAStoppedHostThenTheServiceIsNotStoppedAsync()
    {
        // Act
        await host.StopAsync(CancellationToken.None);

        // Assert
        await service.DidNotReceive().StopAsync(Arg.Any<CancellationToken>());
    }

    [Fact]
    public async void GivenARestartThenTheServiceIsStoppedTheSecondTimeAsync()
    {
        // Arrange
        await host.StartAsync(CancellationToken.None);
        await host.StopAsync(CancellationToken.None);
        await host.StartAsync(CancellationToken.None);

        // Act
        await host.StopAsync(CancellationToken.None);

        // Assert
        await service.Received(2).StartAsync(Arg.Any<CancellationToken>());
        await service.Received(2).StopAsync(Arg.Any<CancellationToken>());
    }

    [Fact]
    public async void GivenMultipleStartsAndStopsThenServiceIsStartedAndStoppedCorrectNumberOfTimes()
    {
        // Arrange
        await host.StartAsync(CancellationToken.None);

        // Act
        await host.StartAsync(CancellationToken.None);
        await host.StopAsync(CancellationToken.None);
        await host.StopAsync(CancellationToken.None);

        // Assert
        await service.Received(1).StartAsync(Arg.Any<CancellationToken>());
        await service.Received(1).StopAsync(Arg.Any<CancellationToken>());
    }
}