namespace MooVC.Composition
{
    using System;
    using System.Collections.Generic;
    using Ardalis.GuardClauses;
    using Microsoft.Extensions.Configuration;
    using MooVC.Configuration;
    using static MooVC.Composition.CollectionFactory_Resources;

    /// <summary>
    /// Provides a factory for creating collections of instances of a given type based on configuration and available strategies.
    /// </summary>
    /// <typeparam name="T">The type of the instances to create.</typeparam>
    /// <typeparam name="TOptions">The type of the options used to configure the instances.</typeparam>
    /// <typeparam name="TType">The type of the enumeration used to select the strategy.</typeparam>
    public sealed class CollectionFactory<T, TOptions, TType>
        : ICollectionFactory<T>
        where T : class
        where TOptions : Options<TType>
        where TType : struct
    {
        private readonly IEnumerable<ICollectionStrategy<T, TOptions, TType>> _strategies;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionFactory{T, TOptions, TType}"/> class.
        /// </summary>
        /// <param name="strategies">The strategies available for creating instances.</param>
        public CollectionFactory(IEnumerable<ICollectionStrategy<T, TOptions, TType>> strategies)
        {
            _strategies = Guard.Against.Null(strategies, message: StrategiesRequired);
        }

        /// <summary>
        /// Creates a collection of instances based on the provided configuration.
        /// </summary>
        /// <param name="configuration">The configuration used to create the instances.</param>
        /// <returns>The collection of created instances.</returns>
        public IEnumerable<T> Create(IConfiguration configuration)
        {
            TType type = configuration.GetValue<TType>(nameof(Options<TType>.Type));

            TOptions inner = configuration
                .GetSection(type.ToString())
                .Get<TOptions>();

            if (_strategies.TryCreate(inner, type, out IEnumerable<T> instances))
            {
                return instances;
            }

            throw new InvalidOperationException(CreateNoSuitableInstanceFound.Format(typeof(T)));
        }
    }
}