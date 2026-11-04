namespace MooVC.Composition
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Ardalis.GuardClauses;
    using static MooVC.Composition.ICollectionStrategyExtensions_Resources;

    /// <summary>
    /// Provides extension methods for the <see cref="ICollectionStrategy{T, TOptions, TType}"/> interface.
    /// </summary>
    public static partial class ICollectionStrategyExtensions
    {
        /// <summary>
        /// Attempts to create a collection of instances of type <typeparamref name="T"/> using the provided strategies, options, and type.
        /// </summary>
        /// <typeparam name="T">The type of the instances to create.</typeparam>
        /// <typeparam name="TOptions">The type of the options used to configure the instances.</typeparam>
        /// <typeparam name="TType">The type of the enumeration used to select the strategy.</typeparam>
        /// <param name="strategies">The strategies to use.</param>
        /// <param name="options">The options used to configure the instances.</param>
        /// <param name="type">The type of the strategy to use.</param>
        /// <param name="instances">When this method returns, contains the collection of created instances.</param>
        /// <returns><c>true</c> if the instances were created successfully; otherwise, <c>false</c>.</returns>
        public static bool TryCreate<T, TOptions, TType>(
            this IEnumerable<ICollectionStrategy<T, TOptions, TType>> strategies,
            TOptions options,
            TType type,
            #if NET6_0_OR_GREATER
            [MaybeNullWhen(false)]
            #endif
            out IEnumerable<T> instances)
            where T : class
            where TOptions : class
            where TType : struct
        {
            _ = Guard.Against.Null(strategies, message: GetStrategiesRequired);
            _ = Guard.Against.Null(options, message: GetOptionsRequired);
            _ = Guard.Against.Null(type, message: GetTypeRequired);

            foreach (ICollectionStrategy<T, TOptions, TType> strategy in strategies)
            {
                if (strategy.TryCreate(options, type, out instances))
                {
                    return true;
                }
            }

            instances = default;

            return false;
        }
    }
}