namespace MooVC.Serialization;

using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    public static ushort GetInternalUInt16(this SerializationInfo info, string name)
    {
        return info.GetUInt16(FormatName(name));
    }
}