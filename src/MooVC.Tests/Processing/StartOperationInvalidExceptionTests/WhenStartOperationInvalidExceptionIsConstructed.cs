namespace MooVC.Processing.StartOperationInvalidExceptionTests
{
    using Xunit;

    public sealed class WhenStartOperationInvalidExceptionIsConstructed
    {
        [Theory]
        [InlineData(ProcessorState.Started)]
        [InlineData(ProcessorState.Starting)]
        [InlineData(ProcessorState.Stopped)]
        [InlineData(ProcessorState.Stopping)]
        [InlineData(ProcessorState.Unknown)]
        public void GivenAStateThenTheStateIsPropagated(ProcessorState state)
        {
            var exception = new StartOperationInvalidException(state);

            Assert.Equal(state, exception.State);
        }
    }
}