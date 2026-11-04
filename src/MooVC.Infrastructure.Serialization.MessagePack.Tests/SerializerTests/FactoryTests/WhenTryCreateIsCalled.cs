namespace MooVC.Infrastructure.Serialization.MessagePack.SerializerTests.FactoryTests;

using global::MessagePack;
using Microsoft.Extensions.Configuration;
using MooVC.Composition;
using MooVC.Compression;
using MooVC.Serialization;
using Compression = MooVC.Compression.Configuration.Type;
using Serialization = MooVC.Serialization.Configuration.Type;
using Serializer = MooVC.Infrastructure.Serialization.MessagePack.Serializer;

public sealed class WhenTryCreateIsCalled
{
    private const int CompressorArgumentIndex = 2;

    [Test]
    public async Task GivenTheExpectedTypeThenADefaultSerializerIsCreated()
    {
        // Arrange
        var factory = new Serializer.Factory([]);
        IConfigurationSection configuration = CreateConfiguration();

        // Act
        bool created = factory.TryCreate(configuration, Serializer.MessagePack, out ISerializer? instance);

        // Assert
        _ = await Assert.That(created).IsTrue();
        _ = await Assert.That(instance is Serializer).IsTrue();
    }

    [Test]
    public async Task GivenRepeatedRequestsThenIndependentInstancesAreCreated()
    {
        // Arrange
        var factory = new Serializer.Factory([]);
        IConfigurationSection configuration = CreateConfiguration();

        // Act
        bool firstCreated = factory.TryCreate(configuration, Serializer.MessagePack, out ISerializer? first);
        bool secondCreated = factory.TryCreate(configuration, Serializer.MessagePack, out ISerializer? second);

        // Assert
        _ = await Assert.That(firstCreated).IsTrue();
        _ = await Assert.That(secondCreated).IsTrue();
        _ = await Assert.That(ReferenceEquals(first, second)).IsFalse();
    }

    [Test]
    [Arguments("Other")]
    [Arguments("messagepack")]
    public async Task GivenAnUnexpectedTypeThenNoInstanceIsCreated(string name)
    {
        // Arrange
        var factory = new Serializer.Factory([]);
        Serialization type = name;

        // Act
        bool created = factory.TryCreate(null!, type, out ISerializer? instance);

        // Assert
        _ = await Assert.That(created).IsFalse();
        _ = await Assert.That(instance).IsNull();
    }

    [Test]
    public async Task GivenDefaultTypeThenNoInstanceIsCreated()
    {
        // Arrange
        var factory = new Serializer.Factory([]);

        // Act
        bool created = factory.TryCreate(null!, default, out ISerializer? instance);

        // Assert
        _ = await Assert.That(created).IsFalse();
        _ = await Assert.That(instance).IsNull();
    }

    [Test]
    public async Task GivenNoCompressorThenTheCreatedSerializerRoundTripsAnInstance()
    {
        // Arrange
        const string Value = "Factory serialization sample";
        var factory = new Serializer.Factory([]);
        IConfigurationSection configuration = CreateConfiguration();
        var original = new SerializableClass { String = Value };

        // Act
        bool created = factory.TryCreate(configuration, Serializer.MessagePack, out ISerializer? instance);
        IEnumerable<byte> serialized = await instance!.Serialize(original, CancellationToken.None);
        SerializableClass result = await instance.Deserialize<SerializableClass>(serialized, CancellationToken.None);

        // Assert
        _ = await Assert.That(created).IsTrue();
        _ = await Assert.That(result.String).IsEqualTo(Value);
    }

    [Test]
    public async Task GivenACompressorThenTheCreatedSerializerCompressesAndRoundTripsAnInstance()
    {
        // Arrange
        const byte GZipHeaderFirstByte = 0x1F;
        const byte GZipHeaderSecondByte = 0x8B;
        const string Value = "Compressed factory serialization sample";
        var compressor = new GZipCompressor(new StreamCompressor.Options());
        var strategy = Substitute.For<IInstanceStrategy<ICompressor, Compression>>();
        _ = strategy.TryCreate(Arg.Any<IConfigurationSection>(), GZipCompressor.GZip, out Arg.Any<ICompressor?>())
            .Returns(call =>
            {
                call[CompressorArgumentIndex] = compressor;
                return true;
            });
        var factory = new Serializer.Factory([strategy]);
        IConfigurationSection configuration = CreateConfiguration("GZip");
        var original = new SerializableClass { String = Value };

        // Act
        bool created = factory.TryCreate(configuration, Serializer.MessagePack, out ISerializer? instance);
        byte[] serialized = (await instance!.Serialize(original, CancellationToken.None)).ToArray();
        SerializableClass result = await instance.Deserialize<SerializableClass>(serialized, CancellationToken.None);

        // Assert
        _ = await Assert.That(created).IsTrue();
        _ = await Assert.That(serialized[0]).IsEqualTo(GZipHeaderFirstByte);
        _ = await Assert.That(serialized[1]).IsEqualTo(GZipHeaderSecondByte);
        _ = await Assert.That(result.String).IsEqualTo(Value);
    }

    [Test]
    public async Task GivenNoSettingsThenTheCreatedSerializerUsesStandardOptions()
    {
        // Arrange
        var factory = new Serializer.Factory([]);
        IConfigurationSection configuration = CreateConfiguration();

        // Act
        bool created = factory.TryCreate(configuration, Serializer.MessagePack, out ISerializer? instance);

        // Assert
        _ = await Assert.That(created).IsTrue();
        var serializer = (Serializer)instance!;
        _ = await Assert.That(ReferenceEquals(serializer.Options, MessagePackSerializerOptions.Standard)).IsTrue();
    }

    private static IConfigurationSection CreateConfiguration(string compression = "None", string? setting = null, string? value = null)
    {
        var values = new Dictionary<string, string?>
        {
            ["Serialization:Compression:Type"] = compression,
        };

        if (setting is not null)
        {
            values["Serialization:Settings:" + setting] = value;
        }

        return new ConfigurationBuilder()
            .AddInMemoryCollection(values)
            .Build()
            .GetSection("Serialization");
    }
}