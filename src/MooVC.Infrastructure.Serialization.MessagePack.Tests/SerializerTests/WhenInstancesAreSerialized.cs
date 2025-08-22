namespace MooVC.Infrastructure.Serialization.MessagePack.SerializerTests;

public sealed class WhenInstancesAreSerialized
{
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

        var serializer = new Serializer();

        // Act
        IEnumerable<byte> stream = await serializer.Serialize(original, CancellationToken.None);
        SerializableClass deserialized = await serializer.Deserialize<SerializableClass>(stream, CancellationToken.None);

        // Assert
        deserialized.ShouldNotBeSameAs(original);
        deserialized.ShouldBeEquivalentTo(original);
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
        var serializer = new Serializer();

        // Act
        await serializer.Serialize(original, stream, CancellationToken.None);

        stream.Position = 0;

        SerializableClass deserialized = await serializer.Deserialize<SerializableClass>(stream, CancellationToken.None);

        // Assert
        deserialized.ShouldNotBeSameAs(original);
        deserialized.ShouldBeEquivalentTo(original);
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

        var serializer = new Serializer();

        // Act
        await serializer.Serialize<ISerializableInstance>(original, stream, CancellationToken.None);

        stream.Position = 0;

        ISerializableInstance deserialized = await serializer.Deserialize<ISerializableInstance>(stream, CancellationToken.None);

        // Assert
        deserialized.ShouldNotBeSameAs(original);
        deserialized.ShouldBeEquivalentTo(original);
    }

    [Fact]
    public async Task GivenAnInstancesOfAClassThenACloneOfThatInstanceIsDeserialized()
    {
        // Arrange
        SerializableClass[] originals =
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
                Integer = 3,
                String = "dark side...",
            },
        ];

        var serializer = new Serializer();

        // Act
        IEnumerable<byte> stream = await serializer.Serialize(originals, CancellationToken.None);
        IEnumerable<SerializableClass> deserialized = await serializer.Deserialize<IEnumerable<SerializableClass>>(stream, CancellationToken.None);

        // Assert
        deserialized.ShouldBeEquivalentTo(originals);
    }

    [Fact]
    public async Task GivenAnInstancesOfAClassWhenSerializedToAStreamThenACloneOfThatInstanceIsDeserialized()
    {
        // Arrange
        SerializableClass[] originals =
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
                Integer = 9,
                String = "dark side...",
            },
        ];

        using var stream = new MemoryStream();
        var serializer = new Serializer();

        // Act
        await serializer.Serialize(originals, stream, CancellationToken.None);

        stream.Position = 0;

        IEnumerable<SerializableClass> deserialized = await serializer.Deserialize<IEnumerable<SerializableClass>>(stream, CancellationToken.None);

        // Assert
        deserialized.ShouldBeEquivalentTo(originals);
    }

    [Fact]
    public async Task GivenAnInstancesOfAClassWithAReferencedObjectWhenSerializedToAStreamThenACloneOfThatInstanceIsDeserialized()
    {
        // Arrange
        ISerializableInstance[] originals =
        [
            new SerializableClass
            {
                Array = [1, 2, 3],
                Integer = 25,
                Object = new SerializableClass(),
                String = "Something something dark side...",
            },
        ];

        using var stream = new MemoryStream();

        var serializer = new Serializer();

        // Act
        await serializer.Serialize(originals, stream, CancellationToken.None);

        stream.Position = 0;

        IEnumerable<ISerializableInstance> deserialized = await serializer
            .Deserialize<IEnumerable<ISerializableInstance>>(stream, CancellationToken.None);

        // Assert
        deserialized.ShouldBeEquivalentTo(originals);
    }

#if NET5_0_OR_GREATER
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
        var serializer = new Serializer();

        // Act
        await serializer.Serialize(original, stream, CancellationToken.None);

        stream.Position = 0;

        SerializableRecord deserialized = await serializer.Deserialize<SerializableRecord>(stream, CancellationToken.None);

        // Assert
        deserialized.ShouldNotBeSameAs(original);
        deserialized.ShouldBeEquivalentTo(original);
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

        var serializer = new Serializer();

        // Act
        IEnumerable<byte> stream = await serializer.Serialize(original, CancellationToken.None);
        SerializableRecord deserialized = await serializer.Deserialize<SerializableRecord>(stream, CancellationToken.None);

        // Assert
        deserialized.ShouldNotBeSameAs(original);
        deserialized.ShouldBeEquivalentTo(original);
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

        var serializer = new Serializer();

        // Act
        await serializer.Serialize<ISerializableInstance>(original, stream, CancellationToken.None);

        stream.Position = 0;

        ISerializableInstance deserialized = await serializer.Deserialize<ISerializableInstance>(stream, CancellationToken.None);

        // Assert
        deserialized.ShouldNotBeSameAs(original);
        deserialized.ShouldBeEquivalentTo(original);
    }

    [Fact]
    public async Task GivenAnInstancseOfARecordThenACloneOfThatInstanceIsDeserialized()
    {
        // Arrange
        SerializableRecord[] originals =
        [
            new SerializableRecord(
                [1, 2, 3],
                25,
                default,
                "Something something"),
            new SerializableRecord(
                [4, 5, 6],
                7,
                default,
                "dark side..."),
        ];

        var serializer = new Serializer();

        // Act
        IEnumerable<byte> stream = await serializer.Serialize(originals, CancellationToken.None);
        IEnumerable<SerializableRecord> deserialized = await serializer.Deserialize<IEnumerable<SerializableRecord>>(stream, CancellationToken.None);

        // Assert
        deserialized.ShouldBeEquivalentTo(originals);
    }

    [Fact]
    public async Task GivenAnInstancesOfARecordWhenSerializedToAStreamThenACloneOfThatInstanceIsDeserialized()
    {
        // Arrange
        SerializableRecord[] originals =
        [
            new SerializableRecord(
                [1, 2, 3],
                25,
                default,
                "dark side..."),
            new SerializableRecord(
                [4, 5, 6],
                3,
                default,
                "dark side..."),
        ];

        using var stream = new MemoryStream();
        var serializer = new Serializer();

        // Act
        await serializer.Serialize(originals, stream, CancellationToken.None);

        stream.Position = 0;

        IEnumerable<SerializableRecord> deserialized = await serializer.Deserialize<IEnumerable<SerializableRecord>>(stream, CancellationToken.None);

        // Assert
        deserialized.ShouldBeEquivalentTo(originals);
    }

    [Fact]
    public async Task GivenAnInstancesOfARecordWithAReferencedObjectWhenSerializedToAStreamThenACloneOfThatInstanceIsDeserialized()
    {
        // Arrange
        ISerializableInstance[] originals =
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
                5,
                new SerializableRecord(
                    [2, 4],
                    2,
                    default,
                    "Something else..."),
                "dark side..."),
        ];

        using var stream = new MemoryStream();

        var serializer = new Serializer();

        // Act
        await serializer.Serialize(originals, stream, CancellationToken.None);

        stream.Position = 0;

        IEnumerable<ISerializableInstance> deserialized = await serializer.Deserialize<IEnumerable<ISerializableInstance>>(stream, CancellationToken.None);

        // Assert
        deserialized.ShouldBeEquivalentTo(originals);
    }
#endif
}