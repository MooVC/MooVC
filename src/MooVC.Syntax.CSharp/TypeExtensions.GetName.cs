namespace MooVC.Syntax.CSharp
{
    using System;
    using Ardalis.GuardClauses;
    using MooVC.Syntax.CSharp.Elements;
    using static MooVC.Syntax.CSharp.TypeExtensions_Resources;

    /// <summary>
    /// Provides helpers for deriving C# type names for syntax generation.
    /// </summary>
    internal static partial class TypeExtensions
    {
        private const char Separator = '`';

        /// <summary>
        /// Gets the name of the <paramref name="type"/>, excluding generic arity suffixes.
        /// </summary>
        /// <param name="type">The type from which the name is derived.</param>
        /// <returns>
        /// A <see cref="Variable"/> representing the name of the <paramref name="type"/>.
        /// </returns>
        /// <remarks>
        /// If the <paramref name="type"/> is a known C# alias, the corresponding alias name is returned.
        /// Generic type arity markers are removed to yield the base type name.
        /// </remarks>
        public static Variable GetName(this Type type)
        {
            _ = Guard.Against.Null(type, message: GetNameTypeRequired.Format(typeof(Type), typeof(Variable)));

            if (Aliases.TryGet(type, out string alias))
            {
                return alias;
            }

            string name = type.Name;

            if (type.IsGenericType)
            {
                int index = name.IndexOf(Separator);

                return index > 0
                    ? name.Substring(0, index)
                    : name;
            }

            return name;
        }
    }
}
