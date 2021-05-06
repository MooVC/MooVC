namespace MooVC.Serialization
{
    using System.Runtime.Serialization;

    public interface ICloner
    {
        T Clone<T>(T original)
            where T : ISerializable;
    }
}