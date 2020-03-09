namespace MooVC.Serialization
{
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static bool GetInternalBoolean(this SerializationInfo info, string name)
        {
            return info.GetBoolean(FormatName(name));
        }
    }
}