namespace MooVC.Collections.Generic.ObjectExtensionsTests;

using System;
using Xunit;

public sealed class WhenAsArrayIsCalled
{
    [Fact]
    public void GivenAValueTypeThenAnArrayContainingTheValueIsReturned()
    {
        var expected = TimeSpan.FromHours(1);

        TimeSpan[] value = expected.AsArray();

        TimeSpan actual = Assert.Single(value);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GivenANullValueTypeThenAnArrayContainingTheNullValueIsReturned()
    {
        TimeSpan? expected = default;

        TimeSpan?[] value = expected.AsArray();

        TimeSpan? actual = Assert.Single(value);
        Assert.Null(actual);
    }

    [Fact]
    public void GivenAReferenceTypeThenAnArrayContainingTheValueIsReturned()
    {
        object expected = new object();

        object[] value = expected.AsArray();

        object actual = Assert.Single(value);
        Assert.Same(expected, actual);
    }

    [Fact]
    public void GivenANullReferenceTypeThenAnArrayContainingTheNullValueIsReturned()
    {
        object? expected = default;

        object?[] value = expected.AsArray();

        object? actual = Assert.Single(value);
        Assert.Null(actual);
    }
}