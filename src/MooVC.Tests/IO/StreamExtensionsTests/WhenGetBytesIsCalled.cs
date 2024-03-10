namespace MooVC.IO.StreamExtensionsTests;

using System.IO;
using System.Text;

public sealed class WhenGetBytesIsCalled
{
    [Fact]
    public void GivenAStreamThenTheBytesWithinTheStreamAreReturned()
    {
        // Arrange
        byte[] expected = [1, 2, 3];
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
        byte[] expected = [];
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
        Stream? source = default;

        // Act
        Action act = () => source!.GetBytes();

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(source));
    }
}