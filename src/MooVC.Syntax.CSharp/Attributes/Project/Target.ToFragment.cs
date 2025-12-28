namespace MooVC.Syntax.CSharp.Attributes.Project
{
    using System.Linq;
    using System.Xml.Linq;

    public sealed partial class Target
    {
        public XElement ToFragment()
        {
            var tasks = Tasks
                .Where(task => !task.IsUndefined)
                .Select(task => task.ToFragment());

            return new XElement(
                nameof(Target),
                ProjectXml.Attribute(nameof(AfterTargets), AfterTargets),
                ProjectXml.Attribute(nameof(BeforeTargets), BeforeTargets),
                ProjectXml.Attribute(nameof(Condition), Condition),
                ProjectXml.Attribute(nameof(DependsOnTargets), DependsOnTargets),
                ProjectXml.Attribute(nameof(Inputs), Inputs),
                ProjectXml.Attribute(nameof(KeepDuplicateOutputs), KeepDuplicateOutputs),
                ProjectXml.Attribute(nameof(Label), Label),
                ProjectXml.Attribute(nameof(Name), Name),
                ProjectXml.Attribute(nameof(Outputs), Outputs),
                ProjectXml.Attribute(nameof(Returns), Returns),
                tasks);
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