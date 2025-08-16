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
        actual.ShouldBe(expected);
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
        actual.ShouldBeEmpty();
    }

    [Fact]
    public void GivenANullStreamThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        Stream? source = default;

        // Act
        Action act = () => source!.GetBytes();

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(act);
        exception.ParamName.ShouldBe(nameof(source));
    }
}