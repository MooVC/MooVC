namespace MooVC.Serialization
{
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static bool TryAddInternalValue<T>(this SerializationInfo info, string name, T value, T defaultValue = default)
        {
            return info.TryAddValue(FormatName(name), value, defaultValue: defaultValue);
        }
    }
}