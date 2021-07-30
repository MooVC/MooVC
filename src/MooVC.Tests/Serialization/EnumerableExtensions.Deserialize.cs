namespace MooVC.Serialization
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Bson;

    internal static partial class EnumerableExtensions
    {
        public static T Deserialize<T>(this IEnumerable<byte> data)
        {
            var serializer = JsonSerializer.CreateDefault();

            using var source = new MemoryStream(data.ToArray());
            using var binary = new BinaryReader(source, Encoding.UTF8);
            using var reader = new BsonDataReader(binary);

            return serializer.Deserialize<T>(reader);
        }
    }
}