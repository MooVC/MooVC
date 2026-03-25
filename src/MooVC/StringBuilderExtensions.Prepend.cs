namespace MooVC;

using System.Text;
using Ardalis.GuardClauses;
using static MooVC.StringBuilderExtensions_Resources;

/// <summary>
/// Provides prepend helpers for <see cref="StringBuilder"/> values.
/// </summary>
public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Prepends a character to the beginning of the current <see cref="StringBuilder"/> instance.
    /// </summary>
    /// <param name="builder">The builder to prepend the value to.</param>
    /// <param name="value">The character to insert at the beginning of the builder.</param>
    /// <returns>The same <see cref="StringBuilder"/> instance for chaining.</returns>
    public static StringBuilder Prepend(this StringBuilder builder, char value)
    {
        _ = Guard.Against.Null(builder, message: PrependBuilderRequired.Format(value));
        _ = Guard.Against.Null(value, message: PrependValueRequired);

        return builder.Insert(0, value);
    }

    /// <summary>
    /// Prepends a string to the beginning of the current <see cref="StringBuilder"/> instance.
    /// </summary>
    /// <param name="builder">The builder to prepend the value to.</param>
    /// <param name="value">The text to insert at the beginning of the builder.</param>
    /// <returns>The same <see cref="StringBuilder"/> instance for chaining.</returns>
    public static StringBuilder Prepend(this StringBuilder builder, string value)
    {
        _ = Guard.Against.Null(builder, message: PrependBuilderRequired.Format(value));
        _ = Guard.Against.Null(value, message: PrependValueRequired);

        return builder.Insert(0, value);
    }
}