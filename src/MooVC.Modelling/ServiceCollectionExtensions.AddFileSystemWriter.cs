namespace MooVC.Modelling;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static MooVC.Modelling.ServiceCollectionExtensions_Resources;

/// <summary>
/// Registers dependency injection services required by modelling writers.
/// </summary>
public static partial class ServiceCollectionExtensions
{
    private const string FileSystemServiceKey = "FileSystem";

    /// <summary>
    /// Adds the file system writer services with default options.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddFileSystemWriter(this IServiceCollection services)
    {
        _ = Guard.Against.Null(services, message: ServiceCollectionRequired);

        return services.PerformAddFileSystemWriter(default);
    }

    /// <summary>
    /// Adds the file system writer services using the provided configuration.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="configuration">The configuration to bind options from.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddFileSystemWriter(this IServiceCollection services, IConfiguration configuration)
    {
        _ = Guard.Against.Null(services, message: ServiceCollectionRequired);
        _ = Guard.Against.Null(configuration, message: ConfigurationRequired);

        return services.PerformAddFileSystemWriter(configuration);
    }

    private static IServiceCollection PerformAddFileSystemWriter(this IServiceCollection services, IConfiguration? configuration)
    {
        return services
            .AddOptions<FileSystemWriter.Options>()
            .ForkOn(
                _ => configuration is null,
                @true: builder => builder,
                @false: builder => builder.Bind(configuration!.GetSection(FileSystemWriter.Options.SectionName)))
            .Services
            .AddSingleton<IFileSystem, FileSystem>()
            .AddKeyedTransient<IWriter, FileSystemWriter>(FileSystemServiceKey);
    }
}