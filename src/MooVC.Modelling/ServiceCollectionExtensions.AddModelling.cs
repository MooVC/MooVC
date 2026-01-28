namespace MooVC.Modelling;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static MooVC.Modelling.ServiceCollectionExtensions_Resources;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddModelling(this IServiceCollection services)
    {
        return services
            .AddGenerator()
            .AddFileSystemWriter()
            .AddZipWriter();
    }

    public static IServiceCollection AddModelling(this IServiceCollection services, IConfiguration configuration)
    {
        _ = Guard.Against.Null(services, message: ServiceCollectionRequired);
        _ = Guard.Against.Null(configuration, message: ConfigurationRequired);

        return services
            .AddGenerator()
            .AddFileSystemWriter(configuration)
            .AddZipWriter(configuration);
    }
}