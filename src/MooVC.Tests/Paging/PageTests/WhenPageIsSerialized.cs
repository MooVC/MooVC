﻿#if NET6_0_OR_GREATER
namespace MooVC.Paging.PageTests;

using MooVC.Serialization;
using Serializer = MooVC.Serialization.Json.Serializer;

public sealed class WhenPageIsSerialized
{
    [Fact]
    public async Task GivenAnInstanceThenTheInstanceIsSerialized()
    {
        // Arrange
        var cloner = new Cloner(new Serializer());
        Directive directive = (Page: 2, Size: 25);
        ulong total = 5;
        int[] values = [1, 2, 3, 4];
        Page<int> original = new(directive, values, total: total);

        // Act
        Page<int> cloned = await cloner.Clone(original, CancellationToken.None);

        // Assert
        _ = cloned.Should().NotBeNull();
        _ = cloned.Should().NotBeSameAs(original);
        _ = cloned.Should().BeEquivalentTo(original);
    }
}
#endif