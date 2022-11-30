namespace MooVC.Collections.Generic.ObjectExtensionsTests;

using System;
using System.Collections.Generic;
using Xunit;

public sealed class WhenAsEnumerableIsCalled
{
    [Fact]
    public void GivenAValueTypeThenAnArrayContainingTheValueIsReturned()
    {
        var expected = TimeSpan.FromHours(1);

        IEnumerable<TimeSpan> value = expected.AsEnumerable();

        TimeSpan actual = Assert.Single(value);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenANullValueTypeThenAnArrayContainingTheNullValueIsReturned()
    {
        TimeSpan? expected = default;

        IEnumerable<TimeSpan?> value = expected.AsEnumerable();

        TimeSpan? actual = Assert.Single(value);
        Assert.Null(actual);
    }

    [Fact]
    public void GivenAReferenceTypeThenAnArrayContainingTheValueIsReturned()
    {
        object expected = new();

        IEnumerable<object> value = expected.AsEnumerable();

        object actual = Assert.Single(value);
        Assert.Same(expected, actual);
    }

    [Fact]
    public void GivenANullReferenceTypeThenAnArrayContainingTheNullValueIsReturned()
    {
        object? expected = default;

        IEnumerable<object?> value = expected.AsEnumerable();

        object? actual = Assert.Single(value);
        Assert.Null(actual);
    }
}