namespace MooVC.Serialization.Configuration.TypeConverterTests;

using System.Globalization;
using Converter = MooVC.Serialization.Configuration.TypeConverter;

public sealed class WhenConvertFromIsCalled
{
    [Test]
    [Arguments("Json")]
    [Arguments("Newtonsoft.Json")]
    [Arguments("Newtonsoft.Bson")]
    [Arguments("MessagePack")]
    [Arguments("Apex")]
    [Arguments("Custom.Serialization")]
    [Arguments("json")]
    [Arguments(" ")]
    public async Task GivenAStringThenItsExactValueIsRetained(string expected)
    {
        // Arrange
        var converter = new Converter();

        // Act
        object? converted = converter.ConvertFrom(expected);

        // Assert
        _ = await Assert.That(converted is Type).IsTrue();
        _ = await Assert.That((string)(Type)converted!).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenAnEmptyStringThenItsExactValueIsRetained()
    {
        // Arrange
        var converter = new Converter();
        string expected = string.Empty;

        // Act
        object? converted = converter.ConvertFrom(expected);

        // Assert
        _ = await Assert.That(converted is Type).IsTrue();
        _ = await Assert.That((string)(Type)converted!).IsEqualTo(expected);
    }

    [Test]
    [Arguments("en-US")]
    [Arguments("tr-TR")]
    public async Task GivenACultureThenTheIdentifierIsRetainedWithoutNormalization(string culture)
    {
        // Arrange
        const string Expected = "Custom.ISerializer";
        var converter = new Converter();
        CultureInfo format = CultureInfo.GetCultureInfo(culture);

        // Act
        object converted = converter.ConvertFrom(null, format, Expected);

        // Assert
        _ = await Assert.That(converted is Type).IsTrue();
        _ = await Assert.That((string)(Type)converted).IsEqualTo(Expected);
    }

    [Test]
    public async Task GivenAnIntegerThenANotSupportedExceptionIsThrown()
    {
        // Arrange
        const int UnsupportedValue = 23;
        var converter = new Converter();
        Action act = () => _ = converter.ConvertFrom(UnsupportedValue);

        // Act & Assert
        _ = await Assert.That(act).Throws<NotSupportedException>();
    }

    [Test]
    public async Task GivenNullThenANotSupportedExceptionIsThrown()
    {
        // Arrange
        var converter = new Converter();
        Action act = () => _ = converter.ConvertFrom(null, CultureInfo.InvariantCulture, null!);

        // Act & Assert
        _ = await Assert.That(act).Throws<NotSupportedException>();
    }
}