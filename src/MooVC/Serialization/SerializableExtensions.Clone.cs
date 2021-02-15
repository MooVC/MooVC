namespace MooVC.Serialization
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    public static class SerializableExtensions
    {
        [Obsolete("BinaryFormatter serialization is obsolete in NET 5.0 and should not be used. See https://aka.ms/binaryformatter for more information.", false)]

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