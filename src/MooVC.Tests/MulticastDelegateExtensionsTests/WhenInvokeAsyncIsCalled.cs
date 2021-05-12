namespace MooVC.MulticastDelegateExtensionsTests
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenInvokeAsyncIsCalled
    {
        private event AsyncEventHandler? Tested;

        private event Func<Exception, EventArgs, Task>? TypedSender;

        private event AsyncEventHandler<MyEventArgs>? TypedArgs;

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

            await Tested.InvokeAsync(this, EventArgs.Empty);

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

            await Tested.InvokeAsync(this, EventArgs.Empty);

            Assert.Equal(Expected, actual);
        }

        [Fact]
        public async Task GivenAnExceptionThenTheExceptionIsThrownAsync()
        {
            var expected = new InvalidOperationException();

            Tested += (sender, e) => throw expected;

            TargetInvocationException exception = await Assert.ThrowsAsync<TargetInvocationException>(
                () => Tested.InvokeAsync(this, EventArgs.Empty));

            Assert.NotNull(exception);
            Assert.Equal(expected, exception.InnerException);
        }

        [Fact]
        public async Task GivenAnInvalidHandlerThenANotSupportedExceptionIsThrownAsync()
        {
            Invalid += (_, _) => { };

            NotSupportedException exception = await Assert.ThrowsAsync<NotSupportedException>(
                () => Invalid.InvokeAsync(this, EventArgs.Empty));
        }

        [Fact]
        public async Task GivenAnInvalidSenderThenANotSupportedExceptionIsThrownAsync()
        {
            TypedSender += (_, _) => Task.CompletedTask;

            NotSupportedException exception = await Assert.ThrowsAsync<NotSupportedException>(
                () => TypedSender.InvokeAsync(this, EventArgs.Empty));
        }

        [Fact]
        public async Task GivenAnInvalidArgsThenANotSupportedExceptionIsThrownAsync()
        {
            TypedArgs += (_, _) => Task.CompletedTask;

            NotSupportedException exception = await Assert.ThrowsAsync<NotSupportedException>(
                () => TypedArgs.InvokeAsync(this, EventArgs.Empty));
        }

        [Fact]
        public async Task GivenAnInvalidNumberOfParametersThenANotSupportedExceptionIsThrownAsync()
        {
            IncorrectParameters += (_, _, _) => Task.CompletedTask;

            NotSupportedException exception = await Assert.ThrowsAsync<NotSupportedException>(
                () => IncorrectParameters.InvokeAsync(this, EventArgs.Empty));
        }

        private class MyEventArgs
            : EventArgs
        {
        }
    }
}