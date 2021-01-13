namespace MooVC.Diagnostics.DiagnosticsEmittedEventArgsTests
{
    using System;
    using System.Linq;
    using Xunit;
    using static System.String;

    public sealed class WhenDiagnosticsEmittedEventArgsIsConstructed
    {
        [Fact]
        public void GivenACauseWhenNoMessageIsProvidedThenTheMessageDefaultsToTheMessageWithinTheCause()
        {
            const string ExpectedMessage = "Something something Dark Side";

            var cause = new Exception(ExpectedMessage);

            var value = new DiagnosticsEmittedEventArgs
            {
                Cause = cause,
            };

            Assert.Equal(cause, value.Cause);
            Assert.Equal(ExpectedMessage, value.Message);
        }

        [Fact]
        public void GivenALevelOutsideOfRangeThenTheMaxLevelIsApplied()
        {
            Level max = Enum.GetValues<Level>().Max();
            byte raw = (byte)max;
            var level = (Level)(raw + 1);

            var value = new DiagnosticsEmittedEventArgs
            {
                Level = level,
            };

            Assert.Equal(max, value.Level);
        }

        [Theory]
        [InlineData(Level.Trace)]
        [InlineData(Level.Information)]
        [InlineData(Level.Critical)]
        public void GivenALevelWithinRangeThenTheLevelIsApplied(Level level)
        {
            var value = new DiagnosticsEmittedEventArgs
            {
                Level = level,
            };

            Assert.Equal(level, value.Level);
        }

        [Fact]
        public void GivenAMessageThenTheMessageIsApplied()
        {
            const string ExpectedMessage = "Something something Dark Side";

            var value = new DiagnosticsEmittedEventArgs
            {
                Message = ExpectedMessage,
            };

            Assert.Equal(ExpectedMessage, value.Message);
        }

        [Theory]
        [InlineData(default)]
        [InlineData("")]
        [InlineData(" ")]
        public void GivenAnEmptyMessageWhenACauseIsProvidedTheMessageDefaultsToTheMessageWithinTheCause(string? message)
        {
            const string ExpectedMessage = "Something something Dark Side";

            var cause = new Exception(ExpectedMessage);

            var value = new DiagnosticsEmittedEventArgs
            {
                Cause = cause,
                Message = message,
            };

            Assert.Equal(ExpectedMessage, value.Message);
        }

        [Theory]
        [InlineData(default)]
        [InlineData("")]
        [InlineData(" ")]
        public void GivenAnEmptyMessageWhenNoCauseIsProvidedThenAnEmptyMessageIsApplied(string? message)
        {
            var value = new DiagnosticsEmittedEventArgs
            {
                Message = message,
            };

            Assert.Equal(Empty, value.Message);
        }
    }
}