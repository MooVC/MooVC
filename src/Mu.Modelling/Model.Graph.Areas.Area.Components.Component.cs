namespace Mu.Modelling;

using System.Collections.Immutable;
using MooVC.Linq;
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
                public partial class Components
                {
                    public partial class Component
                    {
                        public Qualifier Namespace => new([Root.Company, Root.Name, Area.Name]);

                        public string ProjectName => Separator.Combine(Root.Company, Root.Name, Area.Name);

                        public ImmutableArray<Directive> References => Value.Attributes.GetReferences(Namespace);
                    }
                }
            }
        }
    }
}