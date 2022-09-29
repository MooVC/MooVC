namespace MooVC;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using MooVC.Collections.Generic;
using MooVC.Linq;

public static partial class Ensure
{
    public static Guid IsNotEmpty(
        Guid? argument,
        [CallerArgumentExpression("argument")] string? argumentName = default,
        Guid? @default = default,
        string? message = default)
    {
        return Satisfies(argument, value => value != Guid.Empty, argumentName: argumentName, @default: @default, message: message);
    }

    public static TimeSpan IsNotEmpty(
        TimeSpan? argument,
        [CallerArgumentExpression("argument")] string? argumentName = default,
        TimeSpan? @default = default,
        string? message = default)
    {
        return Satisfies(
            argument,
            value => value > TimeSpan.Zero,
            argumentName: argumentName,
            @default: @default,
            message: message);
    }

    public static T[] IsNotEmpty<T>(
        IEnumerable<T>? argument,
        [CallerArgumentExpression("argument")] string? argumentName = default,
        IEnumerable<T>? @default = default,
        string? message = default,
        Func<T, bool>? predicate = default)
    {
        _ = IsNotNull(argument, argumentName: argumentName, @default: @default, message: message);

        predicate ??= element => element is { };

        T[] snapshot = argument.Snapshot(predicate: predicate);

        if (snapshot.IsEmpty())
        {
            if (@default is null)
            {
                throw new ArgumentException(message, argumentName);
            }

            return @default.ToArray();
        }

        return snapshot;
    }
}