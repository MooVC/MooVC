namespace MooVC.Compression.Configuration.TypeConverterTests;

using System.ComponentModel;
using System.Globalization;
using ComponentTypeConverter = System.ComponentModel.TypeConverter;

public sealed class WhenConvertFromIsCalled
{
    [Test]
    [Arguments("en-IE")]
    [Arguments("tr-TR")]
    public async Task GivenCustomIdentifierThenCultureDoesNotChangeTheValue(string cultureName)
    {
        // Arrange
        const string value = "Custom.Identifier";
        ComponentTypeConverter converter = TypeDescriptor.GetConverter(typeof(Type));
        CultureInfo culture = CultureInfo.GetCultureInfo(cultureName);

        // Act
        object? result = converter.ConvertFrom(null, culture, value);

        // Assert
        _ = await Assert.That((string)(Type)result!).IsEqualTo(value);
    }

    [Test]
    public async Task GivenUnsupportedValueThenNotSupportedExceptionIsThrown()
    {
        // Arrange
        const int value = 42;
        ComponentTypeConverter converter = TypeDescriptor.GetConverter(typeof(Type));

        // Act
        Func<object?> act = () => converter.ConvertFrom(value);

        // Assert
        _ = await Assert.That(act).Throws<NotSupportedException>();
    }

    [Test]
    public async Task GivenNullThenNotSupportedExceptionIsThrown()
    {
        // Arrange
        ComponentTypeConverter converter = TypeDescriptor.GetConverter(typeof(Type));

        // Act
        Func<object?> act = () => converter.ConvertFrom(null!);

        // Assert
        _ = await Assert.That(act).Throws<NotSupportedException>();
    }
}