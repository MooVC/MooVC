namespace MooVC.IO
{
    using System.Collections.Generic;
    using System.IO;

    public static partial class StreamExtensions
    {
        public static IEnumerable<byte> GetBytes(this Stream source)
        {
            using var target = new MemoryStream();

            source.Position = 0;
            source.CopyTo(target);

            return target.ToArray();
        }
    }
}