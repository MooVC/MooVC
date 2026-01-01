namespace MooVC.Syntax
{
    using System.Collections.Immutable;
    using System.Text;
    using System.Xml.Linq;

    /// <summary>
    /// Represents a syntax helper x element extensions.
    /// </summary>
    internal static partial class XElementExtensions
    {
        /// <summary>
        /// Merges the XML elements into a single string.
        /// </summary>
        public static string Merge(this ImmutableArray<XElement> elements)
        {
            if (elements.IsDefaultOrEmpty)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();

            foreach (XElement element in elements)
            {
                builder = builder.AppendLine(element.ToString());
            }

            return builder.ToString();
        }
    }
}