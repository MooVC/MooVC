namespace MooVC.Modelling;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        return services
            .AddGenerator()
            .AddFileSystemWriter(configuration)
            .AddZipWriter(configuration);
    }
}