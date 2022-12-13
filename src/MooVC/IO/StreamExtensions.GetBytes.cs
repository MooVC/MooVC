namespace MooVC.IO;

using System;
using System.Collections.Generic;
using System.IO;

public static partial class StreamExtensions
{
    /// <summary>
    /// Reads the bytes from a stream and returns them as an enumerable sequence of bytes.
    /// </summary>
    /// <param name="source">The stream to read from.</param>
    /// <returns>An enumerable sequence of bytes representing the data in the source stream.</returns>
    public static IEnumerable<byte> GetBytes(this Stream source)
    {
        using var target = new MemoryStream();

        source.Position = 0;
        source.CopyTo(target);

        return target.ToArray();
    }
}