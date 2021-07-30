namespace MooVC.Serialization
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Bson;

    internal static partial class ObjectExtensions
    {
        public static IEnumerable<byte> Serialize<T>(this T original)
        {
            var serializer = JsonSerializer.CreateDefault();

            using var target = new MemoryStream();
            using var binary = new BinaryWriter(target, Encoding.UTF8);
            using var writer = new BsonDataWriter(binary);

            serializer.Serialize(writer, original);

            return target.ToArray();
        }
    }
}