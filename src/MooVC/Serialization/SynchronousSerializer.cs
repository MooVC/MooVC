namespace MooVC.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class SynchronousSerializer
        : ISerializer
    {
        public Task<T> DeserializeAsync<T>(
            IEnumerable<byte> data,
            CancellationToken? cancellationToken = default)
            where T : notnull
        {
            return Task.FromResult(PerformDeserialize<T>(data));
        }

        public Task<T> DeserializeAsync<T>(
            Stream source,
            CancellationToken? cancellationToken = default)
            where T : notnull
        {
            return Task.FromResult(PerformDeserialize<T>(source));
        }

        public Task<IEnumerable<byte>> SerializeAsync<T>(
            T instance,
            CancellationToken? cancellationToken = default)
            where T : notnull
        {
            return Task.FromResult(PerformSerialize(instance));
        }

        public Task SerializeAsync<T>(
            T instance,
            Stream target,
            CancellationToken? cancellationToken = default)
            where T : notnull
        {
            PerformSerialize(instance, target);

            return Task.CompletedTask;
        }

        protected abstract T PerformDeserialize<T>(IEnumerable<byte> data)
            where T : notnull;

        protected abstract T PerformDeserialize<T>(Stream source)
            where T : notnull;

        protected abstract IEnumerable<byte> PerformSerialize<T>(T instance)
            where T : notnull;

        protected abstract void PerformSerialize<T>(T instance, Stream target)
            where T : notnull;
    }
}