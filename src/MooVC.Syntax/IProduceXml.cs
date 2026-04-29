namespace MooVC.Syntax
{
    using System.Collections.Immutable;
    using System.Xml.Linq;

    /// <summary>
    /// Defines a contract for producing XML fragments as a collection of <see cref="XElement"/> objects.
    /// </summary>
    /// <remarks>
    /// Implementations should produce deterministic output so repeated invocations can be safely compared in tests.
    /// </remarks>
    public interface IProduceXml
    {
        /// <summary>
        /// Returns the XML fragments that represent the current object's content.
        /// </summary>
        /// <returns>
        /// An immutable array of <see cref="XElement"/> objects containing the XML fragments.
        /// </returns>
        /// <remarks>
        /// The returned array should be empty when no XML output is applicable for the current instance.
        /// </remarks>
        ImmutableArray<XElement> ToFragments();
    }
}