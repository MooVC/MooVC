namespace MooVC.IO.StreamExtensionsTests;

using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

public sealed class WhenGetBytesIsCalled
{
    [Fact]
    public void GivenAStreamThenTheBytesWithinTheStreamAreReturned()
    {
        byte[] expected = new byte[] { 1, 2, 3 };
        using var stream = new MemoryStream(expected);
        IEnumerable<byte> actual = stream.GetBytes();

        Assert.Equal(expected, actual);
    }
}