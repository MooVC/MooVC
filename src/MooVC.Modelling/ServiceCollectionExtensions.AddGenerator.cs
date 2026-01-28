namespace MooVC.Modelling;

using Ardalis.GuardClauses;
using Microsoft.Extensions.DependencyInjection;
using static MooVC.Modelling.ServiceCollectionExtensions_Resources;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddGenerator(this IServiceCollection services)
    {
        _ = Guard.Against.Null(services, message: ServiceCollectionRequired);

        return services.AddSingleton(typeof(IGenerator<>), typeof(Generator<>));
    }
}