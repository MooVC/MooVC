namespace MooVC.Serialization
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    public static partial class DeserializerExtensions
    {
        public static bool TryDeserialize<T>(
            this IDeserializer deserializer,
            ReadOnlySpan<byte> binary,
            [NotNullWhen(true)] out T? instance,
            Action<Exception>? onFailure = default)
            where T : ISerializable
        {
            instance = default;

            try
            {
                instance = deserializer.Deserialize<T>(binary);

                return true;
            }
            catch (Exception ex)
            {
                onFailure?.Invoke(ex);
            }

            return false;
        }
    }
}