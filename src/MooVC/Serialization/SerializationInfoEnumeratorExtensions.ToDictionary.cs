namespace MooVC.Serialization
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public static partial class SerializationInfoEnumeratorExtensions
    {
        public static IDictionary<string, object?> ToDictionary(this SerializationInfoEnumerator enumerator)
        {
            var contents = new Dictionary<string, object?>();

            while (enumerator.MoveNext())
            {
                contents[enumerator.Current.Name] = enumerator.Current.Value;
            }

            return contents;
        }
    }
}