namespace MooVC.Serialization
{
    using Newtonsoft.Json;

    internal static partial class EnumerableExtensions
    {
        public static T Deserialize<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json, Settings.Default)!;
        }
    }
}