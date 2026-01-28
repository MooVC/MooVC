namespace MooVC.Modelling;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static MooVC.Modelling.ServiceCollectionExtensions_Resources;

public static partial class ServiceCollectionExtensions
{
    private const string ZipServiceKey = "Zip";

    public static IServiceCollection AddZipWriter(this IServiceCollection services)
    {
        _ = Guard.Against.Null(services, message: ServiceCollectionRequired);

        return services
            .AddOptions<ZipWriter.Options>()
            .AddKeyedTransient<IWriter, ZipWriter>(ZipServiceKey);
    }

    public static IServiceCollection AddZipWriter(this IServiceCollection services, IConfiguration configuration)
    {
        _ = Guard.Against.Null(services, message: ServiceCollectionRequired);
        _ = Guard.Against.Null(configuration, message: ConfigurationRequired);

        var optionsBuilder = services
            .AddOptions<ZipWriter.Options>()
            .Bind(configuration.GetSection(ZipWriter.Options.SectionName));

        return optionsBuilder.Services
            .AddKeyedTransient<IWriter, ZipWriter>(ZipServiceKey);
    }
}