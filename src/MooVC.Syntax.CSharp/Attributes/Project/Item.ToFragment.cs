namespace MooVC.Syntax.CSharp.Attributes.Project
{
    using System.Linq;
    using System.Xml.Linq;

    public sealed partial class Item
    {
        public XElement ToFragment()
        {
            var metadata = Metadata
                .Where(entry => !entry.IsUndefined)
                .Select(entry => entry.ToFragment());

            return new XElement(
                nameof(Item),
                ProjectXml.Attribute(nameof(Condition), Condition),
                ProjectXml.Attribute(nameof(Exclude), Exclude),
                ProjectXml.Attribute(nameof(Include), Include),
                ProjectXml.Attribute(nameof(KeepDuplicates), KeepDuplicates),
                ProjectXml.Attribute(nameof(MatchOnMetadata), MatchOnMetadata),
                ProjectXml.Attribute(nameof(MatchOnMetadataOptions), MatchOnMetadataOptions),
                ProjectXml.Attribute(nameof(Remove), Remove),
                ProjectXml.Attribute(nameof(RemoveMetadata), RemoveMetadata),
                ProjectXml.Attribute(nameof(Update), Update),
                metadata);
        }

        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToFragment().ToString();
        }
    }
}