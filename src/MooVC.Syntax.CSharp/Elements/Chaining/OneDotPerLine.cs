namespace MooVC.Syntax.CSharp.Elements.Chaining
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using MooVC.Syntax.Elements;

    public sealed class OneDotPerLine
        : Snippet.IChain
    {
        public static readonly Snippet.IChain Instance = new OneDotPerLine();

        private OneDotPerLine()
        {
        }

        public ImmutableArray<string> Chain(string line, Snippet.Options options)
        {
            if (string.IsNullOrWhiteSpace(line) || line.Length < options.MaxLength)
            {
                return ImmutableArray.Create(line);
            }

            List<string> lines = IdentifyChainPoints(line);
            bool unchained = lines.Count < 2;

            if (unchained)
            {
                return ImmutableArray.Create(line);
            }

            string leading = line.GetLeadingWhitespace();
            string indentation = string.Concat(leading, options.Whitespace);

            ImmutableArray<string>.Builder chained = ImmutableArray.CreateBuilder<string>(lines.Count);

            chained.Add(lines[0]);

            for (int index = 1; index < lines.Count; index++)
            {
                string current = lines[index].TrimStart();

                current = string.Concat(indentation, current);
                chained.Add(current);
            }

            return chained.ToImmutable();
        }

        private static List<string> IdentifyChainPoints(string line)
        {
            var lines = new List<string>();
            int start = 0;
            int parenthesisDepth = 0;
            int bracketDepth = 0;
            int braceDepth = 0;

            for (int index = 0; index < line.Length; index++)
            {
                char character = line[index];

                if (character == '(')
                {
                    parenthesisDepth++;
                    continue;
                }

                if (character == ')' && parenthesisDepth > 0)
                {
                    parenthesisDepth--;
                    continue;
                }

                if (character == '[')
                {
                    bracketDepth++;
                    continue;
                }

                if (character == ']' && bracketDepth > 0)
                {
                    bracketDepth--;
                    continue;
                }

                if (character == '{')
                {
                    braceDepth++;
                    continue;
                }

                if (character == '}' && braceDepth > 0)
                {
                    braceDepth--;
                    continue;
                }

                bool shouldSplit = character == '.'
                    && index > 0
                    && parenthesisDepth == 0
                    && bracketDepth == 0
                    && braceDepth == 0;

                if (!shouldSplit)
                {
                    continue;
                }

                string current = line.Substring(start, index - start).TrimEnd();

                lines.Add(current);
                start = index;
            }

            string final = line.Substring(start).TrimEnd();
            lines.Add(final);

            return lines;
        }
    }
}