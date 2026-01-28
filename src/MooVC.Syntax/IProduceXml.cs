namespace MooVC.Syntax
{
    using System.Collections.Immutable;
    using System.Xml.Linq;

    /// <summary>
    /// Defines a contract for producing XML fragments as a collection of <see cref="XElement"/> objects.
    /// </summary>
    public interface IProduceXml
    {
        /// <summary>
        /// Returns the XML fragments that represent the current object's content.
        /// </summary>
        /// <returns>
        /// An immutable array of <see cref="XElement"/> objects containing the XML fragments. The array will be empty if there is no content.
        /// </returns>
        ImmutableArray<XElement> ToFragments();
    }
}