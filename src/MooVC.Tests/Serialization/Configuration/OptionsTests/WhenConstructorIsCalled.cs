namespace MooVC.Serialization.Configuration.OptionsTests;

using System.Text.Json;
using Serializer = MooVC.Serialization.Json.Serializer;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenNewOptionsThenTheJsonSerializerIsSelected()
    {
        // Arrange & Act
        var options = new Options();

        // Assert
        _ = await Assert.That(options.Type).IsEqualTo(Serializer.Json);
#if NET9_0_OR_GREATER
        _ = await Assert.That(options.Json).IsSameReferenceAs(JsonSerializerOptions.Web);
#else
        _ = await Assert.That(options.Json).IsSameReferenceAs(JsonSerializerOptions.Default);
#endif
    }
}