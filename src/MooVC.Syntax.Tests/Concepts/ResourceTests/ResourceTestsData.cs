namespace MooVC.Syntax.Concepts.ResourceTests;

using MooVC.Syntax.Attributes.Resource;
using MooVC.Syntax.Elements;
using Resource = MooVC.Syntax.Concepts.Resource;

internal static class ResourceTestsData
{
    public const string DefaultAssemblyAlias = "System.Windows.Forms";
    public const string DefaultAssemblyName = "System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
    public const string DefaultDataComment = "Sample comment";
    public const string DefaultDataMimeType = "text/plain";
    public const string DefaultDataName = "Greeting";
    public const string DefaultDataType = "System.String";
    public const string DefaultDataValue = "Hello";
    public const string DefaultDataXmlSpace = "preserve";
    public const string DefaultHeaderName = "resmimetype";
    public const string DefaultHeaderValue = "text/microsoft-resx";
    public const string DefaultMetadataMimeType = "text/plain";
    public const string DefaultMetadataName = "MetadataKey";
    public const string DefaultMetadataType = "System.String";
    public const string DefaultMetadataValue = "MetadataValue";
    public const string DefaultMetadataXmlSpace = "preserve";

    public static Resource Create(
        Assembly? assembly = default,
        Data? data = default,
        Header? header = default,
        Metadata? metadata = default)
    {
        return new Resource
        {
            Assemblies = assembly is null ? [CreateAssembly()] : [assembly],
            Data = data is null ? [CreateData()] : [data],
            Headers = header is null ? [CreateHeader()] : [header],
            Metadata = metadata is null ? [CreateMetadata()] : [metadata],
        };
    }

    public static Assembly CreateAssembly()
    {
        return new Assembly
        {
            Alias = DefaultAssemblyAlias,
            Name = DefaultAssemblyName,
        };
    }

    public static Data CreateData()
    {
        return new Data
        {
            Comment = DefaultDataComment,
            MimeType = DefaultDataMimeType,
            Name = DefaultDataName,
            Type = DefaultDataType,
            Value = DefaultDataValue,
        };
    }

    public static Header CreateHeader()
    {
        return new Header
        {
            Name = DefaultHeaderName,
            Value = DefaultHeaderValue,
        };
    }

    public static Metadata CreateMetadata()
    {
        return new Metadata
        {
            MimeType = DefaultMetadataMimeType,
            Name = DefaultMetadataName,
            Type = DefaultMetadataType,
            Value = DefaultMetadataValue,
        };
    }
}