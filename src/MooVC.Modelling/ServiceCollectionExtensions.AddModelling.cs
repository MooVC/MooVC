namespace MooVC.Modelling;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Provides service collection extensions for modelling services.
/// </summary>
public static partial class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds modelling services with default configuration sources.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddModelling(this IServiceCollection services)
    {
        return services
            .AddGenerator()
            .AddFileSystemWriter()
            .AddZipWriter();
    }

    /// <summary>
    /// Adds modelling services using the provided configuration.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="configuration">The configuration to bind options from.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddModelling(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddGenerator()
            .AddFileSystemWriter(configuration)
            .AddZipWriter(configuration);
    }
}