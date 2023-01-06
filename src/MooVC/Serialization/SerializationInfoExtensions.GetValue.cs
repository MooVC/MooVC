namespace MooVC.Serialization;

using System.Runtime.Serialization;
using static System.String;
using static MooVC.Serialization.Resources;

public static partial class SerializationInfoExtensions
{
    [Obsolete(@"Slated for removal in v8 as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static T GetValue<T>(this SerializationInfo info, string name)
    {
        object? value = info.GetValue(name, typeof(T));

        if (value is T result)
        {
            return result;
        }

        throw new SerializationException(Format(SerializationInfoExtensionsGetValueTypeInvalid, name, typeof(T).FullName));
    }
}