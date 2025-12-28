namespace MooVC.Syntax.CSharp.Attributes.Project
{
    using System.Linq;
    using System.Xml.Linq;

    public sealed partial class PropertyGroup
    {
        public XElement ToFragment()
        {
            var properties = Properties
                .Where(property => !property.IsUndefined)
                .Select(property => property.ToFragment());

            return new XElement(
                nameof(PropertyGroup),
                ProjectXml.Attribute(nameof(Condition), Condition),
                ProjectXml.Attribute(nameof(Label), Label),
                properties);
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