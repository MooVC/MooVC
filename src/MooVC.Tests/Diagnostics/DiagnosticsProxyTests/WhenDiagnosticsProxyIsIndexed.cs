namespace MooVC.Diagnostics.DiagnosticsProxyTests;

using System.Collections.Generic;
using Xunit;

public sealed class WhenDiagnosticsProxyIsIndexed
{
    [Fact]
    public void GivenAnExistingLevelThenTheLevelIsReturned()
    {
        var defaults = new Dictionary<Impact, Level>
        {
            { Impact.Recoverable, Level.Critical },
            { Impact.Unrecoverable, Level.Error },
            { Impact.Negligible, Level.Warning },
            { Impact.None, Level.Information },
        };

        var diagnostics = new DiagnosticsProxy(defaults: defaults);

        foreach (Impact impact in defaults.Keys)
        {
            Level actual = diagnostics[impact];
            Level expected = defaults[impact];

            Assert.Equal(expected, actual);
        }
    }

    [Fact]
    public void GivenANonExistingLevelThenTheLevelIsReturned()
    {
        var diagnostics = new DiagnosticsProxy();
        Level level = diagnostics[(Impact)255];

        Assert.Equal(Level.Error, level);
    }
}