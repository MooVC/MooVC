namespace MooVC.Composition
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Defines a strategy for creating collections of instances of a given type based on configuration and available strategies.
    /// </summary>
    /// <typeparam name="T">The type of the instances to create.</typeparam>
    /// <typeparam name="TOptions">The type of the options used to configure the instances.</typeparam>
    /// <typeparam name="TType">The type of the enumeration used to select the strategy.</typeparam>
    public interface ICollectionStrategy<T, in TOptions, in TType>
        where TOptions : class
        where TType : struct
    {
        /// <summary>
        /// Attempts to create a collection of instances of the specified type based on the provided options and strategy type.
        /// </summary>
        /// <param name="options">The options used to configure the instances.</param>
        /// <param name="type">The type of the strategy to use.</param>
        /// <param name="instances">When this method returns, contains the collection of created instances.</param>
        /// <returns><c>true</c> if the instances were created successfully; otherwise, <c>false</c>.</returns>
        bool TryCreate(
            TOptions options,
            TType type,
            #if NET6_0_OR_GREATER
            [MaybeNullWhen(false)]
            #endif
            out IEnumerable<T> instances);
    }
}