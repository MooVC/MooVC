namespace MooVC;

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MooVC.Collections.Generic;
using MooVC.Linq;

/// <summary>
/// Provides methods to support validation.
/// </summary>
public static partial class Ensure
{
    /// <summary>
    /// Validates that the given <see cref="Guid"/> value is not empty.
    /// </summary>
    /// <param name="argument">The value to be validated.</param>
    /// <param name="argumentName">
    /// The name of the argument, which will be used in the exception message if the validation fails.
    /// This value is optional and can be provided automatically by the caller via <see cref="CallerArgumentExpressionAttribute"/>.
    /// </param>
    /// <param name="default">The default value to be returned if the validation fails. This value is optional.</param>
    /// <param name="message">The error message to be used in the exception if the validation fails. This value is optional.</param>
    /// <returns>The given <see cref="Guid"/> value if it is not empty, or the default value if provided and the validation fails.</returns>
    /// <exception cref="ArgumentException">Thrown if the given <see cref="Guid"/> value is empty and no default value is provided.</exception>
    public static Guid IsNotEmpty(
        Guid? argument,
        [CallerArgumentExpression("argument")] string? argumentName = default,
        Guid? @default = default,
        string? message = default)
    {
        return Satisfies(argument, value => value != Guid.Empty, argumentName: argumentName, @default: @default, message: message);
    }

    /// <summary>
    /// Validates that the given <see cref="TimeSpan"/> value is not empty.
    /// </summary>
    /// <param name="argument">The value to be validated.</param>
    /// <param name="argumentName">
    /// The name of the argument, which will be used in the exception message if the validation fails.
    /// This value is optional and can be provided automatically by the caller via <see cref="CallerArgumentExpressionAttribute"/>.
    /// </param>
    /// <param name="default">The default value to be returned if the validation fails. This value is optional.</param>
    /// <param name="message">The error message to be used in the exception if the validation fails. This value is optional.</param>
    /// <returns>The given <see cref="TimeSpan"/> value if it is not empty, or the default value if provided and the validation fails.</returns>
    /// <exception cref="ArgumentException">Thrown if the given <see cref="TimeSpan"/> value is empty and no default value is provided.</exception>
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

    /// <summary>
    /// Validates that the given sequence of elements is not empty.
    /// </summary>
    /// <typeparam name="T">The type of elements in the sequence.</typeparam>
    /// <param name="argument">The sequence of elements to validate.</param>
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
    /// <param name="predicate">
    /// A predicate to apply to each element in the sequence to determine if it should be included.
    /// This value is optional. If not provided, the default predicate will include all elements that are not null.
    /// </param>
    /// <returns>
    /// The given sequence of elements if it is not empty, or <paramref name="default"/> if provided.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if the argument is empty and no default value was provided.
    /// </exception>
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