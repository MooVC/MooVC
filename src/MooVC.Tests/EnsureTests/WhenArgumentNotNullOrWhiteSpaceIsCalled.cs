namespace MooVC.EnsureTests
{
    using System;
    using Xunit;

    public sealed class WhenArgumentNotNullOrWhiteSpaceIsCalled
    {
        [Fact]
        public void GivenANonNullValueThenNoExceptionIsThrown()
        {
            const string Argument = "Some Value";

            string result = Ensure.ArgumentNotNullOrWhiteSpace(
                Argument,
                "Value");

            Assert.Same(Argument, result);
        }

        [Fact]
        public void GivenANonNullValueAndAMessageThenNoExceptionIsThrown()
        {
            const string Argument = "Some Value";

            string result = Ensure.ArgumentNotNullOrWhiteSpace(
                Argument,
                "Value",
                "Some message.");

            Assert.Same(Argument, result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void GivenANullArgumentThenAnArgumentNullExceptionIsThrown(string argument)
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                Ensure.ArgumentNotNullOrWhiteSpace(argument, nameof(argument)));

            Assert.Equal(nameof(argument), exception.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void GivenANullArgumentThenAnArgumentNullExceptionIsThrownWithTheMessageAttached(string argument)
        {
            const string ExpectedMessage = "Expected is null.";

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                Ensure.ArgumentNotNullOrWhiteSpace(argument, nameof(argument), ExpectedMessage));

            Assert.Equal(nameof(argument), exception.ParamName);
            Assert.StartsWith(ExpectedMessage, exception.Message);
        }
    }
}