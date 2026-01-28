namespace MooVC.Modelling;

using Microsoft.Extensions.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddModelling(this IServiceCollection services)
    {
        return services
            .AddGenerator()
            .AddZipWriter();
    }
}