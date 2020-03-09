namespace MooVC.Serialization
{
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static char GetInternalChar(this SerializationInfo info, string name)
        {
            return info.GetChar(FormatName(name));
        }
    }
}