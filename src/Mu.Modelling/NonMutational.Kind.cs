namespace Mu.Modelling;

using Monify;

public partial class NonMutational
{
    [Monify(Type = typeof(byte))]
    public sealed partial class Kind
    {
        public static readonly Kind ReadStore = new(0);
        public static readonly Kind WriteStore = new(1);

        private Kind(byte value)
        {
            _value = value;
        }

        public bool IsReadStore => this == ReadStore;

        public bool IsWriteStore => this == WriteStore;
    }
}