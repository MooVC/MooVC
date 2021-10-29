namespace MooVC.EnsureTests
{
    using System;
    using Xunit;
    using static System.String;
    using static MooVC.Ensure;

    public sealed class WhenArgumentIsAcceptableIsCalled
    {
        [Fact]
        public void GivenAnInvalidArgumentWhenAMessageIsProvidedThenAnArgumentExceptionIsThrown()
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
                ArgumentIsAcceptable(argument, ExpectedArgumentName, Predicate, ExpectedMessage));

            Assert.Equal(ExpectedArgumentName, exception.ParamName);
            Assert.StartsWith(ExpectedMessage, exception.Message);
            Assert.Equal(ExpectedInvocationCount, invocationCount);
        }

        [Fact]
        public void GivenAnInvalidArgumentWhenNoMessageIsProvidedThenAnArgumentExceptionIsThrown()
        {
            const int ExpectedInvocationCount = 1;
            const string ExpectedArgumentName = "expected";

            string argument = "A invalid value.";
            int invocationCount = 0;

            bool Predicate(string value)
            {
                invocationCount++;

                Assert.Equal(argument, value);

                return false;
            }

            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                ArgumentIsAcceptable(argument, ExpectedArgumentName, Predicate));

            Assert.Equal(ExpectedArgumentName, exception.ParamName);
            Assert.Equal(ExpectedInvocationCount, invocationCount);
        }

        [Fact]
        public void GivenANullArgumentWhenAMessageIsProvidedThenAnArgumentNullExceptionIsThrownWithoutInvokingThePredicate()
        {
            const int ExpectedInvocationCount = 0;
            const string ExpectedArgumentName = "expected";
            const string ExpectedMessage = "Expected is null.";

            string? argument = default;
            int invocationCount = 0;

            bool Predicate<T>(T value)
            {
                invocationCount++;

                return false;
            }

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                ArgumentIsAcceptable(argument, ExpectedArgumentName, Predicate, ExpectedMessage));

            Assert.Equal(ExpectedArgumentName, exception.ParamName);
            Assert.StartsWith(ExpectedMessage, exception.Message);
            Assert.Equal(ExpectedInvocationCount, invocationCount);
        }

        [Fact]
        public void GivenANullArgumentWhenNoMessageIsProvidedThenAnArgumentNullExceptionIsThrownWithoutInvokingThePredicate()
        {
            const int ExpectedInvocationCount = 0;
            const string ExpectedArgumentName = "expected";

            string? argument = default;
            int invocationCount = 0;

            bool Predicate<T>(T value)
            {
                invocationCount++;

                return false;
            }

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                ArgumentIsAcceptable(argument, ExpectedArgumentName, Predicate));

            Assert.Equal(ExpectedArgumentName, exception.ParamName);
            Assert.Equal(ExpectedInvocationCount, invocationCount);
        }

        [Fact]
        public void GivenAValidArgumentWhenAMessageIsProvidedThenNoExceptionIsThrown()
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

            string result = ArgumentIsAcceptable(argument, Empty, Predicate, Empty);

            Assert.Same(argument, result);
            Assert.Equal(ExpectedInvocationCount, invocationCount);
        }

        [Fact]
        public void GivenAValidArgumentWhenNoMessageIsProvidedThenNoExceptionIsThrown()
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

            string result = ArgumentIsAcceptable(argument, Empty, Predicate);

            Assert.Same(argument, result);
            Assert.Equal(ExpectedInvocationCount, invocationCount);
        }
    }
}