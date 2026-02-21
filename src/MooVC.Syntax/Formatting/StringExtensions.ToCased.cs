namespace MooVC.Syntax.Formatting
{
    using System;

    /// <summary>
    /// Represents a formatting helper string extensions.
    /// </summary>
    public static partial class StringExtensions
    {
        private static string ToCased(this string value, Func<char, char> transformFirstCharacter)
        {
            int length = value.Length;

            if (length == 0)
            {
                return string.Empty;
            }

            char[] chars = value.ToCharArray();

            chars[0] = transformFirstCharacter(chars[0]);

            return new string(chars);
        }
    }
}