namespace MooVC.Serialization
{
    using System.Runtime.Serialization;

    public static partial class SerializationInfoExtensions
    {
        public static decimal GetInternalDecimal(this SerializationInfo info, string name)
        {
            return info.GetDecimal(FormatName(name));
        }
    }
}