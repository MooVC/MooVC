namespace MooVC.MulticastDelegateExtensionsTests
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenPassiveInvokeAsyncIsCalled
    {
        private event AsyncEventHandler? Tested;

        private event Func<Exception, EventArgs, Task>? TypedSender;

        private event AsyncEventHandler<TestEventArgs>? TypedArgs;

        private event EventHandler? Invalid;

        private event Func<object?, EventArgs, object, Task>? IncorrectParameters;

        [Fact]
        public async Task GivenAHandlerThenTheHandlerIsInvokedAsync()
        {
            bool wasInvoked = false;

            Tested += (sender, e) =>
            {
                wasInvoked = true;

                return Task.CompletedTask;
            };

            await Tested.PassiveInvokeAsync(this, AsyncEventArgs.Empty);

            Assert.True(wasInvoked);
        }

        [Fact]
        public async Task GivenMultipleHandlersThenEachHandlerIsInvokedAsync()
        {
            const byte Expected = 3;
            byte actual = 0;

            Task Handler(object? sender, EventArgs e)
            {
                actual++;

                return Task.CompletedTask;
            }

            Tested += Handler;
            Tested += Handler;
            Tested += Handler;

            await Tested.PassiveInvokeAsync(this, AsyncEventArgs.Empty);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public async Task GivenAnExceptionThenNoExceptionIsThrownAsync()
        {
            bool wasInvoked = false;
            var expected = new InvalidOperationException();

            Tested += (sender, e) => throw expected;

            await Tested.PassiveInvokeAsync(
                this,
                AsyncEventArgs.Empty,
                onFailure: actual =>
                {
                    wasInvoked = true;

                    Assert.Equal(expected, actual.InnerException?.InnerException);

                    return Task.CompletedTask;
                });

            Assert.True(wasInvoked);
        }

        [Fact]
        public async Task GivenAnInvalidHandlerThenANotSupportedExceptionIsThrownAsync()
        {
            Invalid += (_, _) => { };

            NotSupportedException exception = await Assert.ThrowsAsync<NotSupportedException>(
                () => Invalid.PassiveInvokeAsync(this, AsyncEventArgs.Empty));
        }

        [Fact]
        public async Task GivenAnInvalidSenderThenANotSupportedExceptionIsThrownAsync()
        {
            TypedSender += (_, _) => Task.CompletedTask;

            NotSupportedException exception = await Assert.ThrowsAsync<NotSupportedException>(
                () => TypedSender.PassiveInvokeAsync(this, AsyncEventArgs.Empty));
        }

        [Fact]
        public async Task GivenAnInvalidArgsThenANotSupportedExceptionIsThrownAsync()
        {
            TypedArgs += (_, _) => Task.CompletedTask;

            NotSupportedException exception = await Assert.ThrowsAsync<NotSupportedException>(
                () => TypedArgs.PassiveInvokeAsync(this, AsyncEventArgs.Empty));
        }

        [Fact]
        public async Task GivenAnInvalidNumberOfParametersThenANotSupportedExceptionIsThrownAsync()
        {
            IncorrectParameters += (_, _, _) => Task.CompletedTask;

            NotSupportedException exception = await Assert.ThrowsAsync<NotSupportedException>(
                () => IncorrectParameters.PassiveInvokeAsync(this, AsyncEventArgs.Empty));
        }
    }
}