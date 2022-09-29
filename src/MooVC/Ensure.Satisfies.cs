namespace MooVC;

using System;
using System.Runtime.CompilerServices;

public static partial class Ensure
{
    public static T Satisfies<T>(
        T? argument,
        Func<T, bool> predicate,
        [CallerArgumentExpression("argument")] string? argumentName = default,
        T? @default = default,
        string? message = default)
        where T : struct
    {
        T actual = IsNotNull(argument, argumentName: argumentName, @default: @default, message: message);

        if (@default.HasValue && actual.Equals(@default.Value))
        {
            return actual;
        }

        if (!predicate(actual))
        {
            if (@default.HasValue)
            {
                return @default.Value;
            }

            throw new ArgumentException(message, argumentName);
        }

        return actual;
    }

    public static T Satisfies<T>(
        T? argument,
        Func<T, bool> predicate,
        [CallerArgumentExpression("argument")] string? argumentName = default,
        T? @default = default,
        string? message = default)
        where T : class
    {
        T actual = IsNotNull(argument, argumentName: argumentName, @default: @default, message: message);

        if (actual == @default)
        {
            return @default;
        }

        if (!predicate(actual))
        {
            if (@default is null)
            {
                throw new ArgumentException(message, argumentName);
            }

            return @default;
        }

        return actual;
    }
}