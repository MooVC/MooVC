namespace MooVC.Serialization
{
    using System;
    using System.Runtime.Serialization;

    [Obsolete("BinaryFormatter serialization is obsolete in NET 5.0 and should not be used. See https://aka.ms/binaryformatter for more information.", false)]
    public sealed class BinaryFormatterCloner
        : ICloner
    {
        public T Clone<T>(T original)
            where T : ISerializable
        {
            return original.Clone();
        }
    }
}