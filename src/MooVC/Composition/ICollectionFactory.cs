namespace MooVC.Composition
{
    using System.Collections.Generic;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Defines a factory for creating collections of instances of a given type based on configuration and available strategies.
    /// </summary>
    /// <typeparam name="T">The type of the instances to create.</typeparam>
    public interface ICollectionFactory<out T>
    {
        /// <summary>
        /// Creates a collection of instances of the specified type based on the provided configuration.
        /// </summary>
        /// <param name="configuration">The configuration used to create the instances.</param>
        /// <returns>The collection of created instances.</returns>
        IEnumerable<T> Create(IConfiguration configuration);
    }
}