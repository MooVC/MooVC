namespace MooVC.Serialization
{
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static ulong GetInternalUInt64(this SerializationInfo info, string name)
        {
            return info.GetUInt64(FormatName(name));
        }
    }
}