namespace MooVC.Serialization
{
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static sbyte GetInternalSbyte(this SerializationInfo info, string name)
        {
            return info.GetSByte(FormatName(name));
        }
    }
}