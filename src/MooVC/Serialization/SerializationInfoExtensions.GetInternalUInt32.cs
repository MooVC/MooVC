namespace MooVC.Serialization;

using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    public static uint GetInternalUInt32(this SerializationInfo info, string name)
    {
        return info.GetUInt32(FormatName(name));
    }
}