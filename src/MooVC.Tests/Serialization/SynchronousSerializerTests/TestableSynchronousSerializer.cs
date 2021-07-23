namespace MooVC.Serialization.SynchronousSerializerTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public sealed class TestableSynchronousSerializer
        : SynchronousSerializer
    {
        private readonly Func<object, object>? onDeserialize;
        private readonly Func<object, object>? onSerialize;
        private readonly Action<object, Stream>? onSerializeTo;

        public TestableSynchronousSerializer(
            Func<object, object>? onDeserialize = default,
            Func<object, object>? onSerialize = default,
            Action<object, Stream>? onSerializeTo = default)
        {
            this.onDeserialize = onDeserialize;
            this.onSerialize = onSerialize;
            this.onSerializeTo = onSerializeTo;
        }

        protected override T PerformDeserialize<T>(IEnumerable<byte> data)
        {
            return (T)onDeserialize!.Invoke(data);
        }

        protected override T PerformDeserialize<T>(Stream source)
        {
            return (T)onDeserialize!.Invoke(source);
        }

        protected override IEnumerable<byte> PerformSerialize<T>(T instance)
        {
            return (IEnumerable<byte>)onSerialize!.Invoke(instance);
        }

        protected override void PerformSerialize<T>(T instance, Stream target)
        {
            onSerializeTo!.Invoke(instance, target);
        }
    }
}