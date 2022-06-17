namespace MooVC.Serialization;

using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    public static int GetInternalInt32(this SerializationInfo info, string name)
    {
        return info.GetInt32(FormatName(name));
    }
}