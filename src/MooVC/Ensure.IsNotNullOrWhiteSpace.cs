namespace MooVC;

using System;
using System.Runtime.CompilerServices;
using static System.String;

/// <summary>
/// Provides methods to support validation.
/// </summary>
public static partial class Ensure
{
    /// <summary>
    /// Ensures that the specified string argument is not null or whitespace.
    /// </summary>
    /// <param name="argument">The string argument to check.</param>
    /// <param name="argumentName">
    /// The name of the argument, which will be used in the exception message if the validation fails.
    /// This value is optional and can be provided automatically by the caller via <see cref="CallerArgumentExpressionAttribute"/>.
    /// </param>
    /// <param name="default">
    /// The default value to return if the argument is null or whitespace.
    /// If this is not specified, an exception will be thrown instead.
    /// </param>
    /// <param name="message">
    /// An optional message to include in the exception that is thrown if the argument is null or whitespace and no default value has been specified.
    /// </param>
    /// <returns>
    /// The original string argument, if it is not null or whitespace.
    /// Otherwise, the default value (if specified) or an exception is thrown.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// The argument is null or whitespace and no default value has been specified.
    /// </exception>
#if NET6_0_OR_GREATER
    public static string IsNotNullOrWhiteSpace(
        string? argument,
        [CallerArgumentExpression(nameof(argument))] string? argumentName = default,
        string? @default = default,
        string? message = default)
    {
        return PerformIsNotNullOrWhiteSpace(argument, argumentName, @default, message);
    }
#else
    public static string IsNotNullOrWhiteSpace(string? argument, string? argumentName = default, string? @default = default, string? message = default)
    {
        return PerformIsNotNullOrWhiteSpace(argument, argumentName, @default, message);
    }
#endif

    private static string PerformIsNotNullOrWhiteSpace(string? argument, string? argumentName, string? @default, string? message)
    {
        if (IsNullOrWhiteSpace(argument))
        {
            if (@default is null)
            {
                throw new ArgumentNullException(argumentName, message);
            }

            return @default;
        }

        return argument!;
    }
}