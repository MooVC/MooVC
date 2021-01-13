namespace MooVC.Processing.StartOperationInvalidExceptionTests
{
    using MooVC.Serialization;
    using Xunit;

    public sealed class WhenStartOperationInvalidExceptionIsSerialized
    {
        [Theory]
        [InlineData(ProcessorState.Started)]
        [InlineData(ProcessorState.Starting)]
        [InlineData(ProcessorState.Stopped)]
        [InlineData(ProcessorState.Stopping)]
        [InlineData(ProcessorState.Unknown)]
        public void GivenAnInstanceThenAllPropertiesAreSerialized(ProcessorState state)
        {
            var original = new StartOperationInvalidException(state);
            StartOperationInvalidException deserialized = original.Clone();

            Assert.Equal(original.State, deserialized.State);
            Assert.NotSame(original, deserialized);
        }
    }
}