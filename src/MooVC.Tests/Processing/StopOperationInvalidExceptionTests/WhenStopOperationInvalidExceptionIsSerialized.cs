namespace MooVC.Processing.StopOperationInvalidExceptionTests;

using MooVC.Serialization;
using Xunit;

public sealed class WhenStopOperationInvalidExceptionIsSerialized
{
    [Theory]
    [InlineData(ProcessorState.Started)]
    [InlineData(ProcessorState.Starting)]
    [InlineData(ProcessorState.Stopped)]
    [InlineData(ProcessorState.Stopping)]
    [InlineData(ProcessorState.Unknown)]
    public void GivenAnInstanceThenAllPropertiesAreSerialized(ProcessorState state)
    {
        var original = new StopOperationInvalidException(state);
        StopOperationInvalidException deserialized = original.Clone();

        Assert.Equal(original.State, deserialized.State);
        Assert.NotSame(original, deserialized);
    }
}