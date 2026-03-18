namespace MooVC.IO.StreamExtensionsTests;

using System.IO;
using System.Text;

public sealed class WhenGetBytesIsCalled
{
    [Test]
    public async Task GivenAStreamThenTheBytesWithinTheStreamAreReturned()
    {
        // Arrange
        byte[] expected = [1, 2, 3];
        using var stream = new MemoryStream(expected);

        // Act
        IEnumerable<byte> actual = stream.GetBytes();

        // Assert
        _ = await Assert.That(actual).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenAnEmptyStreamThenAnEmptyByteCollectionIsReturned()
    {
        // Arrange
        byte[] expected = [];
        using var stream = new MemoryStream(expected);

        // Act
        IEnumerable<byte> actual = stream.GetBytes();

        // Assert
        _ = await Assert.That(actual).IsEmpty();
    }

    [Test]
    public async Task GivenANullStreamThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        Stream? source = default;

        // Act
        Action act = () => source!.GetBytes();

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(source));
    }
}