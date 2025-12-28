namespace MooVC.Syntax.CSharp.Attributes.Project
{
    using System.Linq;
    using System.Xml.Linq;

    public sealed partial class TargetTask
    {
        public XElement ToFragment()
        {
            var attributes = Parameters
                .Where(parameter => !parameter.IsUndefined && !parameter.Value.IsEmpty)
                .Select(parameter => new XAttribute(ProjectXml.ElementName(parameter.Name, nameof(TaskParameter)), parameter.Value.ToString()));

            var outputs = Outputs
                .Where(output => !output.IsUndefined)
                .Select(output => output.ToFragment());

            return new XElement(
                ProjectXml.ElementName(Name, nameof(TargetTask)),
                ProjectXml.Attribute(nameof(Condition), Condition),
                ProjectXml.Attribute(nameof(ContinueOnError), ContinueOnError),
                attributes,
                outputs);
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