namespace MooVC.Serialization
{
    internal static partial class ObjectExtensions
    {
        public static T Clone<T>(this T original)
        {
            return original
                .Serialize()
                .Deserialize<T>();
        }
    }
}