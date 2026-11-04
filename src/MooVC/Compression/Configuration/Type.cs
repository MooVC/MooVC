namespace MooVC.Compression.Configuration
{
    using System.ComponentModel;
    using Monify;

    /// <summary>
    /// Represents the type of compression strategy to use.
    /// </summary>
    [Monify(Type = typeof(string))]
    [TypeConverterAttribute(typeof(TypeConverter))]
    public partial struct Type
    {
    }
}