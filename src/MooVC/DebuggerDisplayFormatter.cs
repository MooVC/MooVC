namespace MooVC;

using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

public static class DebuggerDisplayFormatter
{
    private const int MaximumStringLength = 16;

    [SuppressMessage("Style", "IDE0057:Use range operator", Justification = "Range operator is not available.")]
    public static object Format(string? value)
    {
        if (value is null)
        {
            return "null";
        }

        return value.Length > MaximumStringLength
            ? value.Substring(0, MaximumStringLength)
            : value;
    }

    public static object Format(ICollection value)
    {
        return value?.Count ?? 0;
    }

    public static object Format<T>(ICollection<T> value)
    {
        return value?.Count ?? 0;
    }

    public static object Format<T>(in ImmutableArray<T> value)
    {
        return value.IsDefaultOrEmpty ? 0 : value.Length;
    }

    public static object Format<T>(IReadOnlyCollection<T> value)
    {
        return value?.Count ?? 0;
    }

    public static object Format<T>(T? value)
    {
        return Format(value?.ToString());
    }
}