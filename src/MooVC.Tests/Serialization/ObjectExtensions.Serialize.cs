namespace MooVC.Serialization;

using Newtonsoft.Json;

internal static partial class ObjectExtensions
{
    public static string Serialize<T>(this T original)
    {
        return JsonConvert.SerializeObject(original);
    }
}