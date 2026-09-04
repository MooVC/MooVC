namespace MooVC.Infrastructure.Serialization.MessagePack
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using global::MessagePack;
    using MooVC.Compression;
    using static System.String;
    using static MooVC.Infrastructure.Serialization.MessagePack.Resources;
    using Base = MooVC.Serialization.Serializer;

    /// <summary>
    /// Provides MessagePack serialization.
    /// </summary>
    /// <remarks>
    /// Delegates serialization to <see cref="MessagePackSerializer" /> using configured <see cref="MessagePackSerializerOptions" /> and optional stream compression.
    /// </remarks>
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    public sealed class Serializer
        : Base
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Serializer"/> class.
        /// </summary>
        /// <param name="compressor">The optional stream compressor.</param>
        /// <param name="options">The MessagePack serializer options.</param>
        public Serializer(ICompressor compressor = default, MessagePackSerializerOptions options = default)
            : base(compressor: compressor)
        {
            Options = options ?? MessagePackSerializerOptions.Standard;
        }

        /// <summary>
        /// Gets the MessagePack serializer options used for serialization operations.
        /// </summary>
        public MessagePackSerializerOptions Options { get; }

        protected override async Task<T> PerformDeserialize<T>(Stream source, CancellationToken cancellationToken)
        {
            var result = await MessagePackSerializer
                .DeserializeAsync<T>(source, options: Options, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            if (ReferenceEquals(result, null))
            {
                throw new MessagePackSerializationException(Format(CultureInfo.InvariantCulture, SerializerPerformDeserializeAsyncFailure, typeof(T)));
            }

            return result;
        }

        protected override Task PerformSerialize<T>(T instance, Stream target, CancellationToken cancellationToken)
        {
            return MessagePackSerializer.SerializeAsync(
                target,
                instance,
                options: Options,
                cancellationToken: cancellationToken);
        }

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Serializer)} {{ {nameof(Options)} = `{DebuggerDisplayFormatter.Format(Options)}` }}";
        }
    }
}