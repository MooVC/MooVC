namespace MooVC.Compression.SynchronousCompressorTests;

using System.Diagnostics.CodeAnalysis;
using System.IO;
using MooVC.IO;

internal sealed class TestableSynchronousCompressor
    : SynchronousCompressor
{
    [SuppressMessage("Major Code Smell", "S1854:Unused assignments should be removed", Justification = "Assignment is used.")]
    protected override Stream PerformCompress(Stream source)
    {
        return new MemoryStream(source.GetBytes().Select(@byte => ++@byte).ToArray());
    }

    [SuppressMessage("Major Code Smell", "S1854:Unused assignments should be removed", Justification = "Assignment is used.")]
    protected override Stream PerformDecompress(Stream source)
    {
        return new MemoryStream(source.GetBytes().Select(@byte => --@byte).ToArray());
    }
}