namespace MooVC.Serialization
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    [Obsolete("BinaryFormatter serialization is obsolete and should not be used. See https://aka.ms/binaryformatter for more information.", DiagnosticId = "SYSLIB0011", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
    public sealed class BinaryFormatterCloner
        : ICloner
    {
        public T Clone<T>(T original)
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