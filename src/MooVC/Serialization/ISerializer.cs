namespace MooVC.Serialization;

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public interface ISerializer
{
    Task<IEnumerable<byte>> SerializeAsync<T>(T instance, CancellationToken? cancellationToken = default)
        where T : notnull;

    Task SerializeAsync<T>(T instance, Stream target, CancellationToken? cancellationToken = default)
        where T : notnull;

    Task<T> DeserializeAsync<T>(IEnumerable<byte> data, CancellationToken? cancellationToken = default)
        where T : notnull;

    Task<T> DeserializeAsync<T>(Stream source, CancellationToken? cancellationToken = default)
        where T : notnull;
}