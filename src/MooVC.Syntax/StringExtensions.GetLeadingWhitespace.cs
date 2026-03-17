namespace MooVC.Syntax
{
    /// <summary>
    /// Provides helpers for string analysis used by syntax generation.
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        /// Gets the leading whitespace portion from a string.
        /// </summary>
        /// <param name="value">The string to inspect.</param>
        /// <returns>The leading whitespace characters, or <see cref="string.Empty"/> when none are present.</returns>
        public static string GetLeadingWhitespace(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            int index = 0;

            while (index < value.Length && char.IsWhiteSpace(value[index]))
            {
                index++;
            }

            return index == 0
                ? string.Empty
                : value.Substring(0, index);
        }
    }
}