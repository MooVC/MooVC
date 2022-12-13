namespace MooVC.Dynamic;

using System;
using System.Collections.Generic;
using System.Dynamic;

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
    public static ExpandoObject Clone(this ExpandoObject? orignal, bool defaultIfNull = true)
    {
        var clone = new ExpandoObject();

        if (orignal is { })
        {
            var target = (IDictionary<string, object?>)clone;

            foreach (KeyValuePair<string, object?> value in orignal)
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
            throw new ArgumentNullException(nameof(orignal));
        }

        return clone;
    }
}