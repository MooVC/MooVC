namespace MooVC.Serialization;

using System.Runtime.Serialization;
using static System.String;
using static MooVC.Serialization.Resources;

public static partial class SerializationInfoExtensions
{
    public static T GetValue<T>(this SerializationInfo info, string name)
    {
        object? value = info.GetValue(name, typeof(T));

        if (value is T result)
        {
            return result;
        }

        throw new SerializationException(Format(
            SerializationInfoExtensionsGetValueTypeInvalid,
            name,
            typeof(T).FullName));
    }
}