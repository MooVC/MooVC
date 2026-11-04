namespace MooVC.Serialization.Composition.FactoryTests;

using MooVC.Composition;
using MooVC.Compression;
using Compression = MooVC.Compression.Configuration.Type;
using Serialization = MooVC.Serialization.Configuration.Type;

public sealed class TestFactory
    : Factory<TestSettings>
{
    public const string ExpectedType = "CustomSerializer";

    public TestFactory(IEnumerable<IInstanceStrategy<ICompressor, Compression>> compressors)
        : base(compressors)
    {
    }

    public ICompressor? Compressor { get; private set; }

    public int CreationCount { get; private set; }

    public ISerializer Serializer { get; } = Substitute.For<ISerializer>();

    public TestSettings? Settings { get; private set; }

    protected override ISerializer Create(ICompressor compressor, TestSettings options)
    {
        Compressor = compressor;
        CreationCount++;
        Settings = options;

        return Serializer;
    }

    protected override bool IsExpectedType(Serialization type)
    {
        return type == ExpectedType;
    }
}