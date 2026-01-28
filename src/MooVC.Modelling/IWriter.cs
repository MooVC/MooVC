namespace MooVC.Modelling;

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public interface IWriter
{
    Task Write(IAsyncEnumerable<File> files, Stream stream, CancellationToken cancellationToken);
}