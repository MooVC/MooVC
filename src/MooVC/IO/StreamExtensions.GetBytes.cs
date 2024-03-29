﻿namespace MooVC.IO;

using Ardalis.GuardClauses;
using static MooVC.IO.StreamExtensions_Resources;

/// <summary>
/// Provides extensions relating to <see cref="Stream" />.
/// </summary>
public static partial class StreamExtensions
{
    /// <summary>
    /// Reads the bytes from a stream and returns them as an enumerable sequence of bytes.
    /// </summary>
    /// <param name="source">The stream to read from.</param>
    /// <returns>An enumerable sequence of bytes representing the data in the source stream.</returns>
    public static IEnumerable<byte> GetBytes(this Stream source)
    {
        _ = Guard.Against.Null(source, message: GetBytesSourceRequired);

        using var target = new MemoryStream();

        source.Position = 0;
        source.CopyTo(target);

        return target.ToArray();
    }
}