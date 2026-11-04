namespace MooVC.Compression.Configuration
{
    using System.ComponentModel;
    using System.Globalization;
    using Base = System.ComponentModel.TypeConverter;
    using SystemType = System.Type;

    /// <summary>
    /// Converts compression strategy identifiers from configuration strings.
    /// </summary>
    public sealed class TypeConverter
        : Base
    {
        /// <inheritdoc/>
        public override bool CanConvertFrom(ITypeDescriptorContext context, SystemType sourceType)
        {
            return (sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType);
        }

        /// <inheritdoc/>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string identifier)
            {
                return (Type)identifier;
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}