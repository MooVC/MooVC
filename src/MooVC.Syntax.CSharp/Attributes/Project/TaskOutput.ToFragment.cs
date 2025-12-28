namespace MooVC.Syntax.CSharp.Attributes.Project
{
    using System.Xml.Linq;

    public sealed partial class TaskOutput
    {
        public XElement ToFragment()
        {
            return new XElement(
                "Output",
                ProjectXml.Attribute(nameof(Condition), Condition),
                ProjectXml.Attribute(nameof(ItemName), ItemName),
                ProjectXml.Attribute(nameof(PropertyName), PropertyName),
                ProjectXml.Attribute(nameof(TaskParameter), TaskParameter));
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