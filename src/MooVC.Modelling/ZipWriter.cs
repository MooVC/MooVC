namespace MooVC.Modelling;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

internal sealed class ZipWriter
    : IWriter
{
    public async Task Write(IAsyncEnumerable<File> files, Stream stream, CancellationToken cancellationToken)
    {
        await foreach (File file in files.ConfigureAwait(false))
        {
            Write(file);
        }
    }

    private static void Write(File file)
    {
        throw new NotImplementedException();
    }
}