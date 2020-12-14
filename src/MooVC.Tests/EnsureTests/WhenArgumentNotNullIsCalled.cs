namespace MooVC.EnsureTests
{
    using System;
    using Xunit;
    using static MooVC.Ensure;

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
        public void GivenANonNullValueThenNoExceptionIsThrown(object argument)
        {
            ArgumentNotNull(argument, nameof(argument));
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
        public void GivenANonNullValueAndAMessageThenNoExceptionIsThrown(object argument)
        {
            ArgumentNotNull(argument, nameof(argument), "Some message.");
        }

        [Fact]
        public void GivenANullArgumentThenAnArgumentNullExceptionIsThrown()
        {
            const string ExpectedArgumentName = "expected";

            string? value = default;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                ArgumentNotNull(value, ExpectedArgumentName));

            Assert.Equal(ExpectedArgumentName, exception.ParamName);
        }

        [Fact]
        public void GivenANullArgumentThenAnArgumentNullExceptionIsThrownWithTheMessageAttached()
        {
            const string ExpectedArgumentName = "expected";
            const string ExpectedMessage = "Expected is null.";

            string? value = default;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                ArgumentNotNull(value, ExpectedArgumentName, ExpectedMessage));

            Assert.Equal(ExpectedArgumentName, exception.ParamName);
            Assert.StartsWith(ExpectedMessage, exception.Message);
        }
    }
}