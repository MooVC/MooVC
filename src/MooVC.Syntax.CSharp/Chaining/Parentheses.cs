namespace MooVC.Syntax.CSharp.Chaining
{
    using System.Collections.Generic;
    using System.Collections.Immutable;

    /// <summary>
    /// Applies chaining by splitting multi-argument parenthesized calls across lines.
    /// </summary>
    public sealed class Parentheses
        : Snippet.Options.IChain
    {
        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        public static readonly Snippet.Options.IChain Instance = new Parentheses();

        private Parentheses()
        {
        }

        /// <summary>
        /// Chains a line by splitting argument lists when applicable.
        /// </summary>
        /// <param name="line">The source line.</param>
        /// <param name="options">The snippet options.</param>
        /// <returns>The chained line fragments.</returns>
        public ImmutableArray<string> Chain(string line, Snippet.Options options)
        {
            if (IsUnchainable(line, options))
            {
                return ImmutableArray.Create(line);
            }

            if (!TryGetParenthesisRange(line, out int opening, out int closing))
            {
                return ImmutableArray.Create(line);
            }

            List<string> arguments = SplitArguments(line, opening, closing);

            if (arguments.Count < 2)
            {
                return ImmutableArray.Create(line);
            }

            return BuildChainedResult(line, options, opening, closing, arguments);
        }

        private static ImmutableArray<string> BuildChainedResult(string line, Snippet.Options options, int opening, int closing, List<string> arguments)
        {
            string prefix = line.Substring(0, opening);
            string suffix = line.Substring(closing + 1);
            string indentation = GetArgumentIndentation(line, options);

            return FormatLines(arguments, prefix, suffix, indentation);
        }

        private static ImmutableArray<string> FormatLines(List<string> arguments, string prefix, string suffix, string indentation)
        {
            ImmutableArray<string>.Builder chained = ImmutableArray.CreateBuilder<string>(arguments.Count + 1);

            chained.Add(prefix + '(');

            for (int index = 0; index < arguments.Count; index++)
            {
                string argument = arguments[index];

                chained.Add(FormatArgument(argument, index, arguments.Count, indentation, suffix));
            }

            return chained.ToImmutable();
        }

        private static string FormatArgument(string argument, int index, int count, string indentation, string suffix)
        {
            bool isLast = index == count - 1;
            string closing = isLast ? ')' + suffix : ",";

            return string.Concat(indentation, argument, closing);
        }

        private static string GetArgumentIndentation(string line, Snippet.Options options)
        {
            string leading = line.GetLeadingWhitespace();

            return string.Concat(leading, options.Whitespace);
        }

        private static bool IsUnchainable(string line, Snippet.Options options)
        {
            return string.IsNullOrWhiteSpace(line) || line.Length < options.MaxLineLength;
        }

        private static List<string> Split(string content)
        {
            var lines = new List<string>();
            int depth = 0;
            int start = 0;

            for (int index = 0; index < content.Length; index++)
            {
                char character = content[index];

                UpdateDepthCounter(character, ref depth);

                if (!ShouldSplitArgument(character, depth))
                {
                    continue;
                }

                AddArgument(lines, content, start, index);
                start = index + 1;
            }

            AddLastArgument(lines, content, start);

            return lines;
        }

        private static List<string> SplitArguments(string line, int opening, int closing)
        {
            string content = line.Substring(opening + 1, closing - opening - 1);

            return Split(content);
        }

        private static bool ShouldSplitArgument(char character, int depth)
        {
            return character == ',' && depth == 0;
        }

        private static bool TryGetParenthesisRange(string line, out int opening, out int closing)
        {
            opening = -1;
            closing = -1;
            var stack = new Stack<int>();

            for (int index = 0; index < line.Length; index++)
            {
                char character = line[index];

                if (character == '(')
                {
                    stack.Push(index);

                    continue;
                }

                if (character != ')' || stack.Count == 0)
                {
                    continue;
                }

                int candidateOpening = stack.Pop();
                string content = line.Substring(candidateOpening + 1, index - candidateOpening - 1);
                List<string> arguments = Split(content);

                if (arguments.Count < 2)
                {
                    continue;
                }

                if (opening < 0 || candidateOpening < opening)
                {
                    opening = candidateOpening;
                    closing = index;
                }
            }

            return opening >= 0 && closing >= 0;
        }

        private static void UpdateDepthCounter(char character, ref int depth)
        {
            if (character == '(')
            {
                depth++;

                return;
            }

            if (character == ')')
            {
                depth--;
            }
        }

        private static void AddArgument(List<string> arguments, string content, int start, int end)
        {
            string current = content.Substring(start, end - start).Trim();

            arguments.Add(current);
        }

        private static void AddLastArgument(List<string> arguments, string content, int start)
        {
            string last = content.Substring(start).Trim();

            if (!string.IsNullOrEmpty(last))
            {
                arguments.Add(last);
            }
        }
    }
}