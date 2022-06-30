namespace MooVC;

using System;
using System.Diagnostics.CodeAnalysis;
using static System.String;

public static partial class Ensure
{
    public static string ArgumentNotNullOrWhiteSpace([NotNull] string? argument, string argumentName)
    {
        if (IsNullOrWhiteSpace(argument))
        {
            throw new ArgumentNullException(argumentName);
        }

        return argument;
    }

    public static string ArgumentNotNullOrWhiteSpace([NotNull] string? argument, string argumentName, string message)
    {
        if (IsNullOrWhiteSpace(argument))
        {
            throw new ArgumentNullException(argumentName, message);
        }

        return argument;
    }
}