namespace Mu.Modelling;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;
using MooVC.Syntax.Formatting;

public partial class Model
{
    public static partial class Graph
    {
        public partial class Areas
        {
            public partial class Area
            {
                public Qualifier Namespace => new([Root.Company, Root.Name, Value.Name]);

                public string ProjectName => Separator.Combine(Root.Company, Root.Name, Value.Name);

                public ImmutableArray<Qualifier> Projects => Value.Components
                    .SelectMany(component => component.Attributes)
                    .GetProjects(Root.Company, Root.Name, Value.Name);

                public ImmutableArray<Directive> References => Value.Components
                    .SelectMany(component => component.Attributes)
                    .GetReferences(Namespace);
            }
        }
    }
}