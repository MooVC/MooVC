namespace MooVC.Processing.ThreadSafeHostedServiceTests;

using System;
using System.Linq;
using Microsoft.Extensions.Hosting;
using Moq;
using Xunit;

public sealed class WhenThreadSafeHostedServiceIsConstructed
{
    [Fact]
    public void GivenAHostThenAnInstanceIsCreated()
    {
        var service = new Mock<IHostedService>();

        _ = new ThreadSafeHostedService(new[] { service.Object });
    }

    [Fact]
    public void GivenANullHostedServicesThenAnArgumentNullExceptionIsThrown()
    {
        _ = Assert.Throws<ArgumentNullException>(
            () => _ = new ThreadSafeHostedService(default!));
    }

    [Fact]
    public void GivenNoHostedServicesThenAnArgumentExceptionIsThrown()
    {
        _ = Assert.Throws<ArgumentException>(
            () => _ = new ThreadSafeHostedService(Enumerable.Empty<IHostedService>()));
    }
}