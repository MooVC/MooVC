namespace MooVC.Serialization.DefaultClonerTests;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;

public sealed class WhenCloneAsyncIsCalled
{
    [Fact]
    public async Task GivenAnInstanceThenTheSerializerIsInvokedAsync()
    {
        // Arrange
        WhenCloneAsyncIsCalled instance = this;
        var serializer = new Mock<ISerializer>();
        var cloner = new DefaultCloner(serializer.Object);
        IEnumerable<byte> binary = new byte[] { 1, 2, 3 };

        _ = serializer
            .Setup(s => s.SerializeAsync(
                It.Is<WhenCloneAsyncIsCalled>(i => i == instance),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(binary);

        _ = serializer
            .Setup(s => s.DeserializeAsync<WhenCloneAsyncIsCalled>(
                It.Is<IEnumerable<byte>>(b => b == binary),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(this);

        // Act
        WhenCloneAsyncIsCalled clone = await cloner.CloneAsync(instance, CancellationToken.None);

        // Assert
        serializer.Verify(
            s => s.SerializeAsync(
                It.IsAny<WhenCloneAsyncIsCalled>(),
                It.IsAny<CancellationToken>()),
            Times.Once);

        serializer.Verify(
           s => s.SerializeAsync(
               It.Is<WhenCloneAsyncIsCalled>(parameter => parameter == instance),
               It.IsAny<CancellationToken>()),
           Times.Once);

        serializer.Verify(
            s => s.DeserializeAsync<WhenCloneAsyncIsCalled>(
                It.IsAny<IEnumerable<byte>>(),
                It.IsAny<CancellationToken>()),
            Times.Once);

        serializer.Verify(
            s => s.DeserializeAsync<WhenCloneAsyncIsCalled>(
                It.Is<IEnumerable<byte>>(parameter => parameter == binary),
                It.IsAny<CancellationToken>()),
            Times.Once);

        _ = clone.Should().Be(instance);
    }

    [Fact]
    public async Task GivenNullInstanceThenArgumentNullExceptionIsThrownAsync()
    {
        // Arrange
        WhenCloneAsyncIsCalled original = default!;
        var serializer = new Mock<ISerializer>();
        var cloner = new DefaultCloner(serializer.Object);

        // Act
        Func<Task> act = async () => await cloner.CloneAsync(original, CancellationToken.None);

        // Assert
        _ = await act.Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName(nameof(original));
    }
}