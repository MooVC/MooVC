namespace MooVC.Modelling;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static MooVC.Modelling.ServiceCollectionExtensions_Resources;

public static partial class ServiceCollectionExtensions
{
    private const string FileSystemServiceKey = "FileSystem";

    public static IServiceCollection AddFileSystemWriter(this IServiceCollection services)
    {
        _ = Guard.Against.Null(services, message: ServiceCollectionRequired);

        return services
            .AddOptions<FileSystemWriter.Options>()
            .AddSingleton<IFileSystem, FileSystem>()
            .AddKeyedTransient<IWriter, FileSystemWriter>(FileSystemServiceKey);
    }

    public static IServiceCollection AddFileSystemWriter(this IServiceCollection services, IConfiguration configuration)
    {
        _ = Guard.Against.Null(services, message: ServiceCollectionRequired);
        _ = Guard.Against.Null(configuration, message: ConfigurationRequired);

        var optionsBuilder = services
            .AddOptions<FileSystemWriter.Options>()
            .Bind(configuration.GetSection(FileSystemWriter.Options.SectionName));

        return optionsBuilder.Services
            .AddSingleton<IFileSystem, FileSystem>()
            .AddKeyedTransient<IWriter, FileSystemWriter>(FileSystemServiceKey);
    }
}