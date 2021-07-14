namespace MooVC.Serialization
{
    using System;
    using System.Runtime.Serialization;

    public interface IDeserializer
    {
        T Deserialize<T>(ReadOnlySpan<byte> binary)
            where T : ISerializable;
    }
}