namespace MooVC.Syntax
{
    public static partial class StringExtensions
    {
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