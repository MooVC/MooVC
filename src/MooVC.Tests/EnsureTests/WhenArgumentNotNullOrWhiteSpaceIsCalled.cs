namespace MooVC.EnsureTests
{
    using System;
    using Xunit;

    public sealed class WhenArgumentNotNullOrWhiteSpaceIsCalled
    {
        [Fact]
        public void GivenANonNullValueThenNoExceptionIsThrown()
        {
            Ensure.ArgumentNotNullOrWhiteSpace("Some Value", "Value");
        }

        [Fact]
        public void GivenANonNullValueAndAMessageThenNoExceptionIsThrown()
        {
            Ensure.ArgumentNotNullOrWhiteSpace("Some Value", "Value", "Some message.");
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
                Ensure.ArgumentNotNullOrWhiteSpace(null, nameof(argument), ExpectedMessage));

            Assert.Equal(nameof(argument), exception.ParamName);
            Assert.StartsWith(ExpectedMessage, exception.Message);
        }
    }
}