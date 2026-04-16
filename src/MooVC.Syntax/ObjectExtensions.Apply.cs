namespace MooVC.Syntax
{
    using System;

    /// <summary>
    /// Provides helpers for object transformations in syntax pipelines.
    /// </summary>
    internal static partial class ObjectExtensions
    {
        /// <summary>
        /// Applies a transformation function to an instance when a function is provided.
        /// </summary>
        /// <typeparam name="T">The instance type.</typeparam>
        /// <param name="source">The source instance.</param>
        /// <param name="action">The transformation to apply.</param>
        /// <returns>The transformed instance, or the original instance when <paramref name="action"/> is <see langword="null"/>.</returns>
        public static T Apply<T>(this T source, Func<T, T> action)
        {
            if (action is null)
            {
                return source;
            }

            return action(source);
        }
    }
}