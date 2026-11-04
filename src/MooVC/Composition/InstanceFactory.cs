namespace MooVC.Composition
{
    using System;
    using System.Collections.Generic;
    using Ardalis.GuardClauses;
    using Microsoft.Extensions.Configuration;
    using MooVC.Configuration;
    using static MooVC.Composition.InstanceFactory_Resources;

    /// <summary>
    /// Provides a factory for creating instances of a given type based on configuration and available strategies.
    /// </summary>
    /// <typeparam name="T">The type of the instance to create.</typeparam>
    /// <typeparam name="TType">The type of the enumeration used to select the strategy.</typeparam>
    public sealed class InstanceFactory<T, TType>
        : IInstanceFactory<T>
        where T : class
        where TType : struct
    {
        private readonly IEnumerable<IInstanceStrategy<T, TType>> _strategies;

        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceFactory{T, TType}"/> class.
        /// </summary>
        /// <param name="strategies">The strategies to use for creating the instance.</param>
        public InstanceFactory(IEnumerable<IInstanceStrategy<T, TType>> strategies)
        {
            _strategies = Guard.Against.Null(strategies, message: StrategiesRequired);
        }

        /// <summary>
        /// Creates an instance of the specified type based on the provided configuration.
        /// </summary>
        /// <param name="configuration">The configuration used to create the instance.</param>
        /// <returns>The created instance.</returns>
        /// <exception cref="InvalidOperationException">Thrown when no suitable instance can be created.</exception>
        public T Create(IConfiguration configuration)
        {
            TType type = configuration.GetValue<TType>(nameof(Options<TType>.Type));
            IConfigurationSection inner = configuration.GetSection(type.ToString());

            if (_strategies.TryCreate(inner, type, out T instance))
            {
                return instance;
            }

            throw new InvalidOperationException(CreateNoSuitableInstanceFound.Format(typeof(T)));
        }
    }
}