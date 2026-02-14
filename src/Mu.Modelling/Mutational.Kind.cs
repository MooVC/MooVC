namespace Mu.Modelling;

using Monify;

public partial class Mutational
{
    [Monify(Type = typeof(string))]
    public sealed partial class Kind
    {
        public static readonly Kind Creational = "Creational";
        public static readonly Kind Transitional = "Transitional";

        private Kind(string value)
        {
            _value = value;
        }

        public bool IsCreational => this == Creational;

        public bool IsTransitional => this == Transitional;

        public override string ToString()
        {
            return _value;
        }
    }
}