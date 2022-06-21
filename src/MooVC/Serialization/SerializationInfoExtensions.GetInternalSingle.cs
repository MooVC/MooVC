namespace MooVC.Serialization;

using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    public static float GetInternalSingle(this SerializationInfo info, string name)
    {
        return info.GetSingle(FormatName(name));
    }
}