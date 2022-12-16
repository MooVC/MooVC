namespace MooVC;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Provides methods to support validation.
/// </summary>
public static partial class Ensure
{
    /// <summary>
    /// Ensures that the specified nullable value type argument is not null.
    /// </summary>
    /// <typeparam name="T">The type of the nullable value.</typeparam>
    /// <param name="argument">The nullable value type argument to check.</param>
    /// <param name="argumentName">
    /// The name of the argument, which will be used in the exception message if the validation fails.
    /// This value is optional and can be provided automatically by the caller via <see cref="CallerArgumentExpressionAttribute"/>.
    /// </param>
    /// <param name="default">
    /// The default value to return if the argument is null.
    /// If this is not specified, an exception will be thrown instead.
    /// </param>
    /// <param name="message">
    /// An optional message to include in the exception that is thrown if the argument is null and no default value has been specified.
    /// </param>
    /// <returns>
    /// The original nullable value type argument, if it is not null.
    /// Otherwise, the default value (if specified) or an exception is thrown.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// The original nullable value type argument is null and no default value has been specified.
    /// </exception>
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

    /// <summary>
    /// Ensures that the specified nullable reference type argument is not null.
    /// </summary>
    /// <typeparam name="T">The type of the nullable reference.</typeparam>
    /// <param name="argument">The nullable reference type argument to check.</param>
    /// <param name="argumentName">
    /// The name of the argument, which will be used in the exception message if the validation fails.
    /// This value is optional and can be provided automatically by the caller via <see cref="CallerArgumentExpressionAttribute"/>.
    /// </param>
    /// <param name="default">
    /// The default value to return if the argument is null.
    /// If this is not specified, an exception will be thrown instead.
    /// </param>
    /// <param name="message">
    /// An optional message to include in the exception that is thrown if the argument is null and no default value has been specified.
    /// </param>
    /// <returns>
    /// The original nullable reference type argument, if it is not null.
    /// Otherwise, the default value (if specified) or an exception is thrown.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// The original nullable reference type argument is null and no default value has been specified.
    /// </exception>
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