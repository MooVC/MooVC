namespace MooVC.Serialization.Composition.FactoryTests;

using System.Globalization;
using Microsoft.Extensions.Configuration;
using MooVC.Composition;
using MooVC.Compression;
using Compression = MooVC.Compression.Configuration.Type;

public sealed class WhenTryCreateIsCalled
{
    private const int CompressorArgumentIndex = 2;
    private const int ConfigurationArgumentIndex = 0;
    private const string SectionName = "Serializer";
    private const int TypeArgumentIndex = 1;

    [Test]
    public async Task GivenAnUnrecognizedTypeThenNoSerializerIsCreated()
    {
        // Arrange
        const string unexpectedType = "Other";
        IInstanceStrategy<ICompressor, Compression> strategy = Substitute.For<IInstanceStrategy<ICompressor, Compression>>();
        var factory = new TestFactory([strategy]);

        // Act
        bool result = factory.TryCreate(null!, unexpectedType, out ISerializer? instance);

        // Assert
        _ = await Assert.That(result).IsFalse();
        _ = await Assert.That(instance).IsNull();
        _ = await Assert.That(factory.CreationCount).IsEqualTo(0);
        _ = strategy.DidNotReceiveWithAnyArgs().TryCreate(default!, default, out _);
    }

    [Test]
    public async Task GivenSettingsThenTheyAreBoundAndPassedToTheSerializer()
    {
        // Arrange
        const int expected = 256;
        IConfigurationSection configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                [$"{SectionName}:Settings:BufferSize"] = expected.ToString(CultureInfo.InvariantCulture),
                [$"{SectionName}:Settings:Enabled"] = bool.TrueString,
            })
            .Build()
            .GetSection(SectionName);
        var factory = new TestFactory([]);

        // Act
        bool result = factory.TryCreate(configuration, TestFactory.ExpectedType, out ISerializer? instance);

        // Assert
        _ = await Assert.That(result).IsTrue();
        _ = await Assert.That(instance).IsSameReferenceAs(factory.Serializer);
        _ = await Assert.That(factory.CreationCount).IsEqualTo(1);
        _ = await Assert.That(factory.Settings!.BufferSize).IsEqualTo(expected);
        _ = await Assert.That(factory.Settings.Enabled).IsTrue();
        _ = await Assert.That(factory.Compressor).IsNull();
    }

    [Test]
    public async Task GivenNoSettingsThenTheSerializerReceivesDefaultSettings()
    {
        // Arrange
        IConfigurationSection configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                [$"{SectionName}:Compression:Type"] = "None",
            })
            .Build()
            .GetSection(SectionName);
        var factory = new TestFactory([]);

        // Act
        bool result = factory.TryCreate(configuration, TestFactory.ExpectedType, out _);

        // Assert
        _ = await Assert.That(result).IsTrue();
        _ = await Assert.That(factory.Settings).IsNull();
        _ = await Assert.That(factory.Compressor).IsNull();
    }

    [Test]
    public async Task GivenACompressorThenItsOwnConfigurationSectionIsPassedToTheStrategy()
    {
        // Arrange
        const string compressorType = "None";
        const string expected = "512";
        const string parentBufferSize = "256";
        const string serializerBufferSize = "128";
        const string siblingBufferSize = "64";
        IConfigurationSection configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                [$"{SectionName}:BufferSize"] = serializerBufferSize,
                [$"{SectionName}:Compression:BufferSize"] = parentBufferSize,
                [$"{SectionName}:Compression:{compressorType}:BufferSize"] = expected,
                [$"{SectionName}:Compression:Other:BufferSize"] = siblingBufferSize,
            })
            .Build()
            .GetSection(SectionName);
        ICompressor compressor = Substitute.For<ICompressor>();
        IInstanceStrategy<ICompressor, Compression> strategy = Substitute.For<IInstanceStrategy<ICompressor, Compression>>();
        IConfigurationSection? receivedConfiguration = default;
        _ = strategy.TryCreate(default!, default, out _)
            .ReturnsForAnyArgs(call =>
            {
                receivedConfiguration = call.ArgAt<IConfigurationSection>(0);
                call[2] = compressor;

                return true;
            });
        var factory = new TestFactory([strategy]);

        // Act
        bool result = factory.TryCreate(configuration, TestFactory.ExpectedType, out _);

        // Assert
        _ = await Assert.That(result).IsTrue();
        _ = await Assert.That(factory.Compressor).IsSameReferenceAs(compressor);
        _ = await Assert.That(factory.CreationCount).IsEqualTo(1);
        _ = await Assert.That(receivedConfiguration![nameof(TestSettings.BufferSize)]).IsEqualTo(expected);
        _ = await Assert.That(receivedConfiguration.Path).IsEqualTo($"{SectionName}:Compression:{compressorType}");
    }

    [Test]
    [Arguments("Brotli")]
    [Arguments("Deflate")]
    [Arguments("GZip")]
    [Arguments("Custom.Compression")]
    public async Task GivenAConfiguredTypeWhenUnselectedOptionsAreMalformedThenOnlyTheSelectedSectionAndSettingsAreUsed(string compressorType)
    {
        // Arrange
        const string compressorBufferSize = "512";
        const int serializerBufferSize = 128;
        const string malformedValue = "Invalid";
        string unselectedType = compressorType == "Brotli" ? "GZip" : "Brotli";
        IConfigurationSection configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                [$"{SectionName}:Compression:Type"] = compressorType,
                [$"{SectionName}:Compression:{compressorType}:BufferSize"] = compressorBufferSize,
                [$"{SectionName}:Compression:{unselectedType}:BufferSize"] = malformedValue,
                [$"{SectionName}:Compression:{unselectedType}:Level"] = malformedValue,
                [$"{SectionName}:Settings:BufferSize"] = serializerBufferSize.ToString(CultureInfo.InvariantCulture),
                [$"{SectionName}:Settings:Enabled"] = bool.TrueString,
            })
            .Build()
            .GetSection(SectionName);
        ICompressor compressor = Substitute.For<ICompressor>();
        IInstanceStrategy<ICompressor, Compression> strategy = Substitute.For<IInstanceStrategy<ICompressor, Compression>>();
        IConfigurationSection? receivedConfiguration = default;
        Compression receivedType = default;
        _ = strategy.TryCreate(default!, default, out _)
            .ReturnsForAnyArgs(call =>
            {
                receivedConfiguration = call.ArgAt<IConfigurationSection>(ConfigurationArgumentIndex);
                receivedType = call.ArgAt<Compression>(TypeArgumentIndex);
                call[CompressorArgumentIndex] = compressor;

                return true;
            });
        var factory = new TestFactory([strategy]);

        // Act
        bool result = factory.TryCreate(configuration, TestFactory.ExpectedType, out ISerializer? instance);

        // Assert
        _ = await Assert.That(result).IsTrue();
        _ = await Assert.That(instance).IsSameReferenceAs(factory.Serializer);
        _ = await Assert.That(factory.Compressor).IsSameReferenceAs(compressor);
        _ = await Assert.That(factory.CreationCount).IsEqualTo(1);
        _ = await Assert.That((string)receivedType).IsEqualTo(compressorType);
        _ = await Assert.That(receivedConfiguration!.Path).IsEqualTo($"{SectionName}:Compression:{compressorType}");
        _ = await Assert.That(receivedConfiguration[nameof(TestSettings.BufferSize)]).IsEqualTo(compressorBufferSize);
        _ = await Assert.That(factory.Settings!.BufferSize).IsEqualTo(serializerBufferSize);
        _ = await Assert.That(factory.Settings.Enabled).IsTrue();
        _ = strategy.ReceivedWithAnyArgs(1).TryCreate(default!, default, out _);
    }

    [Test]
    public async Task GivenAnEmptySectionThenTheSerializerUsesDefaultCompressionAndSettings()
    {
        // Arrange
        const string defaultCompression = "None";
        IConfigurationSection configuration = new ConfigurationBuilder()
            .Build()
            .GetSection(SectionName);
        IInstanceStrategy<ICompressor, Compression> strategy = Substitute.For<IInstanceStrategy<ICompressor, Compression>>();
        var factory = new TestFactory([strategy]);
        Compression expectedType = defaultCompression;

        // Act
        bool result = factory.TryCreate(configuration, TestFactory.ExpectedType, out ISerializer? instance);

        // Assert
        _ = await Assert.That(result).IsTrue();
        _ = await Assert.That(instance).IsSameReferenceAs(factory.Serializer);
        _ = await Assert.That(factory.Compressor).IsNull();
        _ = await Assert.That(factory.Settings).IsNull();
        _ = await Assert.That(factory.CreationCount).IsEqualTo(1);
        _ = strategy.Received(1).TryCreate(
            Arg.Is<IConfigurationSection>(section => section.Path == $"{SectionName}:Compression:{defaultCompression}"),
            expectedType,
            out _);
    }

    [Test]
    public async Task GivenMatchingTypeAndNullConfigurationThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        IConfigurationSection? configuration = default;
        var factory = new TestFactory([]);

        // Act
        Func<bool> act = () => factory.TryCreate(configuration!, TestFactory.ExpectedType, out _);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(configuration));
    }

    [Test]
    public async Task GivenMalformedSerializerSettingsThenNoCompressorStrategyIsInvoked()
    {
        // Arrange
        const string malformedValue = "Invalid";
        IConfigurationSection configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                [$"{SectionName}:Compression:Type"] = "GZip",
                [$"{SectionName}:Settings:BufferSize"] = malformedValue,
            })
            .Build()
            .GetSection(SectionName);
        IInstanceStrategy<ICompressor, Compression> strategy = Substitute.For<IInstanceStrategy<ICompressor, Compression>>();
        var factory = new TestFactory([strategy]);

        // Act
        Func<bool> act = () => factory.TryCreate(configuration, TestFactory.ExpectedType, out _);

        // Assert
        _ = await Assert.That(act).Throws<InvalidOperationException>();
        _ = await Assert.That(factory.CreationCount).IsEqualTo(0);
        _ = strategy.DidNotReceiveWithAnyArgs().TryCreate(default!, default, out _);
    }

    [Test]
    public async Task GivenNoMatchingCompressorThenTheSerializerIsCreatedWithoutCompression()
    {
        // Arrange
        const string compressorType = "Unavailable";
        IConfigurationSection configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                [$"{SectionName}:Compression:Type"] = compressorType,
            })
            .Build()
            .GetSection(SectionName);
        IInstanceStrategy<ICompressor, Compression> strategy = Substitute.For<IInstanceStrategy<ICompressor, Compression>>();
        var factory = new TestFactory([strategy]);

        // Act
        bool result = factory.TryCreate(configuration, TestFactory.ExpectedType, out ISerializer? instance);

        // Assert
        _ = await Assert.That(result).IsTrue();
        _ = await Assert.That(instance).IsSameReferenceAs(factory.Serializer);
        _ = await Assert.That(factory.Compressor).IsNull();
        _ = strategy.ReceivedWithAnyArgs(1).TryCreate(default!, default, out _);
    }

    [Test]
    public async Task GivenACompressorStrategyThatThrowsThenItsExceptionIsPropagated()
    {
        // Arrange
        const string message = "Compression strategy failed.";
        IConfigurationSection configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                [$"{SectionName}:Compression:Type"] = "None",
            })
            .Build()
            .GetSection(SectionName);
        var expected = new InvalidOperationException(message);
        IInstanceStrategy<ICompressor, Compression> strategy = Substitute.For<IInstanceStrategy<ICompressor, Compression>>();
        _ = strategy.TryCreate(default!, default, out _).ReturnsForAnyArgs(_ => throw expected);
        var factory = new TestFactory([strategy]);

        // Act
        Func<bool> act = () => factory.TryCreate(configuration, TestFactory.ExpectedType, out _);

        // Assert
        InvalidOperationException actual = await Assert.That(act).Throws<InvalidOperationException>().And.IsNotNull();
        _ = await Assert.That(actual).IsSameReferenceAs(expected);
        _ = await Assert.That(factory.CreationCount).IsEqualTo(0);
    }
}