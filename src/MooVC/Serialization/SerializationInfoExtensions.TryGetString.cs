namespace MooVC.Serialization
{
    using System.Runtime.Serialization;
    using static System.String;

    public static partial class SerializationInfoExtensions
    {
        public static string TryGetString(this SerializationInfo info, string name, string? defaultValue = default)
        {
            defaultValue ??= Empty;

            return info.TryGetValue(name, defaultValue: defaultValue);
        }
    }
}