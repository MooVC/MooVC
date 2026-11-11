namespace MooVC.Infrastructure.Serialization.Apex.SerializerTests.FactoryTests;

using System.Diagnostics.CodeAnalysis;
using global::Apex.Serialization;
using Microsoft.Extensions.Configuration;
using MooVC.Composition;
using MooVC.Compression;
using MooVC.Serialization;
using Compression = MooVC.Compression.Configuration.Type;
using Serialization = MooVC.Serialization.Configuration.Type;
using Serializer = MooVC.Infrastructure.Serialization.Apex.Serializer;

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
        bool created = factory.TryCreate(configuration, Serializer.Apex, out ISerializer? instance);

        // Assert
        _ = await Assert.That(created).IsTrue();
        _ = await Assert.That(instance is Serializer).IsTrue();
        (instance as IDisposable)?.Dispose();
    }

    [Test]
    public async Task GivenRepeatedRequestsThenIndependentInstancesAreCreated()
    {
        // Arrange
        var factory = new Serializer.Factory([]);
        IConfigurationSection configuration = CreateConfiguration();

        // Act
        bool firstCreated = factory.TryCreate(configuration, Serializer.Apex, out ISerializer? first);
        bool secondCreated = factory.TryCreate(configuration, Serializer.Apex, out ISerializer? second);

        // Assert
        _ = await Assert.That(firstCreated).IsTrue();
        _ = await Assert.That(secondCreated).IsTrue();
        _ = await Assert.That(ReferenceEquals(first, second)).IsFalse();
        (first as IDisposable)?.Dispose();
        (second as IDisposable)?.Dispose();
    }

    [Test]
    [Arguments("Other")]
    [Arguments("apex")]
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
        const string Original = Value;

        // Act
        bool created = factory.TryCreate(configuration, Serializer.Apex, out ISerializer? instance);
        IEnumerable<byte> serialized = await instance!.Serialize(Original, CancellationToken.None);
        string result = await instance.Deserialize<string>(serialized, CancellationToken.None);

        // Assert
        _ = await Assert.That(created).IsTrue();
        _ = await Assert.That(result).IsEqualTo(Value);
        (instance as IDisposable)?.Dispose();
    }

    [Test]
    [SuppressMessage("Minor Code Smell", "S8969:Null-forgiving operators should not be redundant", Justification = "False positive.")]
    public async Task GivenACompressorThenTheCreatedSerializerCompressesAndRoundTripsAnInstance()
    {
        // Arrange
        const byte GZipHeaderFirstByte = 0x1F;
        const byte GZipHeaderSecondByte = 0x8B;
        const string Value = "Compressed factory serialization sample";
        var compressor = new GZipCompressor(new StreamCompressor.Options());
        IInstanceStrategy<ICompressor, Compression> strategy = Substitute.For<IInstanceStrategy<ICompressor, Compression>>();

        _ = strategy.TryCreate(Arg.Any<IConfigurationSection>(), GZipCompressor.GZip, out Arg.Any<ICompressor?>())
            .Returns(call =>
            {
                call[CompressorArgumentIndex] = compressor;
                return true;
            });

        var factory = new Serializer.Factory([strategy]);
        IConfigurationSection configuration = CreateConfiguration("GZip");
        const string Original = Value;

        // Act
        bool created = factory.TryCreate(configuration, Serializer.Apex, out ISerializer? instance);
        byte[] serialized = (await instance!.Serialize(Original, CancellationToken.None)).ToArray();
        string result = await instance.Deserialize<string>(serialized, CancellationToken.None);

        // Assert
        _ = await Assert.That(created).IsTrue();
        _ = await Assert.That(serialized[0]).IsEqualTo(GZipHeaderFirstByte);
        _ = await Assert.That(serialized[1]).IsEqualTo(GZipHeaderSecondByte);
        _ = await Assert.That(result).IsEqualTo(Value);
        (instance as IDisposable)?.Dispose();
    }

    [Test]
    [SuppressMessage("Minor Code Smell", "S8969:Null-forgiving operators should not be redundant", Justification = "False positive.")]
    public async Task GivenGraphSettingsThenTheCreatedSerializerPreservesSharedReferences()
    {
        // Arrange
        int[] shared = [1, 2, 3];
        int[][] original = [shared, shared];
        var factory = new Serializer.Factory([]);
        IConfigurationSection configuration = CreateConfiguration(setting: nameof(Settings.SerializationMode), value: nameof(Mode.Graph));

        // Act
        bool created = factory.TryCreate(configuration, Serializer.Apex, out ISerializer? instance);
        using var serializer = (Serializer)instance!;
        IEnumerable<byte> serialized = await serializer.Serialize(original, CancellationToken.None);
        int[][] result = await serializer.Deserialize<int[][]>(serialized, CancellationToken.None);

        // Assert
        _ = await Assert.That(created).IsTrue();
        _ = await Assert.That(result[0]).IsEquivalentTo(shared);
        _ = await Assert.That(ReferenceEquals(result[0], result[1])).IsTrue();
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