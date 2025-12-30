namespace MooVC.Syntax
{
    using System;
    using System.Text;

    public static partial class StringExtensions
    {
        private const char Hyphen = '-';
        private const char NullCharacter = '\0';
        private const char Underscore = '_';
        private const int CharacterOffset = 1;
        private const int FirstCharacterIndex = 0;
        private const int MinimumCapacityPadding = 16;

        private static string ToSeparatedCase(this string value, char separator)
        {
            int valueLength = value.Length;
            var builder = new StringBuilder(valueLength + Math.Min(MinimumCapacityPadding, valueLength));

            for (int index = FirstCharacterIndex; index < valueLength; index++)
            {
                char currentCharacter = value[index];

                if (IsWordBoundaryCharacter(currentCharacter))
                {
                    builder = AppendCollapsedSeparator(builder, separator);
                    continue;
                }

                if (char.IsUpper(currentCharacter))
                {
                    builder = AppendSeparatorBeforeUpperIfNeeded(value, builder, index, valueLength, separator);
                    builder = builder.Append(char.ToLowerInvariant(currentCharacter));
                    continue;
                }

                builder = builder.Append(currentCharacter);
            }

            TrimTrailingSeparator(builder, separator);

            return builder.ToString();
        }

        private static bool IsWordBoundaryCharacter(char character)
        {
            return character == Underscore || character == Hyphen || char.IsWhiteSpace(character);
        }

        private static StringBuilder AppendCollapsedSeparator(StringBuilder builder, char separator)
        {
            if (builder.Length > FirstCharacterIndex && builder[builder.Length - CharacterOffset] != separator)
            {
                builder = builder.Append(separator);
            }

            return builder;
        }

        private static StringBuilder AppendSeparatorBeforeUpperIfNeeded(string value, StringBuilder builder, int index, int valueLength, char separator)
        {
            bool hasPrevious = index > FirstCharacterIndex;
            bool hasNext = index + CharacterOffset < valueLength;

            if (!hasPrevious || builder.Length == FirstCharacterIndex || builder[builder.Length - CharacterOffset] == separator)
            {
                return builder;
            }

            char previousCharacter = value[index - CharacterOffset];
            char nextCharacter = hasNext ? value[index + CharacterOffset] : NullCharacter;

            bool isBoundaryWithPrevious = char.IsLower(previousCharacter) || char.IsDigit(previousCharacter);
            bool isBoundaryWithNext = hasNext && char.IsLower(nextCharacter);

            if (isBoundaryWithPrevious || isBoundaryWithNext)
            {
                builder = builder.Append(separator);
            }

            return builder;
        }

        private static void TrimTrailingSeparator(StringBuilder builder, char separator)
        {
            if (builder.Length > FirstCharacterIndex && builder[builder.Length - CharacterOffset] == separator)
            {
                builder.Length -= CharacterOffset;
            }
        }
    }
}