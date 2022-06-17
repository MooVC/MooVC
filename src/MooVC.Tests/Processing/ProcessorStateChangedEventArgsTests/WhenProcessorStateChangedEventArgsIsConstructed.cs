namespace MooVC.Processing.ProcessorStateChangedEventArgsTests;

using Xunit;

public sealed class WhenProcessorStateChangedEventArgsIsConstructed
{
    [Theory]
    [InlineData(ProcessorState.Started)]
    [InlineData(ProcessorState.Starting)]
    [InlineData(ProcessorState.Stopped)]
    [InlineData(ProcessorState.Stopping)]
    [InlineData(ProcessorState.Unknown)]
    public void GivenAStateThenTheStatePropertyIsSet(ProcessorState expected)
    {
        var argument = new ProcessorStateChangedAsyncEventArgs(expected);

        Assert.Equal(expected, argument.State);
    }
}