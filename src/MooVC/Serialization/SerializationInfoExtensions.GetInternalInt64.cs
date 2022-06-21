namespace MooVC.Serialization;

using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    public static long GetInternalInt64(this SerializationInfo info, string name)
    {
        return info.GetInt64(FormatName(name));
    }
}