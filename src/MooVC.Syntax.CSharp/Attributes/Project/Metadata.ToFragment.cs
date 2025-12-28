namespace MooVC.Syntax.CSharp.Attributes.Project
{
    using System.Xml.Linq;

    public sealed partial class Metadata
    {
        public XElement ToFragment()
        {
            return new XElement(
                ProjectXml.ElementName(Name, nameof(Metadata)),
                ProjectXml.Attribute(nameof(Condition), Condition),
                Value.IsEmpty ? null : Value.ToString());
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