namespace MooVC.Serialization
{
    using Newtonsoft.Json;

    internal static class Settings
    {
        public static readonly JsonSerializerSettings Default = new()
        {
            TypeNameHandling = TypeNameHandling.All,
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full,
        };
    }
}