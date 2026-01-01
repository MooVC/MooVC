namespace MooVC.Syntax
{
    using System.Collections.Immutable;
    using System.Text;
    using System.Xml.Linq;

    internal static partial class XElementExtensions
    {
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