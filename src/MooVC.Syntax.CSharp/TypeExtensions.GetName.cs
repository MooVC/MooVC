namespace MooVC.Syntax.CSharp
{
    using System;
    using Ardalis.GuardClauses;
    using MooVC.Syntax.CSharp.Elements;
    using static MooVC.Syntax.CSharp.TypeExtensions_Resources;

    /// <summary>
    /// Represents a C# syntax type extensions.
    /// </summary>
    internal static partial class TypeExtensions
    {
        private const char Separator = '`';

        /// <summary>
        /// Performs the get name operation for the C# syntax.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The variable.</returns>
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