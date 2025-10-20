namespace MooVC;

using System.Globalization;
using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using static MooVC.StringExtensions_Resources;

/// <summary>
/// Provides extensions relating to object.
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// A instance based implementation of string.Format that uses the current culture.
    /// </summary>
    /// <param name="value">A composite format string.</param>
    /// <param name="arguments">An object array that contains zero or more objects to format.</param>
    /// <returns>
    /// A copy of format in which the format items have been replaced by the string representation of the corresponding objects in args.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Format(this string value, params object[] arguments)
    {
        _ = Guard.Against.Null(value, message: FormatValueRequired);

        return string.Format(CultureInfo.CurrentCulture, value, arguments);
    }
}