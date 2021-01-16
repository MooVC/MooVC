namespace MooVC.Serialization
{
    using System.Runtime.Serialization;

    public static class SerializableExtensions
    {
        public static T Clone<T>(this T original)
            where T : ISerializable
        {
            var cloner = new BinaryFormatterCloner();

            return cloner.Clone(original);
        }
    }
}