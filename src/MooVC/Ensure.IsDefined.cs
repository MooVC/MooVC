namespace MooVC;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Provides methods to support validation.
/// </summary>
public static partial class Ensure
{
    /// <summary>
    /// Validates that the given value is defined as a member of the specified enumeration.
    /// </summary>
    /// <typeparam name="T">The type of the enumeration.</typeparam>
    /// <param name="argument">The value to validate.</param>
    /// <param name="argumentName">
    /// The name of the argument, which will be used in the exception message if the validation fails.
    /// This value is optional and can be provided automatically by the caller via <see cref="CallerArgumentExpressionAttribute"/>.
    /// </param>
    /// <param name="default">
    /// The default value to return if the argument is invalid.
    /// This value is optional.
    /// If not provided, an exception will be thrown if the argument is invalid.
    /// </param>
    /// <param name="message">
    /// The message to include in the exception if the argument is invalid.
    /// This value is optional.
    /// If not provided, a default message will be used.
    /// </param>
    /// <returns>
    /// The given value if it is defined as a member of the specified enumeration, or <paramref name="default"/> if provided.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if the argument is not defined as a member of the specified enumeration and no default value was provided.
    /// </exception>
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

    /// <summary>
    /// Validates that the given nullable value is defined as a member of the specified enumeration.
    /// </summary>
    /// <typeparam name="T">The type of the enumeration.</typeparam>
    /// <param name="argument">The nullable value to validate.</param>
    /// <param name="argumentName">
    /// The name of the argument, which will be used in the exception message if the validation fails.
    /// This value is optional and can be provided automatically by the caller via <see cref="CallerArgumentExpressionAttribute"/>.
    /// </param>
    /// <param name="default">
    /// The default value to return if the argument is invalid.
    /// This value is optional.
    /// If not provided, an exception will be thrown if the argument is invalid.
    /// </param>
    /// <param name="message">
    /// The message to include in the exception if the argument is invalid.
    /// This value is optional.
    /// If not provided, a default message will be used.
    /// </param>
    /// <returns>
    /// The given value if it is defined as a member of the specified enumeration, or <paramref name="default"/> if provided.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if the argument is not defined as a member of the specified enumeration and no default value was provided.
    /// </exception>
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