namespace MooVC.Diagnostics.DiagnosticsMessageTests;

using MooVC.Serialization;
using Xunit;

public sealed class WhenDiagnosticsMessageIsSerialized
{
    [Fact]
    public void GivenAnInstanceThenAllPropertiesAreSerialized()
    {
        var original = new DiagnosticsMessage("Test", 1, 2, 3, 4);
        DiagnosticsMessage deserialized = original.Clone();

        Assert.NotSame(original, deserialized);
        Assert.Equal(original, deserialized);
    }
}