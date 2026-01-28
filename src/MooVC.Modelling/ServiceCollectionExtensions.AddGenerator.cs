namespace MooVC.Modelling;

using Ardalis.GuardClauses;
using Microsoft.Extensions.DependencyInjection;
using static MooVC.Modelling.ServiceCollectionExtensions_Resources;

public static partial class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds generator services for modelling.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddGenerator(this IServiceCollection services)
    {
        _ = Guard.Against.Null(services, message: ServiceCollectionRequired);

        return services.AddTransient(typeof(IGenerator<>), typeof(Generator<>));
    }
}