namespace MooVC.Serialization.SynchronousSerializerTests
{
    using System;
    using System.IO;
    using MooVC.Compression;

    public sealed class TestableSynchronousSerializer
        : SynchronousSerializer
    {
        private readonly Func<object, object>? onDeserialize;
        private readonly Action<object, Stream>? onSerialize;

        public TestableSynchronousSerializer(
            ICompressor? compressor = default,
            Func<object, object>? onDeserialize = default,
            Action<object, Stream>? onSerialize = default)
            : base(compressor: compressor)
        {
            this.onDeserialize = onDeserialize;
            this.onSerialize = onSerialize;
        }

        protected override T PerformDeserialize<T>(Stream source)
        {
            return (T)onDeserialize!.Invoke(source);
        }

        protected override void PerformSerialize<T>(T instance, Stream target)
        {
            onSerialize!.Invoke(instance, target);
        }
    }
}