namespace MooVC.Syntax.CSharp.Elements.Chaining
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using MooVC.Syntax.Elements;

    public sealed class OneDotPerLine
        : Snippet.IChain
    {
        public ImmutableArray<string> Chain(string line, Snippet.Options options)
        {
            if (string.IsNullOrWhiteSpace(line) || line.Length < options.MaxLength)
            {
                return ImmutableArray.Create(line);
            }

            int firstDot = line.IndexOf('.');

            if (firstDot <= 0)
            {
                return ImmutableArray.Create(line);
            }

            var parts = new List<string>();
            int start = 0;

            for (int index = firstDot + 1; index < line.Length; index++)
            {
                if (line[index] != '.')
                {
                    continue;
                }

                parts.Add(line.Substring(start, index - start).TrimEnd());
                start = index;
            }

            parts.Add(line.Substring(start).TrimEnd());

            if (parts.Count < 2)
            {
                return ImmutableArray.Create(line);
            }

            int leadingSpaces = CountLeadingSpaces(parts[0]);
            string indentation = new string(' ', leadingSpaces + 4);
            ImmutableArray<string>.Builder chained = ImmutableArray.CreateBuilder<string>(parts.Count);

            chained.Add(parts[0]);

            for (int index = 1; index < parts.Count; index++)
            {
                chained.Add(indentation + parts[index].TrimStart());
            }

            return chained.ToImmutable();
        }

        private static int CountLeadingSpaces(string value)
        {
            int count = 0;

            while (count < value.Length && value[count] == ' ')
            {
                count++;
            }

            return count;
        }
    }
}