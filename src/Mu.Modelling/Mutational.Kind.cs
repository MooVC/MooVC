namespace Mu.Modelling;

using Monify;

public partial class Mutational
{
    [Monify(Type = typeof(byte))]
    public sealed partial class Kind
    {
        public static readonly Kind Creational = new(0);
        public static readonly Kind Transitional = new(1);

        private Kind(byte value)
        {
            _value = value;
        }

        public bool IsCreational => this == Creational;

        public bool IsTransitional => this == Transitional;
    }
}