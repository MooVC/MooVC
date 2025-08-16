#if NET6_0_OR_GREATER
namespace MooVC.Paging.DirectiveTests;

using MooVC.Serialization;
using Serializer = MooVC.Serialization.Json.Serializer;

public sealed class WhenDirectiveIsSerialized
{
    [Fact]
    public async Task GivenAnInstanceThenTheInstanceIsSerialized()
    {
        // Arrange
        var cloner = new Cloner(new Serializer());
        Directive original = new(Limit: 25, Page: 2);

        // Act
        Directive cloned = await cloner.Clone(original, CancellationToken.None);

        // Assert
        cloned.ShouldBe(original);
    }
}
#endif