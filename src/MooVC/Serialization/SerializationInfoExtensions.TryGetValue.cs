namespace MooVC.Serialization
{
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static T TryGetValue<T>(this SerializationInfo info, string name, T defaultValue = default)
        {
            try
            {
                return (T)info.GetValue(name, typeof(T));
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}