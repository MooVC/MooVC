namespace MooVC.Serialization
{
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static T TryGetInternalValue<T>(this SerializationInfo info, string name, T defaultValue = default)
        {
            return info.TryGetValue(FormatName(name), defaultValue: defaultValue);
        }
    }
}