namespace MooVC.EnsureTests
{
    using System;
    using Xunit;

    public sealed class WhenArgumentIsAcceptableIsCalled
    {
        [Fact]
        public void GivenANullArgumentThenAnArgumentNullExceptionIsThrownWithoutInvokingThePredicate()
        {
            const int ExpectedInvocationCount = 0;
            const string ExpectedArgumentName = "expected";
            const string ExpectedMessage = "Expected is null.";

            int invocationCount = 0;

            bool Predicate<T>(T value)
            {
                invocationCount++;

                return false;
            }

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => 
                Ensure.ArgumentIsAcceptable<string>(null, ExpectedArgumentName, Predicate, ExpectedMessage));

            Assert.Equal(ExpectedArgumentName, exception.ParamName);
            Assert.StartsWith(ExpectedMessage, exception.Message);
            Assert.Equal(ExpectedInvocationCount, invocationCount);
        }

        [Fact]
        public void GivenAnInvalidArgumentThenAnArgumentExceptionIsThrown()
        {
            const int ExpectedInvocationCount = 1;
            const string ExpectedArgumentName = "expected";
            const string ExpectedMessage = "Expected is null.";

            string argument = "A invalid value.";
            int invocationCount = 0;

            bool Predicate(string value)
            {
                invocationCount++;

                Assert.Equal(argument, value);

                return false;
            }

            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                Ensure.ArgumentIsAcceptable(argument, ExpectedArgumentName, Predicate, ExpectedMessage));

            Assert.Equal(ExpectedArgumentName, exception.ParamName);
            Assert.StartsWith(ExpectedMessage, exception.Message);
            Assert.Equal(ExpectedInvocationCount, invocationCount);
        }

        [Fact]
        public void GivenAValidArgumentThenNoExceptionIsThrown()
        {
            const int ExpectedInvocationCount = 1;

            string argument = "A valid value.";
            int invocationCount = 0;

            bool Predicate(string value)
            {
                invocationCount++;

                Assert.Equal(argument, value);

                return true;
            }

            Ensure.ArgumentIsAcceptable(argument, string.Empty, Predicate, string.Empty);

            Assert.Equal(ExpectedInvocationCount, invocationCount);
        }
    }
}