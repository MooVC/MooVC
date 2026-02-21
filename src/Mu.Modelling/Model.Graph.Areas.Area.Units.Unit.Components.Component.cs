namespace Mu.Modelling;

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
                        public partial class Components
                        {
                            public partial class Component
                            {
                                public Qualifier Namespace => new([Root.Company, Root.Name, Area.Name, Value.Name]);

                                public string ProjectName => Separator.Combine(Root.Company, Root.Name, Area.Name, Value.Name);

                                public Directive[] References => Value.Attributes.GetReferences(Namespace);
                            }
                        }
                    }
                }
            }
        }
    }
}