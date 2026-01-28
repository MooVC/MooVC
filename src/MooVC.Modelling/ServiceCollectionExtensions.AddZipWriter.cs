namespace MooVC.Modelling;

using Ardalis.GuardClauses;
using Microsoft.Extensions.DependencyInjection;
using static MooVC.Modelling.ServiceCollectionExtensions_Resources;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddZipWriter(this IServiceCollection services)
    {
        _ = Guard.Against.Null(services, message: ServiceCollectionRequired);

        return services.AddSingleton<IWriter, ZipWriter>();
    }
}