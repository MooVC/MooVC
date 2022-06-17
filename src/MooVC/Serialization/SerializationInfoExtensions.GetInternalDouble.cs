namespace MooVC.Serialization;

using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    public static double GetInternalDouble(this SerializationInfo info, string name)
    {
        return info.GetDouble(FormatName(name));
    }
}