namespace Mu.Modelling;

using Monify;

public partial class Feature
{
    [Monify(Type = typeof(string))]
    public sealed partial class Kind
    {
        public static readonly Kind Mutational = "Mutational";
        public static readonly Kind NonMutational = "NonMutational";

        private Kind(string value)
        {
            _value = value;
        }

        public bool IsMutational => this == Mutational;

        public bool IsNonMutational => this == NonMutational;

        public override string ToString()
        {
            return _value;
        }
    }
}