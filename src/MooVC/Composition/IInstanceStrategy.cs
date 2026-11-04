namespace MooVC.Composition
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Defines a strategy for creating instances of a given type based on configuration and available strategies.
    /// </summary>
    /// <typeparam name="T">The type of the instance to create.</typeparam>
    /// <typeparam name="TType">The type of the enumeration used to select the strategy.</typeparam>
    public interface IInstanceStrategy<T, in TType>
        where TType : struct
    {
        /// <summary>
        /// Attempts to create an instance of the specified type based on the provided configuration and strategy type.
        /// </summary>
        /// <param name="configuration">The configuration used to create the instance.</param>
        /// <param name="type">The type of the strategy to use.</param>
        /// <param name="instance">When this method returns, contains the created instance.</param>
        /// <returns><c>true</c> if the instance was created successfully; otherwise, <c>false</c>.</returns>
        bool TryCreate(
            IConfigurationSection configuration,
            TType type,
            #if NET6_0_OR_GREATER
            [MaybeNullWhen(false)]
            #endif
            out T instance);
    }
}