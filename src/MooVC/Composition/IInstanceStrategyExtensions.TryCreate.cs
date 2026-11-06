namespace MooVC.Composition
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Ardalis.GuardClauses;
    using Microsoft.Extensions.Configuration;
    using static MooVC.Composition.IInstanceStrategyExtensions_Resources;

    /// <summary>
    /// Provides extension methods for the <see cref="IInstanceStrategy{T, TType}"/> interface.
    /// </summary>
    public static partial class IInstanceStrategyExtensions
    {
        /// <summary>
        /// Attempts to create an instance of type <typeparamref name="T"/> using the provided strategies, configuration, and type.
        /// </summary>
        /// <typeparam name="T">The type of the instance to create.</typeparam>
        /// <typeparam name="TType">The type of the enumeration used to select the strategy.</typeparam>
        /// <param name="strategies">The strategies to use for creating the instance.</param>
        /// <param name="configuration">The configuration used to create the instance.</param>
        /// <param name="type">The type of the strategy to use.</param>
        /// <param name="instance">When this method returns, contains the created instance.</param>
        /// <returns><c>true</c> if the instance was created successfully; otherwise, <c>false</c>.</returns>
        public static bool TryCreate<T, TType>(
            this IEnumerable<IInstanceStrategy<T, TType>> strategies,
            IConfigurationSection configuration,
            TType type,
            #if NET6_0_OR_GREATER
            [MaybeNullWhen(false)]
            #endif
            out T instance)
            where T : class
            where TType : struct
        {
            _ = Guard.Against.Null(strategies, message: GetStrategiesRequired);
            _ = Guard.Against.Null(configuration, message: GetConfigurationRequired);
            _ = Guard.Against.Null(type, message: GetTypeRequired);

            foreach (IInstanceStrategy<T, TType> strategy in strategies)
            {
                if (strategy.TryCreate(configuration, type, out instance))
                {
                    return true;
                }
            }

            instance = default;

            return false;
        }
    }
}