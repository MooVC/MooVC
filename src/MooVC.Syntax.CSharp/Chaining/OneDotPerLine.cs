namespace MooVC.Syntax.CSharp.Chaining
{
    using System.Collections.Generic;
    using System.Collections.Immutable;

    public sealed class OneDotPerLine
        : Snippet.IChain
    {
        public static readonly Snippet.IChain Instance = new OneDotPerLine();

        private OneDotPerLine()
        {
        }

        public ImmutableArray<string> Chain(string line, Snippet.Options options)
        {
            if (IsUnchainable(line, options))
            {
                return ImmutableArray.Create(line);
            }

            List<string> chainPoints = IdentifyChainPoints(line);

            if (chainPoints.Count < 2)
            {
                return ImmutableArray.Create(line);
            }

            return IndentChainedSegments(line, options, chainPoints);
        }

        private static ImmutableArray<string> IndentChainedSegments(string line, Snippet.Options options, List<string> chainPoints)
        {
            string leading = line.GetLeadingWhitespace();
            string indentation = string.Concat(leading, options.Whitespace);
            ImmutableArray<string>.Builder chained = ImmutableArray.CreateBuilder<string>(chainPoints.Count);

            chained.Add(chainPoints[0]);

            for (int index = 1; index < chainPoints.Count; index++)
            {
                string current = chainPoints[index].TrimStart();

                chained.Add(string.Concat(indentation, current));
            }

            return chained.ToImmutable();
        }

        private static List<string> IdentifyChainPoints(string line)
        {
            List<string> outerChainPoints = IdentifyOuterChainPoints(line);

            if (outerChainPoints.Count > 1)
            {
                return outerChainPoints;
            }

            return IdentifyInnerChainPoints(line);
        }

        private static List<string> IdentifyOuterChainPoints(string line)
        {
            var segments = new List<string>();
            int start = 0;
            int parenthesisDepth = 0;
            int bracketDepth = 0;
            int braceDepth = 0;

            for (int index = 0; index < line.Length; index++)
            {
                char character = line[index];

                UpdateDepthCounters(character, ref parenthesisDepth, ref bracketDepth, ref braceDepth);

                if (!ShouldSplitOuterDot(line, character, index, parenthesisDepth, bracketDepth, braceDepth))
                {
                    continue;
                }

                AddCurrentSegment(line, start, index, segments);
                start = index;
            }

            AddFinalSegment(line, start, segments);

            return segments;
        }

        private static List<string> IdentifyInnerChainPoints(string line)
        {
            int opening = line.IndexOf('(');

            if (opening < 0)
            {
                return new List<string> { line };
            }

            var segments = new List<string>();
            int start = 0;
            int parenthesisDepth = 1;
            int bracketDepth = 0;
            int braceDepth = 0;

            for (int index = opening + 1; index < line.Length; index++)
            {
                char character = line[index];

                UpdateDepthCounters(character, ref parenthesisDepth, ref bracketDepth, ref braceDepth);

                if (!ShouldSplitInnerDot(line, index, character, parenthesisDepth, bracketDepth, braceDepth))
                {
                    continue;
                }

                AddCurrentSegment(line, start, index, segments);
                start = index;
            }

            if (segments.Count == 0)
            {
                return new List<string> { line };
            }

            AddFinalSegment(line, start, segments);

            return segments;
        }

        private static void AddCurrentSegment(string line, int start, int index, List<string> segments)
        {
            string current = line.Substring(start, index - start).TrimEnd();

            if (!string.IsNullOrEmpty(current))
            {
                segments.Add(current);
            }
        }

        private static void AddFinalSegment(string line, int start, List<string> segments)
        {
            string final = line.Substring(start).TrimEnd();

            segments.Add(final);
        }

        private static bool IsMethodCall(string line, int dotIndex)
        {
            int methodNameStart = dotIndex + 1;

            if (!StartsWithIdentifier(line, methodNameStart))
            {
                return false;
            }

            int methodNameEnd = SkipIdentifier(line, methodNameStart);
            int afterGenerics = SkipGenericArguments(line, methodNameEnd);
            int afterWhitespace = SkipWhitespace(line, afterGenerics);

            return afterWhitespace < line.Length && line[afterWhitespace] == '(';
        }

        private static bool IsUnchainable(string line, Snippet.Options options)
        {
            return string.IsNullOrWhiteSpace(line) || line.Length < options.MaxLength;
        }

        private static bool ShouldSplitInnerDot(string line, int index, char character, int parenthesisDepth, int bracketDepth, int braceDepth)
        {
            return character == '.'
                && parenthesisDepth == 1
                && bracketDepth == 0
                && braceDepth == 0
                && IsMethodCall(line, index);
        }

        private static bool ShouldSplitOuterDot(string line, char character, int index, int parenthesisDepth, int bracketDepth, int braceDepth)
        {
            return character == '.'
                && index > 0
                && parenthesisDepth == 0
                && bracketDepth == 0
                && braceDepth == 0
                && IsMethodCall(line, index);
        }

        private static int SkipGenericArguments(string line, int start)
        {
            if (start >= line.Length || line[start] != '<')
            {
                return start;
            }

            int genericDepth = 0;
            int index = start;

            while (index < line.Length)
            {
                if (line[index] == '<')
                {
                    genericDepth++;
                }
                else if (line[index] == '>')
                {
                    genericDepth--;

                    if (genericDepth == 0)
                    {
                        return index + 1;
                    }
                }

                index++;
            }

            return index;
        }

        private static int SkipIdentifier(string line, int start)
        {
            int index = start;

            while (index < line.Length && (char.IsLetterOrDigit(line[index]) || line[index] == '_'))
            {
                index++;
            }

            return index;
        }

        private static int SkipWhitespace(string line, int start)
        {
            int index = start;

            while (index < line.Length && char.IsWhiteSpace(line[index]))
            {
                index++;
            }

            return index;
        }

        private static bool StartsWithIdentifier(string line, int index)
        {
            return index < line.Length && (char.IsLetter(line[index]) || line[index] == '_');
        }

        private static void UpdateDepthCounters(char character, ref int parenthesisDepth, ref int bracketDepth, ref int braceDepth)
        {
            if (character == '(')
            {
                parenthesisDepth++;

                return;
            }

            if (character == ')' && parenthesisDepth > 0)
            {
                parenthesisDepth--;

                return;
            }

            if (character == '[')
            {
                bracketDepth++;

                return;
            }

            if (character == ']' && bracketDepth > 0)
            {
                bracketDepth--;

                return;
            }

            if (character == '{')
            {
                braceDepth++;

                return;
            }

            if (character == '}' && braceDepth > 0)
            {
                braceDepth--;
            }
        }
    }
}