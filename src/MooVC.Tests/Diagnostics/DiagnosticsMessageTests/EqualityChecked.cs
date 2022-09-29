namespace MooVC.Diagnostics.DiagnosticsMessageTests;

using System.Linq;
using static System.String;

public abstract class EqualityChecked
{
    protected static string Prepare(string description, int arguments, out DiagnosticsMessage message)
    {
        object[] values = Enumerable
            .Range(1, arguments)
            .Cast<object>()
            .ToArray();

        message = new DiagnosticsMessage(description, values);

        if (arguments > 0)
        {
            return Format(description, values);
        }

        return description;
    }
}