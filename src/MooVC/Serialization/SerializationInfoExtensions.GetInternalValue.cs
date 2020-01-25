namespace MooVC.Serialization
{
    using System;
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static object GetValue(this SerializationInfo info, string name, Type type)
        {
            return info.GetValue(FormatName(name), type);
        }
    }
}