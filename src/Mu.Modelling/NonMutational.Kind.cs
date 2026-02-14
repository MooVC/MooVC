namespace Mu.Modelling;

using Monify;

public partial class NonMutational
{
    [Monify(Type = typeof(string))]
    public sealed partial class Kind
    {
        public static readonly Kind ReadStore = "ReadStore";
        public static readonly Kind WriteStore = "WriteStore";

        private Kind(string value)
        {
            _value = value;
        }

        public bool IsReadStore => this == ReadStore;

        public bool IsWriteStore => this == WriteStore;

        public override string ToString()
        {
            return _value;
        }
    }
}