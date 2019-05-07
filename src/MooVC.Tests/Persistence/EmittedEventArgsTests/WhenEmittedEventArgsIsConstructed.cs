namespace MooVC.Persistence.EmittedEventArgsTests
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public sealed class WhenEmittedEventArgsIsConstructed
    {
        public static readonly IEnumerable<object[]> GivenAnEventThenTheStateIsPropagatedData = new[]
        {
            new object[] { new object() },
            new object[] { new InvalidOperationException() } 
        };

        [Theory]
        [MemberData(nameof(GivenAnEventThenTheStateIsPropagatedData))]
        public void GivenAnEventThenTheStateIsPropagated<T>(T @event)
            where T : class
        {
            var value = new EmittedEventArgs<T>(@event);

            Assert.Equal(@event, value.Event);
        }
    }
}