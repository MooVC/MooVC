namespace MooVC.Syntax.CSharp
{
    using System;
    using Ardalis.GuardClauses;
    using MooVC.Syntax.CSharp.Elements;
    using static MooVC.Syntax.CSharp.TypeExtensions_Resources;

    internal static partial class TypeExtensions
    {
        private const char Separator = '`';

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