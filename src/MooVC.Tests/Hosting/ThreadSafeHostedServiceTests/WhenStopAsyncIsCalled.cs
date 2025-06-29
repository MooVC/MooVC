namespace MooVC.Hosting.ThreadSafeHostedServiceTests;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public sealed class WhenStopAsyncIsCalled
{
    private readonly ThreadSafeHostedService _host;
    private readonly IHostedService _service;

    public WhenStopAsyncIsCalled()
    {
        _service = Substitute.For<IHostedService>();
        _host = new ThreadSafeHostedService(Substitute.For<ILogger<ThreadSafeHostedService>>(), [_service]);
    }

    [Fact]
    public async Task GivenAStartedHostThenTheServiceStops()
    {
        // Arrange
        await _host.StartAsync(CancellationToken.None);

        // Act
        await _host.StopAsync(CancellationToken.None);

        // Assert
        await _service.Received(1).StartAsync(Arg.Any<CancellationToken>());
        await _service.Received(1).StopAsync(Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task GivenAStoppedHostThenTheServiceIsNotStopped()
    {
        // Act
        await _host.StopAsync(CancellationToken.None);

        // Assert
        await _service.DidNotReceive().StopAsync(Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task GivenARestartThenTheServiceIsStoppedTheSecondTime()
    {
        // Arrange
        await _host.StartAsync(CancellationToken.None);
        await _host.StopAsync(CancellationToken.None);
        await _host.StartAsync(CancellationToken.None);

        // Act
        await _host.StopAsync(CancellationToken.None);

        // Assert
        await _service.Received(2).StartAsync(Arg.Any<CancellationToken>());
        await _service.Received(2).StopAsync(Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task GivenMultipleStartsAndStopsThenServiceIsStartedAndStoppedCorrectNumberOfTimes()
    {
        // Arrange
        await _host.StartAsync(CancellationToken.None);

        // Act
        await _host.StartAsync(CancellationToken.None);
        await _host.StopAsync(CancellationToken.None);
        await _host.StopAsync(CancellationToken.None);

        // Assert
        await _service.Received(1).StartAsync(Arg.Any<CancellationToken>());
        await _service.Received(1).StopAsync(Arg.Any<CancellationToken>());
    }
}