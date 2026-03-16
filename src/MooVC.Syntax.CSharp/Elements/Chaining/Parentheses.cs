namespace MooVC.Syntax.CSharp.Elements.Chaining
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using MooVC.Syntax.Elements;

    public sealed class Parentheses
        : Snippet.IChain
    {
        public static readonly Snippet.IChain Instance = new Parentheses();

        private Parentheses()
        {
        }

        public ImmutableArray<string> Chain(string line, Snippet.Options options)
        {
            if (string.IsNullOrWhiteSpace(line) || line.Length < options.MaxLength)
            {
                return ImmutableArray.Create(line);
            }

            int opening = line.IndexOf('(');

            if (opening < 0)
            {
                return ImmutableArray.Create(line);
            }

            int closing = FindClosingParenthesis(line, opening);

            if (closing < 0)
            {
                return ImmutableArray.Create(line);
            }

            string content = line.Substring(opening + 1, closing - opening - 1);
            List<string> arguments = Split(content);
            bool unchained = arguments.Count < 2;

            if (unchained)
            {
                return ImmutableArray.Create(line);
            }

            string prefix = line.Substring(0, opening);
            string suffix = line.Substring(closing + 1);
            string leading = line.GetLeadingWhitespace();
            string indentation = string.Concat(leading, options.Whitespace);

            return FormatLines(arguments, prefix, suffix, indentation);
        }

        private static int FindClosingParenthesis(string line, int opening)
        {
            int depth = 0;

            for (int index = opening; index < line.Length; index++)
            {
                char character = line[index];

                if (character == '(')
                {
                    depth++;
                }
                else if (character == ')')
                {
                    depth--;

                    if (depth == 0)
                    {
                        return index;
                    }
                }
            }

            return -1;
        }

        private static ImmutableArray<string> FormatLines(List<string> arguments, string prefix, string suffix, string indentation)
        {
            ImmutableArray<string>.Builder chained = ImmutableArray.CreateBuilder<string>(arguments.Count + 1);

            chained.Add(prefix + '(');

            for (int index = 0; index < arguments.Count; index++)
            {
                string argument = arguments[index];
                bool isLast = index == arguments.Count - 1;
                string closing = isLast ? ')' + suffix : ",";
                string current = string.Concat(indentation, argument, closing);

                chained.Add(current);
            }

            return chained.ToImmutable();
        }

        private static List<string> Split(string content)
        {
            var lines = new List<string>();
            int depth = 0;
            int start = 0;

            for (int index = 0; index < content.Length; index++)
            {
                char character = content[index];

                if (character == '(')
                {
                    depth++;
                }
                else if (character == ')')
                {
                    depth--;
                }
                else if (character == ',' && depth == 0)
                {
                    string current = content.Substring(start, index - start).Trim();

                    lines.Add(current);
                    start = index + 1;
                }
            }

            string last = content.Substring(start).Trim();

            if (!string.IsNullOrEmpty(last))
            {
                lines.Add(last);
            }

            return lines;
        }
    }
}