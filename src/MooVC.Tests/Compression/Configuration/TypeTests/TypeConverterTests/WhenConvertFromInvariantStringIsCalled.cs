namespace MooVC.Compression.Configuration.TypeConverterTests;

using System.ComponentModel;
using ComponentTypeConverter = System.ComponentModel.TypeConverter;

public sealed class WhenConvertFromInvariantStringIsCalled
{
    [Test]
    public async Task GivenEmptyIdentifierThenEmptyValueIsPreserved()
    {
        // Arrange
        ComponentTypeConverter converter = TypeDescriptor.GetConverter(typeof(Type));

        // Act
        object? result = converter.ConvertFromInvariantString(string.Empty);

        // Assert
        _ = await Assert.That(result).IsTypeOf<Type>();
        _ = await Assert.That((string)(Type)result!).IsEqualTo(string.Empty);
    }

    [Test]
    [Arguments("None")]
    [Arguments("Brotli")]
    [Arguments("Deflate")]
    [Arguments("GZip")]
    [Arguments("Custom.Compression")]
    [Arguments("gzip")]
    [Arguments(" Custom.Compression ")]
    public async Task GivenIdentifierThenExactValueIsPreserved(string value)
    {
        // Arrange
        ComponentTypeConverter converter = TypeDescriptor.GetConverter(typeof(Type));

        // Act
        object? result = converter.ConvertFromInvariantString(value);

        // Assert
        _ = await Assert.That(result).IsTypeOf<Type>();
        _ = await Assert.That((string)(Type)result!).IsEqualTo(value);
    }
}