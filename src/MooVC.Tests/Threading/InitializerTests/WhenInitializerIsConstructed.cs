namespace MooVC.Threading.InitializerTests
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenInitializerIsConstructed
    {
        [Fact]
        public void GivenAnInitiazerThenAnInstanceIsReturned()
        {
            static Task<object> Initializer(CancellationToken cancellationToken)
            {
                return Task.FromResult(new object());
            }

            _ = new Initializer<object>(Initializer);
        }

        [Fact]
        public void GivenAnNullInitiazerThenAnArgumentExceptionIsThrown()
        {
            Func<CancellationToken, Task<object>>? initializer = default;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => new Initializer<object>(initializer!));

            Assert.Equal(nameof(initializer), exception.ParamName);
        }
    }
}