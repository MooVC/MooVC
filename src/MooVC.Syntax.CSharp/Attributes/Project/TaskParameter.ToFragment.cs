namespace MooVC.Syntax.CSharp.Attributes.Project
{
    using System.Xml.Linq;

    public sealed partial class TaskParameter
    {
        public XElement ToFragment()
        {
            return new XElement(
                "Parameter",
                ProjectXml.Attribute(nameof(Name), Name),
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