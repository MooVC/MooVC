namespace MooVC.Serialization;

using System;
using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    public static DateTime GetInternalDateTime(this SerializationInfo info, string name)
    {
        return info.GetDateTime(FormatName(name));
    }
}