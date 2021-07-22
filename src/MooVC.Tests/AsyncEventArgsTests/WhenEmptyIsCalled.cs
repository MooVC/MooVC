namespace MooVC.AsyncEventArgsTests
{
    using System.Threading;
    using Xunit;

    public sealed class WhenEmptyIsCalled
    {
        [Fact]
        public void GivenACancellationTokenThenAnArgumentWithThatTokenIsReturned()
        {
            var cancellationToken = new CancellationToken(false);
            var args = AsyncEventArgs.Empty(cancellationToken: cancellationToken);

            Assert.Equal(cancellationToken, args.CancellationToken);
        }

        [Fact]
        public void GivenNoCancellationTokenThenAnArgumentWithTheNoneTokenIsReturned()
        {
            var args = AsyncEventArgs.Empty();

            Assert.Equal(CancellationToken.None, args.CancellationToken);
        }
    }
}