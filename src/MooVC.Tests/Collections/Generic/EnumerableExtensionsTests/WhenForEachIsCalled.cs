namespace MooVC.Collections.Generic.EnumerableExtensionsTests;

using System;
using System.Collections.Generic;
using Xunit;

public sealed class WhenForEachIsCalled
{
    [Fact]
    public void GivenAnEnumerationWhenAnActionIsProvidedThenTheActionIsInvokedInOrderForEachEnumerationMember()
    {
        int[] enumeration = new[] { 1, 2, 3 };
        var invocations = new List<int>();

        void Action(int value)
        {
            invocations.Add(value);
        }

        enumeration.ForEach(Action);

        Assert.Equal(enumeration, invocations);
    }

    [Fact]
    public void GivenAnEnumerationWhenNoActionIsProvidedThenAnArgumentNullExceptionIsThrown()
    {
        int[] enumeration = new[] { 1, 2, 3 };
        Action<int>? action = default;

        ArgumentNullException? exception = Assert.Throws<ArgumentNullException>(
            () => enumeration.ForEach(action!));

        Assert.Equal(nameof(action), exception.ParamName);
    }

    [Fact]
    public void GivenANullEnumerationWhenAnActionIsProvidedThenTheActionIsGracefullyIgnored()
    {
        IEnumerable<int>? enumeration = default;
        bool wasInvoked = false;

        void Action(int value)
        {
            wasInvoked = true;
        }

        enumeration.ForEach(Action);

        Assert.False(wasInvoked);
    }

    [Fact]
    public void GivenANullEnumerationWhenNoActionIsProvidedThenNoArgumentNullExceptionIsThrown()
    {
        IEnumerable<int>? enumeration = default;

        enumeration.ForEach(default!);
    }
}