namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Immutable;
    using Ardalis.GuardClauses;

    public static partial class IndexerExtensions
    {
        /// <summary>
        /// Creates an indexer that accepts the specified parameter.
        /// </summary>
        /// <param name="subject">The indexer to update.</param>
        /// <param name="value">The indexer parameter.</param>
        /// <returns>The updated indexer.</returns>
        public static Indexer Accepts(this Indexer subject, Parameter value)
        {
            _ = Guard.Against.Null(subject);
            _ = Guard.Against.Null(value);

            ImmutableArray<Parameter> parameters = value.IsUndefined
                ? ImmutableArray<Parameter>.Empty
                : ImmutableArray.Create(value);

            return subject.With(parameters: () => parameters);
        }

        /// <summary>
        /// Creates an indexer using an updated copy of its first parameter.
        /// </summary>
        /// <param name="subject">The indexer to update.</param>
        /// <param name="builder">A function that updates the parameter.</param>
        /// <returns>The updated indexer.</returns>
        public static Indexer Accepts(this Indexer subject, Func<Parameter, Parameter> builder)
        {
            _ = Guard.Against.Null(subject);

            return subject.Accepts(subject.Parameter, builder);
        }

        /// <summary>
        /// Creates an indexer using an updated copy of the specified parameter.
        /// </summary>
        /// <param name="subject">The indexer to update.</param>
        /// <param name="instance">The parameter to pass to the builder.</param>
        /// <param name="builder">A function that updates the parameter.</param>
        /// <returns>The updated indexer.</returns>
        public static Indexer Accepts(this Indexer subject, Parameter instance, Func<Parameter, Parameter> builder)
        {
            _ = Guard.Against.Null(subject);
            _ = Guard.Against.Null(builder);

            return subject.Accepts(builder(instance));
        }

        /// <summary>
        /// Creates an indexer that accepts the specified parameters in order.
        /// </summary>
        /// <param name="subject">The indexer to update.</param>
        /// <param name="parameters">The indexer parameters.</param>
        /// <returns>The updated indexer.</returns>
        public static Indexer Accepts(this Indexer subject, params Parameter[] parameters)
        {
            _ = Guard.Against.Null(subject);
            _ = Guard.Against.Null(parameters);

            return subject.With(parameters: () => ImmutableArray.CreateRange(parameters));
        }
    }
}