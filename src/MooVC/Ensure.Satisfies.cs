namespace MooVC;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Provides methods to support validation.
/// </summary>
public static partial class Ensure
{
    /// <summary>
    /// Returns the given argument if it satisfies the specified predicate, or the default value if it is not null and if specified,
    /// or throws an <see cref="ArgumentException"/> if the default value is not specified.
    /// </summary>
    /// <typeparam name="T">The type of the argument to check.</typeparam>
    /// <param name="argument">The argument to check.</param>
    /// <param name="predicate">The predicate to evaluate the argument against.</param>
    /// <param name="argumentName">
    /// The name of the argument, which will be used in the exception message if the validation fails.
    /// This value is optional and can be provided automatically by the caller via <see cref="CallerArgumentExpressionAttribute"/>.
    /// </param>
    /// <param name="default">The default value to return if the argument is not null.</param>
    /// <param name="message">The error message to use if the argument does not satisfy the predicate and no default value is specified.</param>
    /// <returns>
    /// The given argument if it satisfies the specified predicate, or the default value if it is not null and if specified.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// The given argument does not satisfy the specified predicate and no default value is specified.
    /// </exception>
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

    /// <summary>
    /// Returns the given argument if it satisfies the specified predicate, or the default value if it is not null and if specified,
    /// or throws an <see cref="ArgumentException"/> if the default value is not specified.
    /// </summary>
    /// <typeparam name="T">The type of the argument to check.</typeparam>
    /// <param name="argument">The argument to check.</param>
    /// <param name="predicate">The predicate to evaluate the argument against.</param>
    /// <param name="argumentName">
    /// The name of the argument, which will be used in the exception message if the validation fails.
    /// This value is optional and can be provided automatically by the caller via <see cref="CallerArgumentExpressionAttribute"/>.
    /// </param>
    /// <param name="default">The default value to return if the argument is not null.</param>
    /// <param name="message">The error message to use if the argument does not satisfy the predicate and no default value is specified.</param>
    /// <returns>
    /// The given argument if it satisfies the specified predicate, or the default value if it is not null and if specified.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// The given argument does not satisfy the specified predicate and no default value is specified.
    /// </exception>
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