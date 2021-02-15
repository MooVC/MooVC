namespace MooVC.Processing
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Hosting;
    using static MooVC.Ensure;
    using static MooVC.Processing.Resources;

    public sealed class ThreadSafeHostedService
        : ThreadSafeProcessor
    {
        private readonly IHostedService service;

        public ThreadSafeHostedService(IHostedService service)
        {
            ArgumentNotNull(service, nameof(service), ThreadSafeHostedServiceServiceRequired);

            this.service = service;
        }

        protected override Task PerformStartAsync(CancellationToken cancellationToken)
        {
            return service.StartAsync(cancellationToken);
        }

        protected override Task PerformStopAsync(CancellationToken cancellationToken)
        {
            return service.StopAsync(cancellationToken);
        }
    }
}