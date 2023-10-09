namespace MooVC.Serialization.ClonerTests;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Xunit;

public sealed class WhenCloneAsyncIsCalled
{
    [Fact]
    public async Task GivenAnInstanceThenTheSerializerIsInvokedAsync()
    {
        // Arrange
        WhenCloneAsyncIsCalled instance = this;
        ISerializer serializer = Substitute.For<ISerializer>();
        var cloner = new Cloner(serializer);
        IEnumerable<byte> binary = new byte[] { 1, 2, 3 };

        _ = serializer
            .SerializeAsync(instance, Arg.Any<CancellationToken>())
            .Returns(binary);

        _ = serializer
            .DeserializeAsync<WhenCloneAsyncIsCalled>(binary, Arg.Any<CancellationToken>())
            .Returns(this);

        // Act
        WhenCloneAsyncIsCalled clone = await cloner.CloneAsync(instance, CancellationToken.None);

        // Assert
        _ = await serializer.Received(1).SerializeAsync(instance, Arg.Any<CancellationToken>());
        _ = await serializer.Received(1).DeserializeAsync<WhenCloneAsyncIsCalled>(binary, Arg.Any<CancellationToken>());

        _ = clone.Should().Be(instance);
    }

    [Fact]
    public async Task GivenNullInstanceThenArgumentNullExceptionIsThrownAsync()
    {
        // Arrange
        WhenCloneAsyncIsCalled original = default!;
        ISerializer serializer = Substitute.For<ISerializer>();
        var cloner = new Cloner(serializer);

        // Act
        Func<Task> act = async () => await cloner.CloneAsync(original, CancellationToken.None);

        // Assert
        _ = await act.Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName(nameof(original));
    }
}