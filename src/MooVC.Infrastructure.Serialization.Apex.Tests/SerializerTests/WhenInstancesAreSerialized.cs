namespace MooVC.Infrastructure.Serialization.Apex.SerializerTests;

using global::Apex.Serialization;
using MooVC.Serialization;
using Serializer = MooVC.Infrastructure.Serialization.Apex.Serializer;

public sealed class WhenInstancesAreSerialized
    : IDisposable
{
    private readonly ISerializer serializer;
    private bool isDisposed;

    public WhenInstancesAreSerialized()
    {
        Settings settings = new Settings()
            .MarkSerializable(type => true);

        serializer = new Serializer(settings: settings);
    }

    public void Dispose()
    {
        Dispose(isDisposing: true);

        GC.SuppressFinalize(this);
    }

    [Fact]
    public async Task GivenAnInstanceOfAClassThenACloneOfThatInstanceIsDeserialized()
    {
        // Arrange
        var original = new SerializableClass
        {
            Array = [1, 2, 3],
            Integer = 25,
            String = "Something something dark side...",
        };

        // Act
        IEnumerable<byte> stream = await serializer.Serialize(original, CancellationToken.None);
        SerializableClass deserialized = await serializer.Deserialize<SerializableClass>(stream, CancellationToken.None);

        // Assert
        _ = deserialized.Should().NotBe(original);
        _ = deserialized.Should().BeEquivalentTo(original);
    }

    [Fact]
    public async Task GivenAnInstanceOfAClassWhenSerializedToAStreamThenACloneOfThatInstanceIsDeserialized()
    {
        // Arrange
        var original = new SerializableClass
        {
            Array = [1, 2, 3],
            Integer = 25,
            String = "Something something dark side...",
        };

        using var stream = new MemoryStream();

        // Act
        await serializer.Serialize(original, stream, CancellationToken.None);

        stream.Position = 0;

        SerializableClass deserialized = await serializer.Deserialize<SerializableClass>(stream, CancellationToken.None);

        // Assert
        _ = deserialized.Should().NotBe(original);
        _ = deserialized.Should().BeEquivalentTo(original);
    }

    [Fact]
    public async Task GivenAnInstanceOfAClassWithAReferencedObjectWhenSerializedToAStreamThenACloneOfThatInstanceIsDeserialized()
    {
        // Arrange
        var original = new SerializableClass
        {
            Array = [1, 2, 3],
            Integer = 25,
            Object = new SerializableClass(),
            String = "Something something dark side...",
        };

        using var stream = new MemoryStream();

        // Act
        await serializer.Serialize<ISerializableInstance>(original, stream, CancellationToken.None);

        stream.Position = 0;

        ISerializableInstance deserialized = await serializer.Deserialize<ISerializableInstance>(stream, CancellationToken.None);

        // Assert
        _ = deserialized.Should().NotBe(original);
        _ = deserialized.Should().BeEquivalentTo(original);
    }

    [Fact]
    public async Task GivenAnInstanceOfARecordWhenSerializedToAStreamThenACloneOfThatInstanceIsDeserialized()
    {
        // Arrange
        var original = new SerializableRecord(
            [1, 2, 3],
            25,
            default,
            "Something something dark side...");

        using var stream = new MemoryStream();

        // Act
        await serializer.Serialize(original, stream, CancellationToken.None);

        stream.Position = 0;

        SerializableRecord deserialized = await serializer.Deserialize<SerializableRecord>(stream, CancellationToken.None);

        // Assert
        _ = deserialized.Should().NotBe(original);
        _ = deserialized.Should().BeEquivalentTo(original);
    }

    [Fact]
    public async Task GivenAnInstanceOfARecordThenACloneOfThatInstanceIsDeserialized()
    {
        // Arrange
        var original = new SerializableRecord(
            [1, 2, 3],
            25,
            default,
            "Something something dark side...");

        // Act
        IEnumerable<byte> stream = await serializer.Serialize(original, CancellationToken.None);
        SerializableRecord deserialized = await serializer.Deserialize<SerializableRecord>(stream, CancellationToken.None);

        // Assert
        _ = deserialized.Should().NotBe(original);
        _ = deserialized.Should().BeEquivalentTo(original);
    }

    [Fact]
    public async Task GivenAnInstanceOfARecordWithAReferencedObjectWhenSerializedToAStreamThenACloneOfThatInstanceIsDeserialized()
    {
        // Arrange
        var original = new SerializableRecord(
            [1, 2, 3],
            25,
            new SerializableRecord(
                [1, 5],
                3,
                default,
                "Something else..."),
            "Something something dark side...");

        using var stream = new MemoryStream();

        // Act
        await serializer.Serialize<ISerializableInstance>(original, stream, CancellationToken.None);

        stream.Position = 0;

        ISerializableInstance deserialized = await serializer.Deserialize<ISerializableInstance>(stream, CancellationToken.None);

        // Assert
        _ = deserialized.Should().NotBe(original);
        _ = deserialized.Should().BeEquivalentTo(original);
    }

    [Fact]
    public async Task GivenAnInstancesOfAClassThenACloneOfThatInstanceIsDeserialized()
    {
        // Arrange
        IEnumerable<SerializableClass> originals =
        [
            new SerializableClass
            {
                Array = [1, 2, 3],
                Integer = 25,
                String = "Something something",
            },
            new SerializableClass
            {
                Array = [4, 5, 6],
                Integer = 2,
                String = "dark side...",
            },
        ];

        // Act
        IEnumerable<byte> stream = await serializer.Serialize(originals, CancellationToken.None);
        IEnumerable<SerializableClass> deserialized = await serializer.Deserialize<IEnumerable<SerializableClass>>(stream, CancellationToken.None);

        // Assert
        _ = deserialized.Should().BeEquivalentTo(originals);
    }

    [Fact]
    public async Task GivenAnInstancesOfAClassWhenSerializedToAStreamThenACloneOfThatInstanceIsDeserialized()
    {
        // Arrange
        IEnumerable<SerializableClass> originals =
        [
            new SerializableClass
            {
                Array = [1, 2, 3],
                Integer = 25,
                String = "Something something",
            },
            new SerializableClass
            {
                Array = [4, 5, 6],
                Integer = 2,
                String = "dark side...",
            },
        ];

        using var stream = new MemoryStream();

        // Act
        await serializer.Serialize(originals, stream, CancellationToken.None);

        stream.Position = 0;

        IEnumerable<SerializableClass> deserialized = await serializer.Deserialize<IEnumerable<SerializableClass>>(stream, CancellationToken.None);

        // Assert
        _ = deserialized.Should().BeEquivalentTo(originals);
    }

    [Fact]
    public async Task GivenAnInstancesOfAClassWithAReferencedObjectWhenSerializedToAStreamThenACloneOfThatInstanceIsDeserialized()
    {
        // Arrange
        IEnumerable<ISerializableInstance> originals =
        [
            new SerializableClass
            {
                Array = [1, 2, 3],
                Integer = 25,
                Object = new SerializableClass(),
                String = "Something something",
            },
            new SerializableClass
            {
                Array = [4, 5, 6],
                Integer = 5,
                Object = new SerializableClass(),
                String = "dark side...",
            },
        ];

        using var stream = new MemoryStream();

        // Act
        await serializer.Serialize(originals, stream, CancellationToken.None);

        stream.Position = 0;

        IEnumerable<ISerializableInstance> deserialized = await serializer
            .Deserialize<IEnumerable<ISerializableInstance>>(stream, CancellationToken.None);

        // Assert
        _ = deserialized.Should().BeEquivalentTo(originals);
    }

    [Fact]
    public async Task GivenAnInstancesOfARecordWhenSerializedToAStreamThenACloneOfThatInstanceIsDeserialized()
    {
        // Arrange
        IEnumerable<SerializableRecord> originals =
        [
            new SerializableRecord(
                [1, 2, 3],
                25,
                default,
                "Something something"),
            new SerializableRecord(
                [4, 5, 6],
                5,
                default,
                "dark side..."),
        ];

        using var stream = new MemoryStream();

        // Act
        await serializer.Serialize(originals, stream, CancellationToken.None);

        stream.Position = 0;

        IEnumerable<SerializableRecord> deserialized = await serializer.Deserialize<IEnumerable<SerializableRecord>>(stream, CancellationToken.None);

        // Assert
        _ = deserialized.Should().BeEquivalentTo(originals);
    }

    [Fact]
    public async Task GivenAnInstancesOfARecordThenACloneOfThatInstanceIsDeserialized()
    {
        // Arrange
        IEnumerable<SerializableRecord> originals =
        [
            new SerializableRecord(
                [1, 2, 3],
                25,
                default,
                "Something something"),
            new SerializableRecord(
                [4, 5, 6],
                5,
                default,
                "dark side..."),
        ];

        // Act
        IEnumerable<byte> stream = await serializer.Serialize(originals, CancellationToken.None);

        IEnumerable<SerializableRecord> deserialized = await serializer.Deserialize<IEnumerable<SerializableRecord>>(stream, CancellationToken.None);

        // Assert
        _ = deserialized.Should().BeEquivalentTo(originals);
    }

    [Fact]
    public async Task GivenAnInstancesOfARecordWithAReferencedObjectWhenSerializedToAStreamThenACloneOfThatInstanceIsDeserialized()
    {
        // Arrange
        IEnumerable<ISerializableInstance> originals =
        [
            new SerializableRecord(
                [1, 2, 3],
                25,
                new SerializableRecord(
                    [1, 5],
                    3,
                    default,
                    "Something else..."),
                "Something something"),
            new SerializableRecord(
                [4, 5, 6],
                2,
                new SerializableRecord(
                    [2, 4],
                    1,
                    default,
                    "Something else..."),
                "dark side..."),
        ];

        using var stream = new MemoryStream();

        // Act
        await serializer.Serialize(originals, stream, CancellationToken.None);

        stream.Position = 0;

        IEnumerable<ISerializableInstance> deserialized = await serializer
            .Deserialize<IEnumerable<ISerializableInstance>>(stream, CancellationToken.None);

        // Assert
        _ = deserialized.Should().BeEquivalentTo(originals);
    }

    private void Dispose(bool isDisposing)
    {
        if (!isDisposed)
        {
            if (isDisposing)
            {
                ((IDisposable)serializer).Dispose();
            }

            isDisposed = true;
        }
    }
}