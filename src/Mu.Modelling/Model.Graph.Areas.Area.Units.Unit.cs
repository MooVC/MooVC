namespace Mu.Modelling;

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
                    public sealed partial class Unit
                    {
                        private const string Separator = ".";

                        public string ProjectName => Separator.Combine(Root.Company, Root.Name, Area.Name, Value.Name);
                    }
                }
            }
        }
    }
}