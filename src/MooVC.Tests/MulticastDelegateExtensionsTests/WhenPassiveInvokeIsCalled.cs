namespace MooVC.MulticastDelegateExtensionsTests
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenPassiveInvokeIsCalled
    {
        private event EventHandler? Tested;

        private event Action<Exception, EventArgs>? TypedSender;

        private event EventHandler<TestEventArgs>? TypedArgs;

        private event AsyncEventHandler? Invalid;

        private event Action<object?, EventArgs, object>? IncorrectParameters;

        [Fact]
        public void GivenAHandlerThenTheHandlerIsInvoked()
        {
            bool wasInvoked = false;

            Tested += (sender, e) => wasInvoked = true;

            Tested.PassiveInvoke(this, EventArgs.Empty);

            Assert.True(wasInvoked);
        }

        [Fact]
        public void GivenMultipleHandlersThenEachHandlerIsInvoked()
        {
            const byte Expected = 3;
            byte actual = 0;

            void Handler(object? sender, EventArgs e)
            {
                actual++;
            }

            Tested += Handler;
            Tested += Handler;
            Tested += Handler;

            Tested.PassiveInvoke(this, EventArgs.Empty);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public void GivenAnExceptionThenTheExceptionIsPassedthrough()
        {
            bool wasInvoked = false;
            var expected = new InvalidOperationException();

            Tested += (sender, e) => throw expected;

            Tested.PassiveInvoke(
                this,
                EventArgs.Empty,
                onFailure: actual =>
                {
                    wasInvoked = true;

                    Assert.Equal(expected, actual.InnerException?.InnerException);
                });

            Assert.True(wasInvoked);
        }

        [Fact]
        public void GivenAnInvalidHandlerThenANotSupportedExceptionIsThrown()
        {
            Invalid += (_, _) => Task.CompletedTask;

            NotSupportedException exception = Assert.Throws<NotSupportedException>(
                () => Invalid.PassiveInvoke(this, EventArgs.Empty));
        }

        [Fact]
        public void GivenAnInvalidSenderThenANotSupportedExceptionIsThrown()
        {
            TypedSender += (_, _) => { };

            NotSupportedException exception = Assert.Throws<NotSupportedException>(
                () => TypedSender.PassiveInvoke(this, EventArgs.Empty));
        }

        [Fact]
        public void GivenAnInvalidArgsThenANotSupportedExceptionIsThrown()
        {
            TypedArgs += (_, _) => { };

            NotSupportedException exception = Assert.Throws<NotSupportedException>(
                () => TypedArgs.PassiveInvoke(this, EventArgs.Empty));
        }

        [Fact]
        public void GivenAnInvalidNumberOfParametersThenANotSupportedExceptionIsThrown()
        {
            IncorrectParameters += (_, _, _) => { };

            NotSupportedException exception = Assert.Throws<NotSupportedException>(
                () => IncorrectParameters.PassiveInvoke(this, EventArgs.Empty));
        }
    }
}