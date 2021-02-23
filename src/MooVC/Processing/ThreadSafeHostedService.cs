namespace MooVC.Processing
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Hosting;
    using MooVC.Collections.Generic;
    using static MooVC.Ensure;
    using static MooVC.Processing.Resources;

    public sealed class ThreadSafeHostedService
        : ThreadSafeProcessor
    {
        private readonly IEnumerable<IHostedService> services;

        public ThreadSafeHostedService(IEnumerable<IHostedService> services)
        {
            ArgumentIsAcceptable(
                services,
                nameof(services),
                _ => services.Any(),
                ThreadSafeHostedServiceServicesRequired);

            this.services = services.Snapshot();
        }

        protected override Task PerformStartAsync(CancellationToken cancellationToken)
        {
            return services.ForAllAsync(service => service.StartAsync(cancellationToken));
        }

        protected override Task PerformStopAsync(CancellationToken cancellationToken)
        {
            return services.ForAllAsync(service => service.StopAsync(cancellationToken));
        }
    }
}