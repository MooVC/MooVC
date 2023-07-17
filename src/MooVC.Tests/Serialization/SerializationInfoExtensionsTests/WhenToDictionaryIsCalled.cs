﻿namespace MooVC.Serialization.SerializationInfoExtensionsTests;

using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Xunit;

public sealed class WhenToDictionaryIsCalled
{
    [Fact]
    public void GivenAEnumeratorThenADictionaryWithTheValuesFromTheEnumeratorIsReturned()
    {
        const string First = "Hello";
        const string Second = "World";
        const int ExpectedCount = 2;

        var info = new SerializationInfo(GetType(), new FormatterConverter());

        info.AddValue(nameof(First), First);
        info.AddValue(nameof(Second), Second);

        IDictionary<string, object?> result = info.ToDictionary();

        Assert.Equal(ExpectedCount, result.Count);
        Assert.Equal(First, result[nameof(First)]);
        Assert.Equal(Second, result[nameof(Second)]);
    }

    [Fact]
    public void GivenAnEmptyEnumeratorThenAnEmptyDictionaryIsReturned()
    {
        var info = new SerializationInfo(GetType(), new FormatterConverter());
        IDictionary<string, object?> result = info.ToDictionary();

        Assert.Empty(result);
    }
}