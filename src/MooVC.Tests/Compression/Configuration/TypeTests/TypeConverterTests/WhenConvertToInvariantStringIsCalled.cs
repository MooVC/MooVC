namespace MooVC.Compression.Configuration.TypeConverterTests;

using System.ComponentModel;
using ComponentTypeConverter = System.ComponentModel.TypeConverter;

public sealed class WhenConvertToInvariantStringIsCalled
{
    [Test]
    [Arguments("None")]
    [Arguments("Brotli")]
    [Arguments("Deflate")]
    [Arguments("GZip")]
    [Arguments("Custom.Compression")]
    public async Task GivenIdentifierThenStringValueIsPreserved(string value)
    {
        // Arrange
        ComponentTypeConverter converter = TypeDescriptor.GetConverter(typeof(Type));
        Type type = value;

        // Act
        string? result = converter.ConvertToInvariantString(type);

        // Assert
        _ = await Assert.That(result).IsEqualTo(value);
    }
}