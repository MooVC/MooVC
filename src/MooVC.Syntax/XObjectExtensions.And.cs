namespace MooVC.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Provides helpers for composing XML object sequences.
    /// </summary>
    internal static partial class XObjectExtensions
    {
        /// <summary>
        /// Concatenates two sequences of <see cref="XObject"/> values.
        /// </summary>
        /// <typeparam name="T1">The type of elements in the first sequence.</typeparam>
        /// <typeparam name="T2">The type of elements in the second sequence.</typeparam>
        /// <param name="first">The first sequence.</param>
        /// <param name="second">The second sequence.</param>
        /// <returns>A combined sequence containing elements from <paramref name="first"/> and <paramref name="second"/>.</returns>
        public static IEnumerable<XObject> And<T1, T2>(this IEnumerable<T1> first, IEnumerable<T2> second)
            where T1 : XObject
            where T2 : XObject
        {
            return first.Cast<XObject>().And(second);
        }

        /// <summary>
        /// Concatenates an <see cref="IEnumerable{T}"/> of <see cref="XObject"/> with another compatible sequence.
        /// </summary>
        /// <typeparam name="T">The type of elements in the second sequence.</typeparam>
        /// <param name="first">The first sequence.</param>
        /// <param name="second">The second sequence.</param>
        /// <returns>A combined sequence containing both input sequences.</returns>
        public static IEnumerable<XObject> And<T>(this IEnumerable<XObject> first, IEnumerable<T> second)
            where T : XObject
        {
            return first.Concat(second);
        }

        /// <summary>
        /// Appends a single <see cref="XObject"/> item to a sequence.
        /// </summary>
        /// <typeparam name="T">The type of the appended element.</typeparam>
        /// <param name="first">The first sequence.</param>
        /// <param name="second">The element to append.</param>
        /// <returns>A combined sequence containing <paramref name="first"/> followed by <paramref name="second"/>.</returns>
        public static IEnumerable<XObject> And<T>(this IEnumerable<XObject> first, T second)
            where T : XObject
        {
            return first.Concat(new XObject[] { second });
        }
    }
}