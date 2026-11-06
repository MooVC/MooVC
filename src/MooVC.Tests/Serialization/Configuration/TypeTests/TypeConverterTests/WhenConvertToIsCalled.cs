namespace MooVC.Serialization.Configuration.TypeConverterTests;

using System.Globalization;
using Converter = MooVC.Serialization.Configuration.TypeConverter;

public sealed class WhenConvertToIsCalled
{
    [Test]
    [Arguments("Json")]
    [Arguments("Custom.Serialization")]
    [Arguments("json")]
    public async Task GivenAnIdentifierThenTheBaseStringConversionRetainsItsValue(string expected)
    {
        // Arrange
        var converter = new Converter();
        Type type = expected;

        // Act
        object? converted = converter.ConvertTo(null, CultureInfo.InvariantCulture, type, typeof(string));

        // Assert
        _ = await Assert.That(converted is string).IsTrue();
        _ = await Assert.That((string?)converted).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenAnIntegerDestinationThenANotSupportedExceptionIsThrown()
    {
        // Arrange
        const string Name = "Json";
        var converter = new Converter();
        Type type = Name;
        Action act = () => _ = converter.ConvertTo(type, typeof(int));

        // Act & Assert
        _ = await Assert.That(act).Throws<NotSupportedException>();
    }
}