namespace MooVC;

using System;
using System.Runtime.CompilerServices;

public static partial class Ensure
{
    public static T IsNotNull<T>(
        T? argument,
        [CallerArgumentExpression("argument")] string? argumentName = default,
        T? @default = default,
        string? message = default)
        where T : struct
    {
        if (!argument.HasValue)
        {
            if (@default.HasValue)
            {
                return @default.Value;
            }

            throw new ArgumentNullException(argumentName, message);
        }

        return argument.Value;
    }

    public static T IsNotNull<T>(
        T? argument,
        [CallerArgumentExpression("argument")] string? argumentName = default,
        T? @default = default,
        string? message = default)
        where T : class
    {
        if (argument is null)
        {
            if (@default is null)
            {
                throw new ArgumentNullException(argumentName, message);
            }

            return @default;
        }

        return argument;
    }
}