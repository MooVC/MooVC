namespace MooVC.Hosting.ThreadSafeHostedServiceTests;

using System.Threading;
using FluentAssertions;
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

    [Fact]
    public async void GivenServiceStartAsyncThrowsExceptionThenHostIsStoppedAsync()
    {
        // Arrange
        var expected = new InvalidOperationException("Service failed to start.");
        service.When(service => service.StartAsync(Arg.Any<CancellationToken>())).Do(_ => throw expected);

        // Act & Assert
        AggregateException actual = await Assert.ThrowsAsync<AggregateException>(() => host.StartAsync(CancellationToken.None));

        _ = actual.InnerException.Should().Be(expected);

        await service.Received(1).StopAsync(Arg.Any<CancellationToken>());
    }

    [Fact]
    public async void GivenServiceStartAsyncThrowsExceptionAndStopAsyncAlsoThrowsThenHostIsStillStoppedAsync()
    {
        // Arrange
        var start = new InvalidOperationException("Service failed to start.");
        var stop = new InvalidOperationException("Service failed to stop.");
        service.When(service => service.StartAsync(Arg.Any<CancellationToken>())).Do(_ => throw start);
        service.When(services => service.StopAsync(Arg.Any<CancellationToken>())).Do(_ => throw stop);

        // Act & Assert
        AggregateException actual = await Assert.ThrowsAsync<AggregateException>(() => host.StartAsync(CancellationToken.None));

        _ = actual.InnerException.Should().Be(start);
        _ = actual.InnerExceptions.Should().NotContain(stop);

        await service.Received(1).StopAsync(Arg.Any<CancellationToken>());
    }
}