namespace MooVC.Serialization.Configuration.TypeConverterTests;

using System.ComponentModel;
using ComponentConverter = System.ComponentModel.TypeConverter;
using Converter = MooVC.Serialization.Configuration.TypeConverter;

public sealed class WhenGetConverterIsCalled
{
    [Test]
    public async Task GivenTheSerializationTypeThenItsStringConverterIsDiscovered()
    {
        // Arrange & Act
        ComponentConverter converter = TypeDescriptor.GetConverter(typeof(Type));

        // Assert
        _ = await Assert.That(converter is Converter).IsTrue();
    }
}