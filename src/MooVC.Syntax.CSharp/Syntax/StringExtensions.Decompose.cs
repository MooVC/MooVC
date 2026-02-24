namespace MooVC.Syntax.CSharp.Syntax
{
    using System;
    using System.Collections.Generic;

    internal static partial class StringExtensions
    {
        public static FullyQualifiedName Decompose(this string fullyQualifiedName)
        {
            string value = RemoveGlobalQualifier(fullyQualifiedName);
            int genericListStartIndex = value.IndexOf('<');

            string head = genericListStartIndex < 0
                ? value
                : value.Substring(0, genericListStartIndex);

            int lastDotIndex = head.LastIndexOf('.');

            string @namespace = lastDotIndex < 0
                ? string.Empty
                : head.Substring(0, lastDotIndex);

            string name = lastDotIndex < 0
                ? head
                : head.Substring(lastDotIndex + 1);

            FullyQualifiedName[] arguments = genericListStartIndex < 0
                ? Array.Empty<FullyQualifiedName>()
                : ParseGenericArguments(value, genericListStartIndex);

            return new FullyQualifiedName(@namespace, name, arguments);
        }

        private static FullyQualifiedName[] ParseGenericArguments(string value, int genericListStartIndex)
        {
            string inner = value.Substring(genericListStartIndex + 1, value.Length - genericListStartIndex - 2);
            List<string> arguments = SplitTopLevelArguments(inner);
            var parsed = new List<FullyQualifiedName>(arguments.Count);

            for (int index = 0; index < arguments.Count; index++)
            {
                string argument = arguments[index];
                FullyQualifiedName name = argument.Decompose();

                parsed[index] = name;
            }

            return parsed.ToArray();
        }

        private static List<string> SplitTopLevelArguments(string inner)
        {
            var results = new List<string>();
            int genericDepth = 0;
            int argumentStartIndex = 0;

            for (int index = 0; index < inner.Length; index++)
            {
                char character = inner[index];

                if (character == '<')
                {
                    genericDepth++;
                    continue;
                }

                if (character == '>')
                {
                    genericDepth--;
                    continue;
                }

                if (character == ',' && genericDepth == 0)
                {
                    AddArgument(inner, argumentStartIndex, index, results);
                    argumentStartIndex = index + 1;
                }
            }

            AddArgument(inner, argumentStartIndex, inner.Length, results);

            return results;
        }

        private static void AddArgument(string inner, int startIndex, int endIndex, ICollection<string> results)
        {
            string argument = inner.Substring(startIndex, endIndex - startIndex);

            if (argument.Length == 0)
            {
                return;
            }

            results.Add(RemoveGlobalQualifier(argument));
        }

        private static string RemoveGlobalQualifier(string value)
        {
            const string globalQualifier = "global::";

            if (value.StartsWith(globalQualifier, StringComparison.Ordinal))
            {
                return value
                    .Substring(globalQualifier.Length)
                    .TrimStart();
            }

            return value;
        }
    }
}