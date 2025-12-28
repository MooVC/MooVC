namespace MooVC.Syntax.CSharp.Attributes.Project
{
    using System.Xml.Linq;

    public sealed partial class Import
    {
        public XElement ToFragment()
        {
            return new XElement(
                nameof(Import),
                ProjectXml.Attribute(nameof(Project), Project),
                ProjectXml.Attribute(nameof(Sdk), Sdk),
                ProjectXml.Attribute(nameof(Condition), Condition),
                ProjectXml.Attribute(nameof(Label), Label));
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