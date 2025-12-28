namespace MooVC.Syntax.CSharp.Attributes.Project
{
    using System.Xml.Linq;

    public sealed partial class Sdk
    {
        public XElement ToFragment()
        {
            return new XElement(
                nameof(Sdk),
                ProjectXml.Attribute(nameof(Name), Name),
                ProjectXml.Attribute(nameof(Version), Version),
                ProjectXml.Attribute(nameof(MinimumVersion), MinimumVersion));
        }

        public override string ToString()
        {
            if (IsUnspecified)
            {
                return string.Empty;
            }

            return ToFragment().ToString();
        }
    }
}