namespace MooVC.IO.StreamExtensionsTests;

using System.Collections.Generic;
using System.IO;
using System.Text;
using FluentAssertions;
using Xunit;

public sealed class WhenGetBytesIsCalled
{
    [Fact]
    public void GivenAStreamThenTheBytesWithinTheStreamAreReturned()
    {
        // Arrange
        byte[] expected = new byte[] { 1, 2, 3 };
        using var stream = new MemoryStream(expected);

        // Act
        IEnumerable<byte> actual = stream.GetBytes();

        // Assert
        _ = actual.Should().Equal(expected);
    }

    [Fact]
    public void GivenAnEmptyStreamThenAnEmptyByteCollectionIsReturned()
    {
        // Arrange
        byte[] expected = Array.Empty<byte>();
        using var stream = new MemoryStream(expected);

        // Act
        IEnumerable<byte> actual = stream.GetBytes();

        // Assert
        _ = actual.Should().BeEmpty();
    }

    [Fact]
    public void GivenANullStreamThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        Stream? stream = default;

        // Act
        Action act = () => stream!.GetBytes();

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(stream));
    }
}