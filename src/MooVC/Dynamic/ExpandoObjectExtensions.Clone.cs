namespace MooVC.Dynamic;

using System;
using System.Collections.Generic;
using System.Dynamic;

public static class ExpandoObjectExtensions
{
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