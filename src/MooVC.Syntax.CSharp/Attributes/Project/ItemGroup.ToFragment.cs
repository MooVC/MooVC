namespace MooVC.Syntax.CSharp.Attributes.Project
{
    using System.Linq;
    using System.Xml.Linq;

    public sealed partial class ItemGroup
    {
        public XElement ToFragment()
        {
            var items = Items
                .Where(item => !item.IsUndefined)
                .Select(item => item.ToFragment());

            return new XElement(
                nameof(ItemGroup),
                ProjectXml.Attribute(nameof(Condition), Condition),
                ProjectXml.Attribute(nameof(Label), Label),
                items);
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