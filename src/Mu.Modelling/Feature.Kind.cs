namespace Mu.Modelling;

using Monify;

public partial class Feature
{
    [Monify(Type = typeof(byte))]
    public sealed partial class Kind
    {
        public static readonly Kind Mutational = new(0);
        public static readonly Kind NonMutational = new(1);

        private Kind(byte value)
        {
            _value = value;
        }

        public bool IsMutational => this == Mutational;

        public bool IsNonMutational => this == NonMutational;
    }
}