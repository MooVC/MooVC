namespace MooVC.Composition;

using Microsoft.Extensions.Configuration;

/// <summary>
/// Defines an interface for an extension that allows a dynamic link library (DLL) to expose an entry point for IoC containers to register
/// the required services for the extension.
/// </summary>
/// <remarks>
/// Implementations of this interface should provide the necessary logic to integrate the extension's services into the application's
/// dependency injection container, enhancing modularity and facilitating loose coupling between components.
/// </remarks>
/// <typeparam name="TContainer">
/// The type of the dependency injection container or service collection where the services
/// will be registered.
/// </typeparam>
public interface IExtension<in TContainer>
    where TContainer : class
{
    /// <summary>
    /// Registers the extension's services into the provided IoC container using the specified configuration.
    /// </summary>
    /// <param name="configuration">
    /// The application's configuration, which may contain specific settings for the extension's services.
    /// </param>
    /// <param name="container">
    /// The IoC container or service collection where the extension's services will be registered. This allows the extension to configure
    /// services, register implementations, and potentially resolve other required services for setup.
    /// </param>
    void Register(IConfiguration configuration, TContainer container);
}