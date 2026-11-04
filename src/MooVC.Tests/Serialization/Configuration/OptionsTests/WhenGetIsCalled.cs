namespace MooVC.Serialization.Configuration.OptionsTests;

using Microsoft.Extensions.Configuration;

public sealed class WhenGetIsCalled
{
    [Test]
    [Arguments("Json")]
    [Arguments("Newtonsoft.Json")]
    [Arguments("MessagePack")]
    public async Task GivenATypeNameThenTheConfiguredTypeIsSelected(string expected)
    {
        // Arrange
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                [nameof(Options.Type)] = expected,
            })
            .Build();

        // Act
        Options? options = configuration.Get<Options>();

        // Assert
        _ = await Assert.That(options).IsNotNull();
        _ = await Assert.That((string)options!.Type).IsEqualTo(expected);
    }
}