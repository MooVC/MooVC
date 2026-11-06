namespace MooVC.Composition
{
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Defines a factory for creating instances of a given type based on configuration.
    /// </summary>
    /// <typeparam name="T">The type of the instance to create.</typeparam>
    public interface IInstanceFactory<out T>
        where T : class
    {
        /// <summary>
        /// Creates an instance of the specified type based on the provided configuration.
        /// </summary>
        /// <param name="configuration">The configuration used to create the instance.</param>
        /// <returns>The created instance.</returns>
        T Create(IConfiguration configuration);
    }
}