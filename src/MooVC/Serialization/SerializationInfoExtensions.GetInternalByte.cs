namespace MooVC.Serialization
{
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static byte GetInternalByte(this SerializationInfo info, string name)
        {
            return info.GetByte(FormatName(name));
        }
    }
}