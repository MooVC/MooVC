namespace MooVC.EnsureTests
{
    using System;
    using Xunit;

    public sealed class WhenArgumentNotNullIsCalled
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        [InlineData(true)]
        [InlineData(false)]
        [InlineData("")]
        [InlineData(" ")]
        public void GivenANonNullValueThenNotExceptionIsThrown(object argument)
        {
            Ensure.ArgumentNotNull(argument, string.Empty);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        [InlineData(true)]
        [InlineData(false)]
        [InlineData("")]
        [InlineData(" ")]
        public void GivenANonNullValueAndAMessageThenNotExceptionIsThrown(object argument)
        {
            Ensure.ArgumentNotNull(argument, string.Empty, "Some message.");
        }

        [Fact]
        public void GivenANullArgumentThenAnArgumentNullExceptionIsThrown()
        {
            const string ExpectedArgumentName = "expected";

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                Ensure.ArgumentNotNull(null, ExpectedArgumentName));

            Assert.Equal(ExpectedArgumentName, exception.ParamName);
        }

        [Fact]
        public void GivenANullArgumentThenAnArgumentNullExceptionIsThrownWithTheMessageAttached()
        {
            const string ExpectedArgumentName = "expected";
            const string ExpectedMessage = "Expected is null.";

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                Ensure.ArgumentNotNull(null, ExpectedArgumentName, ExpectedMessage));

            Assert.Equal(ExpectedArgumentName, exception.ParamName);
            Assert.StartsWith(ExpectedMessage, exception.Message);
        }
    }
}