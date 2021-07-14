namespace MooVC.Serialization
{
    using System;
    using System.Runtime.Serialization;

    public interface ISerializer
    {
        ReadOnlySpan<byte> Serialize<T>(T instance)
            where T : ISerializable;
    }
}