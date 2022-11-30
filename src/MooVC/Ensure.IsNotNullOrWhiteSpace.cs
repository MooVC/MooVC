namespace MooVC;

using System;
using System.Runtime.CompilerServices;
using static System.String;

public static partial class Ensure
{
    public static string IsNotNullOrWhiteSpace(
        string? argument,
        [CallerArgumentExpression("argument")] string? argumentName = default,
        string? @default = default,
        string? message = default)
    {
        if (IsNullOrWhiteSpace(argument))
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