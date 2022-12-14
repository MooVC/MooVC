namespace MooVC.Dynamic;

using System;
using System.Collections.Generic;
using System.Dynamic;

/// <summary>
/// Provides extensions relating to ExpandoObject.
/// </summary>
public static class ExpandoObjectExtensions
{
    /// <summary>
    /// Clones the given ExpandoObject.
    /// If the original object is null and defaultIfNull is true, a default ExpandoObject is returned.
    /// If defaultIfNull is false and the original object is null, an ArgumentNullException is thrown.
    /// </summary>
    /// <param name="original">The original ExpandoObject to clone.</param>
    /// <param name="defaultIfNull">
    /// Whether to return a default ExpandoObject if the original object is null.
    /// If this is set to false and the original object is null, an ArgumentNullException is thrown.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if defaultIfNull is false and the original object is null.
    /// </exception>
    /// <returns>A clone of the original ExpandoObject.</returns>
    public static ExpandoObject Clone(this ExpandoObject? original, bool defaultIfNull = true)
    {
        var clone = new ExpandoObject();

        if (original is { })
        {
            var target = (IDictionary<string, object?>)clone;

            foreach (KeyValuePair<string, object?> value in original)
            {
                if (value.Value is ExpandoObject child)
                {
                    target.Add(value.Key, child.Clone());
                }
                else
                {
                    target.Add(value);
                }
            }
        }
        else if (!defaultIfNull)
        {
            throw new ArgumentNullException(nameof(original));
        }

        return clone;
    }
}