namespace MooVC;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Provides methods to support validation.
/// </summary>
public static partial class Ensure
{
    /// <summary>
    /// Validates that a given argument is within a specified range.
    /// If the argument is outside of the range, returns a default value or throws an exception.
    /// </summary>
    /// <typeparam name="T">The type of the argument. Must be a struct and implement IComparable{T}.</typeparam>
    /// <param name="argument">The argument to be validated.</param>
    /// <param name="argumentName">
    /// The name of the argument, which will be used in the exception message if the validation fails.
    /// This value is optional and can be provided automatically by the caller via <see cref="CallerArgumentExpressionAttribute"/>.
    /// </param>
    /// <param name="default">The default value to be returned if the argument is outside of the range. This parameter is optional.</param>
    /// <param name="end">The end of the range. The argument must be less than or equal to this value. This parameter is optional.</param>
    /// <param name="message">An optional message to be included in the exception if one is thrown. This parameter is optional.</param>
    /// <param name="start">The start of the range. The argument must be greater than or equal to this value. This parameter is optional.</param>
    /// <returns>The original argument if it is within the specified range, or the default value if provided.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if the argument is outside of the specified range and no default value is provided.
    /// </exception>
    public static T InRange<T>(
        T argument,
#if NET6_0_OR_GREATER
        [CallerArgumentExpression(nameof(argument))]
#endif
        string? argumentName = default,
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

    /// <summary>
    /// Validates that a given nullable argument is within a specified range.
    /// If the argument is outside of the range, returns a default value or throws an exception.
    /// </summary>
    /// <typeparam name="T">The type of the argument. Must be a struct and implement IComparable{T}.</typeparam>
    /// <param name="argument">The nullable argument to be validated.</param>
    /// <param name="argumentName">
    /// The name of the argument, which will be used in the exception message if the validation fails.
    /// This value is optional and can be provided automatically by the caller via <see cref="CallerArgumentExpressionAttribute"/>.
    /// </param>
    /// <param name="default">The default value to be returned if the argument is outside of the range. This parameter is optional.</param>
    /// <param name="end">The end of the range. The argument must be less than or equal to this value. This parameter is optional.</param>
    /// <param name="message">An optional message to be included in the exception if one is thrown. This parameter is optional.</param>
    /// <param name="start">The start of the range. The argument must be greater than or equal to this value. This parameter is optional.</param>
    /// <returns>The original argument if it is within the specified range, or the default value if provided.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if the argument is outside of the specified range and no default value is provided.
    /// </exception>
    public static T InRange<T>(
        T? argument,
#if NET6_0_OR_GREATER
        [CallerArgumentExpression(nameof(argument))]
#endif
        string? argumentName = default,
        T? @default = default,
        T? end = default,
        string? message = default,
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