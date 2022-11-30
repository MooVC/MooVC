namespace MooVC;

using System;
using System.Runtime.CompilerServices;

public static partial class Ensure
{
    public static T IsDefined<T>(
        T? argument,
        [CallerArgumentExpression("argument")] string? argumentName = default,
        T? @default = default,
        string? message = default)
        where T : struct, Enum
    {
        T actual = IsNotNull(argument, argumentName: argumentName, @default: @default, message: message);

        if (@default.HasValue && actual.Equals(@default.Value))
        {
            return actual;
        }

        return IsDefined(actual, argumentName: argumentName, @default: @default, message: message);
    }

    public static T IsDefined<T>(
        T argument,
        [CallerArgumentExpression("argument")] string? argumentName = default,
        T? @default = default,
        string? message = default)
        where T : struct, Enum
    {
        Type type = typeof(T);

        if (type.IsEnum)
        {
            if (Enum.IsDefined(type, argument))
            {
                return argument;
            }

            if (@default.HasValue)
            {
                return @default.Value;
            }
        }

        throw new ArgumentException(message, argumentName);
    }
}