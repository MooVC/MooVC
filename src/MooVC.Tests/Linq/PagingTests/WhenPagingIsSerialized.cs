#if NET6_0_OR_GREATER
namespace MooVC.Linq.PagingTests;

using MooVC.Serialization;
using Serializer = MooVC.Serialization.Json.Serializer;

public sealed class WhenPagingIsSerialized
{
    [Fact]
    public async Task GivenAnInstanceThenTheInstanceIsSerialized()
    {
        // Arrange
        var cloner = new Cloner(new Serializer());
        Paging original = (Page: 2, Size: 25);

        // Act
        Paging cloned = await cloner.Clone(original, CancellationToken.None);

        // Assert
        _ = cloned.Should().NotBeNull();
        _ = cloned.Should().NotBeSameAs(original);
        _ = cloned.Should().BeEquivalentTo(original);
    }
}
#endif