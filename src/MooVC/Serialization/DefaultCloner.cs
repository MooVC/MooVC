namespace MooVC.Serialization
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using static MooVC.Ensure;
    using static MooVC.Serialization.Resources;

    public sealed class DefaultCloner
        : ICloner
    {
        private readonly ISerializer serializer;

        public DefaultCloner(ISerializer serializer)
        {
            ArgumentNotNull(serializer, nameof(serializer), DefaultClonerSerializerRequired);

            this.serializer = serializer;
        }

        public async Task<T> CloneAsync<T>(
            T original,
            CancellationToken? cancellationToken = default)
            where T : notnull
        {
            IEnumerable<byte> data = await serializer
                .SerializeAsync(original, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            return await serializer
                .DeserializeAsync<T>(data, cancellationToken: cancellationToken)
                .ConfigureAwait(false);
        }
    }
}