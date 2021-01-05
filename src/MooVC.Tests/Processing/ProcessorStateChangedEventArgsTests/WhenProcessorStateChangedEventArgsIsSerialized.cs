namespace MooVC.Processing.ProcessorStateChangedEventArgsTests
{
    using MooVC.Serialization;
    using Xunit;

    public sealed class WhenProcessorStateChangedEventArgsIsSerialized
    {
        [Theory]
        [InlineData(ProcessorState.Started)]
        [InlineData(ProcessorState.Starting)]
        [InlineData(ProcessorState.Stopped)]
        [InlineData(ProcessorState.Stopping)]
        [InlineData(ProcessorState.Unknown)]
        public void GivenAnInstanceThenAllPropertiesAreSerialized(ProcessorState expected)
        {
            var original = new ProcessorStateChangedEventArgs(expected);
            ProcessorStateChangedEventArgs deserialized = original.Clone();

            Assert.Equal(original.State, deserialized.State);
            Assert.NotSame(original, deserialized);
        }
    }
}