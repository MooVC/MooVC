namespace MooVC.Serialization
{
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static string TryGetInternalString(this SerializationInfo info, string name, string? defaultValue = default)
        {
            return info.TryGetString(FormatName(name), defaultValue: defaultValue);
        }
    }
}