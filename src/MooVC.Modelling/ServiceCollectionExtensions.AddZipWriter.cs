namespace MooVC.Modelling;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using static MooVC.Modelling.ServiceCollectionExtensions_Resources;

public static partial class ServiceCollectionExtensions
{
    private const string ZipServiceKey = "Zip";

    /// <summary>
    /// Adds the zip writer services with default options.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddZipWriter(this IServiceCollection services)
    {
        _ = Guard.Against.Null(services, message: ServiceCollectionRequired);

        return services.PerformAddZipWriter(default);
    }

    /// <summary>
    /// Adds the zip writer services using the provided configuration.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="configuration">The configuration to bind options from.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddZipWriter(this IServiceCollection services, IConfiguration configuration)
    {
        _ = Guard.Against.Null(services, message: ServiceCollectionRequired);
        _ = Guard.Against.Null(configuration, message: ConfigurationRequired);

        return services.PerformAddZipWriter(configuration);
    }

    private static IServiceCollection PerformAddZipWriter(this IServiceCollection services, IConfiguration? configuration)
    {
        return services
            .AddOptions<ZipWriter.Options>()
            .ForkOn(
                _ => configuration is null,
                builder => builder,
                builder => builder.Bind(configuration!.GetSection(ZipWriter.Options.SectionName)))
             .Services
            .AddKeyedTransient<IWriter, ZipWriter>(ZipServiceKey);
    }
}