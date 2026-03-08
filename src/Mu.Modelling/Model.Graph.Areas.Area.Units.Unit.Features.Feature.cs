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
                public partial class Units
                {
                    public partial class Unit
                    {
                        public partial class Features
                        {
                            public partial class Feature
                            {
                                public string DomainName => Separator.Combine(Root.Company, Root.Name, Area.Name, Unit.Name);

                                public Qualifier Namespace => new([Root.Company, Root.Name, Area.Name, Unit.Name, Value.Name]);

                                public string ProjectName => Separator.Combine(Root.Company, Root.Name, Area.Name, Unit.Name, Value.Name);

                                public ImmutableArray<Directive> References => Value.Parameters.GetReferences(Namespace);
                            }
                        }
                    }
                }
            }
        }
    }
}