namespace MooVC.Serialization.Configuration
{
    using System.ComponentModel;
    using Monify;

    /// <summary>
    /// Represents the type of serialization strategy to use.
    /// </summary>
    [Monify(Type = typeof(string))]
    [TypeConverterAttribute(typeof(TypeConverter))]
    public partial struct Type
    {
    }
}