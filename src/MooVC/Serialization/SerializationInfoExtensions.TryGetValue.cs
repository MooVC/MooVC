namespace MooVC.Serialization
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        [return: NotNullIfNotNull("defaultValue")]
        public static T? TryGetValue<T>(this SerializationInfo info, string name, T? defaultValue = default)
        {
            try
            {
                object? value = info.GetValue(name, typeof(T));

                if (value is T result)
                {
                    return result;
                }

                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}