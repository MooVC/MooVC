namespace MooVC.Modelling;

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Defines a writer for modelling files.
/// </summary>
public interface IWriter
{
    /// <summary>
    /// Writes the provided files to the target stream.
    /// </summary>
    /// <param name="files">The files to write.</param>
    /// <param name="stream">The target stream.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous write operation.</returns>
    Task Write(IAsyncEnumerable<File> files, Stream stream, CancellationToken cancellationToken);
}