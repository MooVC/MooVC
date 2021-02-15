namespace MooVC.Threading.InitializerTests
{
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenInitializeAsyncIsCalled
    {
        [Fact]
        public async Task GivenAnInitializerThenTheInitializerIsOnlyCalledOnceAndTheInstanceIsAlwaysTheSameAsync()
        {
            const int ExpectedInvocations = 1;
            int invocations = 0;

            Task<object> Initializer()
            {
                invocations++;

                return Task.FromResult(new object());
            }

            var initializer = new Initializer<object>(Initializer);

            object? first = await initializer.InitializeAsync();
            object? second = await initializer.InitializeAsync();
            object? third = await initializer.InitializeAsync();

            Assert.Equal(ExpectedInvocations, invocations);
            Assert.NotNull(first);
            Assert.Equal(first, second);
            Assert.Equal(first, third);
            Assert.Equal(second, third);
        }

        [Fact]
        public async Task GivenAnExceptionThenTheExceptionIsThrownAsync()
        {
            static Task<object> Initializer()
            {
                throw new NotImplementedException();
            }

            var initializer = new Initializer<object>(Initializer);

            _ = await Assert.ThrowsAsync<NotImplementedException>(() => initializer.InitializeAsync());
        }
    }
}