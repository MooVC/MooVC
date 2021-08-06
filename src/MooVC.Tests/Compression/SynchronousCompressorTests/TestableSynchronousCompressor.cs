namespace MooVC.Compression.SynchronousCompressorTests
{
    using System.IO;
    using System.Linq;
    using MooVC.IO;

    internal sealed class TestableSynchronousCompressor
        : SynchronousCompressor
    {
        protected override Stream PerformCompress(Stream source)
        {
            return new MemoryStream(source.GetBytes().Select(@byte => ++@byte).ToArray());
        }

        protected override Stream PerformDecompress(Stream source)
        {
            return new MemoryStream(source.GetBytes().Select(@byte => --@byte).ToArray());
        }
    }
}