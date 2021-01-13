namespace MooVC.Processing.ThreadSafeHostedServiceTests
{
    using System;
    using Microsoft.Extensions.Hosting;
    using Moq;
    using Xunit;

    public sealed class WhenThreadSafeHostedServiceIsConstructed
    {
        [Fact]
        public void GivenAHostThenAnInstanceIsCreated()
        {
            var service = new Mock<IHostedService>();

            _ = new ThreadSafeHostedService(service.Object);
        }

        [Fact]
        public void GivenANullHostedServiceThenAnArgumentNullExceptionIsThrown()
        {
            IHostedService? service = default;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => _ = new ThreadSafeHostedService(service!));
        }
    }
}