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

        protected override async Task PerformStartAsync(CancellationToken cancellationToken)
        {
            await service
                .StartAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        protected override async Task PerformStopAsync(CancellationToken cancellationToken)
        {
            await service
                .StopAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}