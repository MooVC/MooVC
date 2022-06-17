namespace MooVC.Diagnostics.DiagnosticsEmittedEventArgsExtensionsTests;

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public sealed class WhenThrowIsCalled
{
    [Fact]
    public void GivenAnEmptySourceWhenANullPredicateIsProvidedThenAnArgumentNullExceptionIsThrown()
    {
        IEnumerable<DiagnosticsEmittedAsyncEventArgs>? source = Array.Empty<DiagnosticsEmittedAsyncEventArgs>();
        Func<DiagnosticsEmittedAsyncEventArgs, Exception, bool>? predicate = default;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
            () => source.Throw(predicate!));

        Assert.Equal(nameof(predicate), exception.ParamName);
    }

    [Fact]
    public void GivenAnEmptySourceWhenNoPredicateIsProvidedThenNoAggregateExceptionIsThrown()
    {
        IEnumerable<DiagnosticsEmittedAsyncEventArgs>? source = Array.Empty<DiagnosticsEmittedAsyncEventArgs>();

        source.Throw();
    }

    [Fact]
    public void GivenAnNullSourceThenNoAggregateExceptionIsThrown()
    {
        IEnumerable<DiagnosticsEmittedAsyncEventArgs>? source = default;

        source.Throw();
    }

    [Fact]
    public void GivenASourceWhenALevelIsProvidedThenAnAggregateExceptionIsThrownWithTheExpectedDiagnosticsAsTheCause()
    {
        IEnumerable<DiagnosticsEmittedAsyncEventArgs> expected = new DiagnosticsEmittedAsyncEventArgs[]
        {
            new(cause: new InvalidOperationException(), level: Level.Critical),
            new(cause: new InvalidOperationException(), level: Level.Error),
            new(cause: new InvalidOperationException(), level: Level.Warning),
            new(cause: new InvalidOperationException(), level: Level.Information),
        };

        IEnumerable<DiagnosticsEmittedAsyncEventArgs> unexpected = new DiagnosticsEmittedAsyncEventArgs[]
        {
            new(level: Level.Critical),
            new(level: Level.Error),
            new(level: Level.Warning),
            new(level: Level.Information),
            new(cause: new InvalidOperationException(), level: Level.Debug),
            new(cause: new InvalidOperationException(), level: Level.Trace),
        };

        IEnumerable<DiagnosticsEmittedAsyncEventArgs> source = expected.Union(unexpected);

        AggregateException exception = Assert.Throws<AggregateException>(
            () => source.Throw(level: Level.Information));

        Assert.Equal(expected.Select(expected => expected.Cause), exception.InnerExceptions);
    }

    [Fact]
    public void GivenASourceWhenAPredicateIsProvidedThenAnAggregateExceptionIsThrownWithTheExpectedDiagnosticsAsTheCause()
    {
        const string ExpectedMessage = "Test";

        IEnumerable<DiagnosticsEmittedAsyncEventArgs> source = new DiagnosticsEmittedAsyncEventArgs[]
        {
            new(cause: new InvalidOperationException(), level: Level.Critical),
            new(cause: new InvalidOperationException(ExpectedMessage), level: Level.Error),
            new(cause: new InvalidOperationException(), level: Level.Warning),
            new(cause: new InvalidOperationException(), level: Level.Information),
            new(level: Level.Critical),
            new(level: Level.Error),
            new(level: Level.Warning),
            new(level: Level.Information),
            new(cause: new InvalidOperationException(), level: Level.Debug),
            new(cause: new InvalidOperationException(), level: Level.Trace),
        };

        AggregateException exception = Assert.Throws<AggregateException>(
            () => source.Throw((_, cause) => cause.Message == ExpectedMessage));

        Exception expected = Assert.Single(exception.InnerExceptions);
        Assert.Equal(ExpectedMessage, expected.Message);
    }

    [Fact]
    public void GivenASourceAndAMessageWhenALevelIsProvidedThenAnAggregateExceptionIsThrownWithAMatchingMessage()
    {
        const string ExpectedMessage = "Something something Dark Side";

        IEnumerable<DiagnosticsEmittedAsyncEventArgs> source = new DiagnosticsEmittedAsyncEventArgs[]
        {
            new(cause: new InvalidOperationException(), level: Level.Critical),
        };

        AggregateException exception = Assert.Throws<AggregateException>(
            () => source.Throw(level: Level.Trace, message: ExpectedMessage));

        Assert.StartsWith(ExpectedMessage, exception.Message);
    }

    [Fact]
    public void GivenASourceAndAMessageWhenAPredicateIsProvidedThenAnAggregateExceptionIsThrownWithAMatchingMessage()
    {
        const string ExpectedMessage = "Something something Dark Side";

        IEnumerable<DiagnosticsEmittedAsyncEventArgs> source = new DiagnosticsEmittedAsyncEventArgs[]
        {
            new(cause: new InvalidOperationException(), level: Level.Critical),
        };

        AggregateException exception = Assert.Throws<AggregateException>(
            () => source.Throw((_, _) => true, message: ExpectedMessage));

        Assert.StartsWith(ExpectedMessage, exception.Message);
    }

    [Fact]
    public void GivenASourceAndAMessageWhenNoLevelIsProvidedThenAnAggregateExceptionIsThrownWithAMatchingMessage()
    {
        const string ExpectedMessage = "Something something Dark Side";

        IEnumerable<DiagnosticsEmittedAsyncEventArgs> source = new DiagnosticsEmittedAsyncEventArgs[]
        {
            new(cause: new InvalidOperationException(), level: Level.Critical),
        };

        AggregateException exception = Assert.Throws<AggregateException>(
            () => source.Throw(message: ExpectedMessage));

        Assert.StartsWith(ExpectedMessage, exception.Message);
    }
}