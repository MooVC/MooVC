namespace MooVC;

using System;
using System.Runtime.CompilerServices;

public static partial class Ensure
{
    public static T InRange<T>(
        T argument,
        [CallerArgumentExpression("argument")] string? argumentName = default,
        T? @default = default,
        T? end = default,
        string? message = default,
        T? start = default)
        where T : struct, IComparable<T>
    {
        if ((start.HasValue && argument.CompareTo(start.Value) < 0) || (end.HasValue && argument.CompareTo(end.Value) > 0))
        {
            if (@default.HasValue)
            {
                return @default.Value;
            }

            throw new ArgumentOutOfRangeException(argumentName, argument, message);
        }

        return argument;
    }

    public static T InRange<T>(
        T? argument,
        [CallerArgumentExpression("argument")] string? argumentName = default,
        T? @default = default,
        string? message = default,
        T? end = default,
        T? start = default)
       where T : struct, IComparable<T>
    {
        T actual = IsNotNull(argument, argumentName: argumentName, @default: @default, message: message);

        if (@default.HasValue && actual.Equals(@default.Value))
        {
            return actual;
        }

        return InRange(actual, argumentName: argumentName, @default: @default, end: end, message: message, start: start);
    }
}