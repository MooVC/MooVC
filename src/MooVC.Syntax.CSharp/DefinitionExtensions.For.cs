namespace MooVC.Syntax.CSharp
{
    using System;
    using Fluentify.Internal;

    /// <summary>
    /// Provides helpers for configuring <see cref="Definition"/> instances.
    /// </summary>
    public static partial class DefinitionExtensions
    {
        /// <summary>
        /// Configures and assigns the type definition for the provided <see cref="Definition"/>.
        /// </summary>
        /// <typeparam name="T">The type model to build.</typeparam>
        /// <param name="definition">The definition being configured.</param>
        /// <param name="builder">A builder function that customizes the type model.</param>
        /// <returns>The updated definition.</returns>
        public static Definition For<T>(this Definition definition, Func<T, T> builder)
            where T : Type, new()
        {
            builder.ThrowIfNull(nameof(builder));

            var type = new T();

            type = builder(type);

            return definition.WithType(type);
        }
    }
}