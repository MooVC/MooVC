namespace MooVC.Logging.ExceptionEventArgsTests
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public sealed class WhenExceptionEventArgsIsConstructed
    {
        public static readonly IEnumerable<object[]> GivenAMessageAndAnExceptionThenThePropertiesMatchData = new[]
        {
            new object[] { "Test Message 1", null },
            new object[] { "Test Message 2", new ArgumentException() }
        };

        public static readonly IEnumerable<object[]> GivenAnExceptionThenTheMessageMatchesTheExceptionMessageData = new[]
        {
            new object[] { new InvalidOperationException("Test Message 1") },
            new object[] { new ArgumentException("Test Message 2") }
        };

        [Theory]
        [MemberData(nameof(GivenAMessageAndAnExceptionThenThePropertiesMatchData))]
        public void GivenAMessageAndAnExceptionThenThePropertiesAreSetToMatch(string message, Exception exception)
        {
            var value = new ExceptionEventArgs(message, exception);

            Assert.Equal(message, value.Message);
            Assert.Equal(exception, value.Exception);
        }

        [Theory]
        [MemberData(nameof(GivenAnExceptionThenTheMessageMatchesTheExceptionMessageData))]
        public void GivenAnExceptionThenTheMessageMatchesTheExceptionMessage(Exception exception)
        {
            var value = new ExceptionEventArgs(exception);

            Assert.Equal(exception.Message, value.Message);
            Assert.Equal(exception, value.Exception);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void GivenABlanklMessageThenAnArgumentExceptionIsThrown(string message)
        {
            _ = Assert.Throws<ArgumentException>(() => new ExceptionEventArgs(message));
        }

        [Fact]
        public void GivenANullExceptionThenAnArgumentNullExceptionIsThrown()
        {
            _ = Assert.Throws<ArgumentNullException>(() => new ExceptionEventArgs(null));
        }
        
        [Fact]
        public void GivenANullMessageThenAnArgumentNullExceptionIsThrown()
        {
            _ = Assert.Throws<ArgumentNullException>(() => new ExceptionEventArgs(null, null));
        }
    }
}