namespace MooVC.Hosting.ThreadSafeHostedServiceTests;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public sealed class WhenStartAsyncIsCalled
{
    private readonly ThreadSafeHostedService _host;
    private readonly IHostedService _service;

    public WhenStartAsyncIsCalled()
    {
        _service = Substitute.For<IHostedService>();
        _host = new ThreadSafeHostedService(Substitute.For<ILogger<ThreadSafeHostedService>>(), [_service]);
    }

    [Fact]
    public async Task GivenAStoppedHostThenTheServiceStarts()
    {
        // Act
        await _host.StartAsync(CancellationToken.None);

        // Assert
        await _service.Received(1).StartAsync(Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task GivenAStartedHostThenTheServiceIsNotStartedASecondTime()
    {
        // Arrange
        await _host.StartAsync(CancellationToken.None);

        // Act
        await _host.StartAsync(CancellationToken.None);

        // Assert
        await _service.Received(1).StartAsync(Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task GivenARestartThenTheServiceIsStartedTheSecondTime()
    {
        // Arrange
        await _host.StartAsync(CancellationToken.None);
        await _host.StopAsync(CancellationToken.None);

        // Act
        await _host.StartAsync(CancellationToken.None);

        // Assert
        await _service.Received(2).StartAsync(Arg.Any<CancellationToken>());
        await _service.Received(1).StopAsync(Arg.Any<CancellationToken>());
    }

    [Fact]
    public void GivenAStoppedHostStartAsyncIsNotCalled()
    {
        // Assert
        _ = _service.DidNotReceive().StartAsync(Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task GivenServiceStartAsyncThrowsExceptionThenHostIsStopped()
    {
        // Arrange
        var expected = new InvalidOperationException("Service failed to start.");
        _service.When(service => service.StartAsync(Arg.Any<CancellationToken>())).Do(_ => throw expected);

        // Act & Assert
        AggregateException actual = await Should.ThrowAsync<AggregateException>(() => _host.StartAsync(CancellationToken.None));

        actual.InnerException.ShouldBe(expected);

        await _service.Received(1).StopAsync(Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task GivenServiceStartAsyncThrowsExceptionAndStopAsyncAlsoThrowsThenHostIsStillStopped()
    {
        // Arrange
        var start = new InvalidOperationException("Service failed to start.");
        var stop = new InvalidOperationException("Service failed to stop.");
        _service.When(service => service.StartAsync(Arg.Any<CancellationToken>())).Do(_ => throw start);
        _service.When(services => _service.StopAsync(Arg.Any<CancellationToken>())).Do(_ => throw stop);

        // Act & Assert
        AggregateException actual = await Should.ThrowAsync<AggregateException>(() => _host.StartAsync(CancellationToken.None));

        actual.InnerException.ShouldBe(start);
        actual.InnerExceptions.ShouldNotContain(stop);

        await _service.Received(1).StopAsync(Arg.Any<CancellationToken>());
    }
}