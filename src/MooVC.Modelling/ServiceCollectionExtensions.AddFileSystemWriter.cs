namespace MooVC.Modelling;

using Ardalis.GuardClauses;
using Microsoft.Extensions.DependencyInjection;
using static MooVC.Modelling.ServiceCollectionExtensions_Resources;

public static partial class ServiceCollectionExtensions
{
    private const string FileSystemServiceKey = "FileSystem";

    public static IServiceCollection AddFileSystemWriter(this IServiceCollection services)
    {
        _ = Guard.Against.Null(services, message: ServiceCollectionRequired);

        return services
            .AddSingleton<IFileSystem, FileSystem>()
            .AddKeyedTransient<IWriter, FileSystemWriter>(FileSystemServiceKey);
    }
}