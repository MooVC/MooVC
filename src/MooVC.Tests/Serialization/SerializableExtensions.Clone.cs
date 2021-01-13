namespace MooVC.Serialization
{
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    public static class SerializableExtensions
    {
        public static T Clone<T>(this T original)
            where T : ISerializable
        {
            var binaryFormatter = new BinaryFormatter();

            using var stream = new MemoryStream();

            binaryFormatter.Serialize(stream, original);
            _ = stream.Seek(0, SeekOrigin.Begin);

            return (T)binaryFormatter.Deserialize(stream);
        }
    }
}