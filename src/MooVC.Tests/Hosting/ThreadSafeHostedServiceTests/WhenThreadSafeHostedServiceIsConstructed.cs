namespace MooVC.Hosting.ThreadSafeHostedServiceTests;

using System;
using FluentAssertions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public sealed class WhenThreadSafeHostedServiceIsConstructed
{
    [Fact]
    public void GivenALoggerAndServicesThenAnInstanceIsCreated()
    {
        // Arrange
        var logger = new Mock<ILogger<ThreadSafeHostedService>>();
        var service = new Mock<IHostedService>();

        // Act
        Func<IHostedService> act = () => new ThreadSafeHostedService(logger.Object, new[] { service.Object });

        // Assert
        _ = act.Should().NotThrow();
    }

    [Fact]
    public void GivenALoggerAndNoServicesThenAnInstanceIsCreated()
    {
        // Arrange
        var logger = new Mock<ILogger<ThreadSafeHostedService>>();
        IHostedService[] services = Array.Empty<IHostedService>();

        // Act
        Func<IHostedService> act = () => new ThreadSafeHostedService(logger.Object, services);

        // Assert
        _ = act.Should().NotThrow();
    }

    [Fact]
    public void GivenALoggerAndNullServicesThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        var logger = new Mock<ILogger<ThreadSafeHostedService>>();
        IHostedService[]? services = default;

        // Act
        Func<IHostedService> act = () => _ = new ThreadSafeHostedService(logger.Object, services!);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(services));
    }

    [Fact]
    public void GivenANullLoggerAndServicesThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        ILogger<ThreadSafeHostedService>? logger = default;
        var service = new Mock<IHostedService>();

        // Act
        Func<IHostedService> act = () => _ = new ThreadSafeHostedService(logger!, new[] { service.Object });

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(logger));
    }
}