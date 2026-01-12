namespace MooVC.Syntax.Formatting
{
    using System;
    using System.Text;

    /// <summary>
    /// Represents a formatting helper string extensions.
    /// </summary>
    public static partial class StringExtensions
    {
        private static string ToCased(this string value, Func<char, char> transformFirstCharacter)
        {
            const int FirstCharacterIndex = 0;
            const int RemainingCharactersOffset = 1;

            int length = value.Length;
            var builder = new StringBuilder(length);

            char firstCharacter = transformFirstCharacter(value[FirstCharacterIndex]);

            builder = builder.Append(firstCharacter);

            if (length > RemainingCharactersOffset)
            {
                builder = builder.Append(value, RemainingCharactersOffset, length - RemainingCharactersOffset);
            }

            return builder.ToString();
        }
    }
}