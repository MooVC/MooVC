namespace MooVC.Processing.StopOperationInvalidExceptionTests;

using Xunit;

public sealed class WhenStopOperationInvalidExceptionIsConstructed
{
    [Theory]
    [InlineData(ProcessorState.Started)]
    [InlineData(ProcessorState.Starting)]
    [InlineData(ProcessorState.Stopped)]
    [InlineData(ProcessorState.Stopping)]
    [InlineData(ProcessorState.Unknown)]
    public void GivenAStateThenTheStateIsPropagated(ProcessorState state)
    {
        var exception = new StopOperationInvalidException(state);

        Assert.Equal(state, exception.State);
    }
}