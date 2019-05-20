namespace MooVC.Dynamic
{
    using System.Collections.Generic;
    using System.Dynamic;

    public static class ExpandoObjectExtensions
    {
        public static ExpandoObject Clone(this ExpandoObject orignal)
        {
            var clone = new ExpandoObject();
            var target = (IDictionary<string, object>)clone;
            
            foreach (KeyValuePair<string, object> value in orignal)
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

            return clone;
        }
    }
}