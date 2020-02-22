namespace MooVC.Serialization
{
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static bool TryAddValue<T>(this SerializationInfo info, string name, T value, T defaultValue = default)
        {
            if (value is null || value.Equals(defaultValue))
            {
                return false;
            }

            info.AddValue(name, value);

            return true;
        }
    }
}