namespace MooVC.Serialization
{
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static short GetInternalInt16(this SerializationInfo info, string name)
        {
            return info.GetInt16(FormatName(name));
        }
    }
}