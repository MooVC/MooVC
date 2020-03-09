namespace MooVC.Serialization
{
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static string GetInternalString(this SerializationInfo info, string name)
        {
            return info.GetString(FormatName(name));
        }
    }
}