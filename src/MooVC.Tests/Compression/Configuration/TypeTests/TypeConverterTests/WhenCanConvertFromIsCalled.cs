namespace MooVC.Compression.Configuration.TypeConverterTests;

using System.ComponentModel;
using ComponentTypeConverter = System.ComponentModel.TypeConverter;
using RuntimeType = System.Type;

public sealed class WhenCanConvertFromIsCalled
{
    [Test]
    public async Task GivenStringSourceThenConversionIsSupported()
    {
        // Arrange
        ComponentTypeConverter converter = TypeDescriptor.GetConverter(typeof(Type));

        // Act
        bool result = converter.CanConvertFrom(typeof(string));

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    [Arguments(typeof(int))]
    [Arguments(typeof(object))]
    [Arguments(typeof(Type))]
    public async Task GivenUnsupportedSourceThenConversionIsNotSupported(RuntimeType sourceType)
    {
        // Arrange
        ComponentTypeConverter converter = TypeDescriptor.GetConverter(typeof(Type));

        // Act
        bool result = converter.CanConvertFrom(sourceType);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}