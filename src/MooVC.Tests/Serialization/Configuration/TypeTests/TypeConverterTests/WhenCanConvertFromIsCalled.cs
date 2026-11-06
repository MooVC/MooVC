namespace MooVC.Serialization.Configuration.TypeConverterTests;

using Converter = MooVC.Serialization.Configuration.TypeConverter;
using SystemType = System.Type;

public sealed class WhenCanConvertFromIsCalled
{
    [Test]
    [Arguments(typeof(string), true)]
    [Arguments(typeof(int), false)]
    [Arguments(typeof(bool), false)]
    [Arguments(typeof(object), false)]
    public async Task GivenASourceTypeThenStringConversionSupportIsReported(SystemType sourceType, bool expected)
    {
        // Arrange
        var converter = new Converter();

        // Act
        bool actual = converter.CanConvertFrom(sourceType);

        // Assert
        _ = await Assert.That(actual).IsEqualTo(expected);
    }
}