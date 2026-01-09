namespace MooVC.Syntax
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Provides static helper methods for working with immutable arrays.
    /// </summary>
    internal static partial class ImmutableArrayExtensions
    {
        /// <summary>
        /// Returns a new immutable array containing all <see cref="XElement"/> fragments produced from elements in the
        /// source array that satisfy the specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of elements in the source array. Must be a reference type.</typeparam>
        /// <param name="subjects">The source immutable array of elements to process. Must not be the default value.</param>
        /// <param name="fragments">
        /// A function that, given an element of type <typeparamref name="T"/>, returns an immutable array of <see cref="XElement"/>
        /// fragments to include in the result.
        /// </param>
        /// <param name="isDefined">
        /// A predicate that determines whether a given element should be included. Only elements for which this returns
        /// <see langword="true"/> are processed.
        /// </param>
        /// <returns>
        /// An immutable array containing all <see cref="XElement"/> fragments from elements in <paramref name="subjects"/>
        /// that satisfy <paramref name="isDefined"/>. Returns an empty array if the source is default or empty, or if no elements match the predicate.
        /// </returns>
        /// <remarks>
        /// This method filters the source array using the provided predicate and projects each
        /// matching element to a collection of <see cref="XElement"/> fragments, which are then combined into a single
        /// immutable array. The order of fragments in the result matches the order of the source elements and their
        /// respective fragments.
        /// </remarks>
        public static ImmutableArray<XElement> Get<T>(
            this ImmutableArray<T> subjects,
            Func<T, ImmutableArray<XElement>> fragments,
            Predicate<T> isDefined)
            where T : class
        {
            if (subjects.IsDefaultOrEmpty)
            {
                return ImmutableArray<XElement>.Empty;
            }

            return subjects
                .Where(item => isDefined(item))
                .SelectMany(item => fragments(item))
                .ToImmutableArray();
        }
    }
}