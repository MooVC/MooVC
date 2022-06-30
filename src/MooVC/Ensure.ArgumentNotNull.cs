namespace MooVC;

using System;
using System.Diagnostics.CodeAnalysis;

public static partial class Ensure
{
    public static T ArgumentNotNull<T>([NotNull] T? argument, string argumentName)
       where T : struct
    {
        if (!argument.HasValue)
        {
            throw new ArgumentNullException(argumentName);
        }

        return argument.Value;
    }

    public static T ArgumentNotNull<T>([NotNull] T? argument, string argumentName)
        where T : class
    {
        if (argument is null)
        {
            throw new ArgumentNullException(argumentName);
        }

        return argument;
    }

    public static T ArgumentNotNull<T>([NotNull] T? argument, string argumentName, string message)
        where T : struct
    {
        if (!argument.HasValue)
        {
            throw new ArgumentNullException(argumentName, message);
        }

        return argument.Value;
    }

    public static T ArgumentNotNull<T>([NotNull] T? argument, string argumentName, string message)
        where T : class
    {
        if (argument is null)
        {
            throw new ArgumentNullException(argumentName, message);
        }

        return argument;
    }
}